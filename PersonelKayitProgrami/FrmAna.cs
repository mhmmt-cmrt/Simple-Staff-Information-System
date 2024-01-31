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
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-53PSGMT;Initial Catalog=PERSONALDATA;Integrated Security=True");

        void Temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtSehir.Text = "";
            txtMeslek.Text = "";
            ComboMaas.Text = "";
            radioButtonEvli.Checked = false;
            radioButtonBekar.Checked = false;
            txtAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'pERSONALDATADataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.

            this.tbl_PersonelTableAdapter.Fill(this.pERSONALDATADataSet.Tbl_Personel);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.pERSONALDATADataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1, @p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtSehir.Text);
            komut.Parameters.AddWithValue("@p4", ComboMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("PERSONEL EKLENDI ");
        }

        private void radioButtonEvli_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEvli.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButtonBekar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEvli.Checked == false)
            {
                label8.Text = "False";
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text =     dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text =     dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text =  dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSehir.Text =  dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            ComboMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text =    dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
           
            if (label8.Text == "False")
            {
                radioButtonBekar.Checked = true;
            }
            if (label8.Text == "True")
            {
                radioButtonEvli.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand sql = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1", baglanti);
            sql.Parameters.AddWithValue("@k1", txtID.Text);
            sql.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand sql = new SqlCommand("Update Tbl_Personel Set PerAd =@A1, PerSoyad = @A2,PerSehir = @A3,PerMaas = @A4, PerDurum= @A5,PerMeslek = @A6 where Perid = @A7",baglanti);
            sql.Parameters.AddWithValue("@A1", txtAd.Text);
            sql.Parameters.AddWithValue("@A2", txtSoyad.Text);
            sql.Parameters.AddWithValue("@A3", txtSehir.Text);
            sql.Parameters.AddWithValue("@A4", ComboMaas.Text);
            sql.Parameters.AddWithValue("@A5", label8.Text);
            sql.Parameters.AddWithValue("@A6", txtMeslek.Text);
            sql.Parameters.AddWithValue("@A7", txtID.Text); 
            sql.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            FrmIstatistik fr = new FrmIstatistik();
            fr.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
    }
}
