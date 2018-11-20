using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizKurlari
{
    public class Islem
    {
        public DataTable DovizKurlari()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://tcmb.gov.tr/kurlar/today.xml");
            var nodes = doc.SelectNodes("//Tarih_Date//Currency");

            DataTable dt = new DataTable();
            dt.Columns.Add("Adı");
            dt.Columns.Add("Alış Değeri");
            dt.Columns.Add("Satış Değeri");

            DataRow row;//satır

            for (int i = 0; i < nodes.Count; i++)
            {
                row = dt.NewRow();
                row[0] = nodes[i].SelectSingleNode("Isim").InnerText;
                row[1] = nodes[i].SelectSingleNode("ForexBuying").InnerText;
                row[2] = nodes[i].SelectSingleNode("ForexSelling").InnerText;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public Control WidgetOlustur(string alisDegeri, string satisDegeri,string isim,Point lbl1Point, Point lbl2Point, Point gbPoint)
        {
            Label lbl1 = new Label();
            lbl1.Text = "Alış Değeri: "+alisDegeri;
            lbl1.Location = lbl1Point;
            Label lbl2 = new Label();
            lbl2.Text = "Satış Değeri: "+satisDegeri;
            lbl2.Location = lbl2Point;
        
            GroupBox gb = new GroupBox();
            gb.Name = Guid.NewGuid().ToString();
            gb.Text = isim;
            gb.Location = new System.Drawing.Point(101, 49);
            gb.Size = new System.Drawing.Size(200, 78);
            gb.Location = gbPoint;
            gb.Controls.Add(lbl1);
            gb.Controls.Add(lbl2);

            return gb;
            
        }
    }
}

