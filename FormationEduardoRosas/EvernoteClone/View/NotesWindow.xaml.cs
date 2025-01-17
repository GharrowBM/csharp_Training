﻿using Azure.Storage.Blobs;
using EvernoteClone.ViewModel;
using EvernoteClone.ViewModel.Helpers;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvernoteClone.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        NotesVM vm;

        public NotesWindow()
        {
            InitializeComponent();

            vm = Resources["vm"] as NotesVM;
            vm.SelectedNoteChanged += Vm_SelectedNoteChanged;

            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            fontFamilyComboBox.ItemsSource = fontFamilies;

            List<double> fontSizes = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 28, 48, 72 };
            fontSizeComboBox.ItemsSource = fontSizes;

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (string.IsNullOrEmpty(App.UserId))
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                vm.GetNotebooks();
            }
        }

        private async void Vm_SelectedNoteChanged(object? sender, EventArgs e)
        {
            contentRichTextBox.Document.Blocks.Clear();

            if (vm.SelectedNote != null)
            {
                if (!string.IsNullOrEmpty(vm.SelectedNote.FileLocation))
                {
                    string downloadPath = $"{vm.SelectedNote.Id}.rtf";
                    await new BlobClient(new Uri(vm.SelectedNote.FileLocation)).DownloadToAsync(downloadPath);

                    using (FileStream fs = new FileStream(downloadPath, FileMode.Open))
                    {
                        var contents = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
                        contents.Load(fs, DataFormats.Rtf);
                    }
                }
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            string region = "francecentral";
            string key = MSSpeechAuthHelper.Key;

            var speechConfig = SpeechConfig.FromSubscription(key, region);
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var result = await recognizer.RecognizeOnceAsync();
            contentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(result.Text)));
        }

        private void contentRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int amountOfCharacters = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd).Text.Length;

            statusTextBlock.Text = $"Document length: {amountOfCharacters} {(amountOfCharacters > 1 ? "characters" : "character")}";
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonChecked)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            }
        }

        private void contentRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedWeight = contentRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldButton.IsChecked = selectedWeight != DependencyProperty.UnsetValue && selectedWeight.Equals(FontWeights.Bold);

            var selectedStyle = contentRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italicButton.IsChecked = selectedStyle != DependencyProperty.UnsetValue && selectedStyle.Equals(FontStyles.Italic);

            var selectedDecoration = contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underlineButton.IsChecked = selectedDecoration != DependencyProperty.UnsetValue && selectedDecoration.Equals(TextDecorations.Underline);

            var selectedFontFamily = contentRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);

            var selectedSize = contentRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty).ToString();

        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonChecked)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
            }
        }

        private void underlineButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonChecked)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                TextDecorationCollection textDecorations;
                (contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecorations);
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }
        }

        private void fontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontFamilyComboBox.SelectedItem != null)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
            }
        }

        private void fontSizeComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeComboBox.Text);
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = $"{vm.SelectedNote.Id}.rtf";
            string rtfFile = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);

            using (FileStream fs = new FileStream(rtfFile, FileMode.Create))
            {
                var contents = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
                contents.Save(fs, DataFormats.Rtf);

            }


            vm.SelectedNote.FileLocation = await UpdateFile(rtfFile, fileName);
            await DatabaseHelper.Update(vm.SelectedNote);
        }

        private async Task<string> UpdateFile(string rtfFilePath, string fileName)
        {
            string connectionString = MSContainerAuthHelper.ConnectionString;
            string containerName = "notes";

            var container = new BlobContainerClient(connectionString, containerName);
            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlobClient(fileName);
            await blob.UploadAsync(rtfFilePath, true);

            return $"https://gharrowevernotestorage.blob.core.windows.net/notes/{fileName}";
        }
    }
}
