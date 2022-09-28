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

namespace Film_Arsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RBCL1FM\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True");

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * FROM TBLFILMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (AD,KATEGORI,LINK) VALUES (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@P3", TxtLink.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Film Bilgisi Eklendi");
            filmler();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);

        }

        private void BtnHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Yuşa Abdullah AYAR tarafından 29 Eylül 2022' de kodlandı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRenkDegistir_Click(object sender, EventArgs e)
        {
         
         
            
                BackColor = Color.Green;
               
                
            
          
       
            

        }

        private void BtnTamEkran_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            
        }
    }
}
