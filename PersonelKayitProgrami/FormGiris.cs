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
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-53PSGMT;Initial Catalog=PERSONALDATA;Integrated Security=True");


        private void FormGiris_Load(object sender, EventArgs e)
        {

        }

        private void GirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut1.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader okuyucu1 = komut1.ExecuteReader();
            if (okuyucu1.Read())
            {
                FrmAna frm = new FrmAna();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali Kullanici Adi veya Şifre");
            }
            baglanti.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
