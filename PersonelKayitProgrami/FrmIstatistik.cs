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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-53PSGMT;Initial Catalog=PERSONALDATA;Integrated Security=True");


        private void Frmıstatistik_Load(object sender, EventArgs e)
        {
            // Toplam Personel Sayisi

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count (*) From Tbl_Personel",baglanti);
            SqlDataReader okuyucu = komut1.ExecuteReader();
            while (okuyucu.Read())
                {
                    lbltoplamper.Text = okuyucu[0].ToString();
                }
            baglanti.Close();

            // evli personel sayisi
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count (*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader okuyucu2 = komut2.ExecuteReader();
            while (okuyucu2.Read())
            {
                lblEvliPersonel.Text = okuyucu2[0].ToString();  
            }
            baglanti.Close();

            // bekar personel sayisi
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count (*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader okuyucu3 = komut3.ExecuteReader();
            while (okuyucu3.Read())
            {
                lblBekarPersonel.Text = okuyucu3[0].ToString();
            }
            baglanti.Close();


            // şehir sayisi
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader okuyucu4 = komut4.ExecuteReader();
            while (okuyucu4.Read())
            {
                lblSehir.Text = okuyucu4[0].ToString();
            }

            baglanti.Close();


            // toplam maas 
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select Sum (PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader okuyucu5 = komut5.ExecuteReader();
            while (okuyucu5.Read())
            {
                lblToplamamaas.Text = okuyucu5[0].ToString();
            }

            baglanti.Close();

            // ortalama maas 
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select Avg (PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader okuyucu6 = komut6.ExecuteReader();
            while (okuyucu6.Read())
            {
                lblOrtalamaMaas.Text = okuyucu6[0].ToString();
            }

            baglanti.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbltoplamper_Click(object sender, EventArgs e)
        {

        }
    }
}
