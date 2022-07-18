using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneYönetimOtamasyonu
{
    internal class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=GOKAY\\SQLEXPRESS;Initial Catalog=HastaneProje;Integrated Security=True");

            baglan.Open();

            return baglan;
        }

        
    }
}
