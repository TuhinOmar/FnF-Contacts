using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FnF___Contacts
{
    public partial class formPriyoList : Form
    {
        public formPriyoList()
        {
            InitializeComponent();
        }

        static string myConnStrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(myConnStrng);
            string sql = "SELECT * FROM PriyoList";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            conn.Open();

            dgvPriyoList.DataSource = dt;
        }
    }
}
