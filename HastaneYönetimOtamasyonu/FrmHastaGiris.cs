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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void LnkÜyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frmHastaKayit = new FrmHastaKayit();
            frmHastaKayit.Show();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTc = @p1 and HastaSifre = @p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FrmHastaDetay frmHastaDetay = new FrmHastaDetay();
                frmHastaDetay.tc = MskTc.Text;
                frmHastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!" , "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bgl.baglanti().Close();
        }
    }
}
