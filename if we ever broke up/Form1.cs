using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace if_we_ever_broke_up
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSv.Text.Length == 0 || txtHoTen.Text.Length == 0 || txtLop.Text.Length == 0)
            {
                MessageBox.Show("Vui long nhap du lieu", "Thong Bao");
                string[] arr = new string[] { txtMaSV.Text, txtHoTen.Text, txtLop.Text };
                ListViewItem item = new ListViewItem(arr);
                listView1.Items.AddRange(new ListViewItem[] { item });
                txtMaSv.Clear();
                txtHoTen.Clear();
                txtLop.Clear();
            }
            private void listView1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

        
        }
    }
}
