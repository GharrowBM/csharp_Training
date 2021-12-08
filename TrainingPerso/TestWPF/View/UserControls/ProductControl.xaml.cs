using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestWPF.Model;

namespace TestWPF.View.UserControls
{
    /// <summary>
    /// Logique d'interaction pour ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {


        public Product Product
        {
            get { return (Product)GetValue(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Product.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register("Product", typeof(Product), typeof(ProductControl), new PropertyMetadata(new Product { Title = "Product Title", Price = 1.99m}, SetProduct));

        private static void SetProduct(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProductControl control = (ProductControl) d;

            if (control != null)
            {
                control.productTitleLebel.Content = (e.NewValue as Product)?.Title;
                control.productPriceLabel.Content = (e.NewValue as Product)?.Price.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        public ProductControl()
        {
            InitializeComponent();
        }
    }
}
