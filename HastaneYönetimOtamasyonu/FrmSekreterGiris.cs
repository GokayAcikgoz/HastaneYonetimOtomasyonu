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

namespace HastaneYönetimOtamasyonu
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            

            SqlCommand komut = new SqlCommand("select * from Tbl_Sekreter where SekreterTc = @p1 and SekreterSifre = @p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frmSekreterDetay = new FrmSekreterDetay();
                frmSekreterDetay.tc = MskTc.Text;
                frmSekreterDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Tc veya Şifre");
            }

            bgl.baglanti().Close();

            
        }
    }
}
