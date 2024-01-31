using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayitProgrami
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-53PSGMT;Initial Catalog=PERSONALDATA;Integrated Security=True");


        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //grafikler 1
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select PerSehir, Count (*) From Tbl_Personel group by PerSehir", baglanti);
            SqlDataReader okuyucu1 = komut1.ExecuteReader();
            while (okuyucu1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(okuyucu1[0], okuyucu1[1]);
            }
            baglanti.Close();


            //grafikler 2
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select PerMeslek, Avg (PerMaas) From Tbl_Personel group by PerMeslek", baglanti);
            SqlDataReader okuyucu2 = komut2.ExecuteReader();
            while (okuyucu2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(okuyucu2[0], okuyucu2[1]);
            }
            baglanti.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
