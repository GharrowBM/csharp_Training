using BanqueTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanqueTest
{
    public partial class Form1 : Form
    {
        private List<Client> clients;

        public Form1()
        {
            clients = new List<Client>();
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (txtbox_name.Text != String.Empty && txtbox_fname.Text != String.Empty && txtbox_phone.Text != String.Empty)
            {
                clients.Add(new Client(txtbox_name.Text, txtbox_fname.Text, txtbox_phone.Text));
                lstvw_datas.Items.Clear();
                foreach (Client client in clients)
                {
                    ListViewItem item = new ListViewItem("", 0);
                    item.SubItems.Add(client.Name);
                    item.SubItems.Add(client.FName);
                    item.SubItems.Add(client.PhoneNumber);
                    lstvw_datas.Items.Add(item);

                }
            }
        }
    }
}
