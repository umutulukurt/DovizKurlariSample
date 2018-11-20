using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizKurlari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Islem islem = new Islem();

            DataTable dovizKurlari = islem.DovizKurlari();

            foreach (DataRow item in dovizKurlari.Rows)
            {
                Control groupBox = islem.WidgetOlustur(item[1].ToString(), item[2].ToString(), item[0].ToString(), new Point(6,51), new Point(6,25), new Point());
                this.Controls.Add(groupBox);
            }
        }
    }
}
