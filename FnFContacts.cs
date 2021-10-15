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
using FnF___Contacts.FnFContactsClasses;
using System.Configuration;

namespace FnF___Contacts
{
    public partial class FnFContacts : Form
    {
        public FnFContacts()
        {
            InitializeComponent();
        }

        FnFClass c = new FnFClass();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)                                                               // deletion mechanism
        {
            
            c.ContactID = int.Parse(txtboxContactID.Text);

            bool success = c.Delete(c);

            if (success)
            {
                MessageBox.Show("Successfully deleted!");
                DataTable dt = c.Select();
                dgv.DataSource = dt;

                Clear();
            }
            else
            {
                MessageBox.Show("Deletion failed. try again.");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)                                                               // Add or insertion of contacts
        {
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtboxContactNo.Text;
            c.Adress = txtboxAddress.Text;
            c.Gender = cbGender.Text;

            bool success = c.Insert(c);
            if (success)
            {
                MessageBox.Show("Contact inserted successfully!");
            }
            else
            {
                MessageBox.Show("Failed to add new contact. Try again.");
            }

            DataTable dt = c.Select();
            dgv.DataSource = dt;

            Clear();

        }
        private void Clear()
        {
            txtboxContactID.Text = "";
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtboxContactNo.Text = "";
            txtboxAddress.Text = "";
            cbGender.Text = "";
        }

        private void pbClose_Click(object sender, EventArgs e)                                                                 //closing form
        {
            this.Close();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtboxContactID.Text = dgv.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgv.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgv.Rows[rowIndex].Cells[2].Value.ToString();
            txtboxContactNo.Text = dgv.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxAddress.Text = dgv.Rows[rowIndex].Cells[4].Value.ToString();
            cbGender.Text = dgv.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)                                                                 // clear fields
        {
            Clear();
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtboxContactID.Text = dgv.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgv.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgv.Rows[rowIndex].Cells[2].Value.ToString();
            txtboxContactNo.Text = dgv.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxAddress.Text = dgv.Rows[rowIndex].Cells[4].Value.ToString();
            cbGender.Text = dgv.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)                                                               // update mechanish
        {
            try
            {
                c.ContactID = int.Parse(txtboxContactID.Text);
                c.FirstName = txtboxFirstName.Text;
                c.LastName = txtboxLastName.Text;
                c.ContactNo = txtboxContactNo.Text;
                c.Adress = txtboxAddress.Text;
                c.Gender = cbGender.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            bool success = c.Update(c);
            if (success)
            {
                MessageBox.Show("Contact successfully updated!");
                DataTable dt = c.Select();
                dgv.DataSource = dt;

                Clear();
            }
            else
            {
                MessageBox.Show("Updation Failed. Try again.");
            }
        }

        private void FnFContacts_Load(object sender, EventArgs e)                                                            // load contacts on start up
        {
            DataTable dt = c.Select();
            dgv.DataSource = dt;
        }

        static string myConnStrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void txtboxSearch_TextChanged(object sender, EventArgs e)                                                   //contact searching mechanism
        {
            SqlConnection conn = new SqlConnection(myConnStrng);
            string keyword = txtboxSearch.Text;
            string sql = "SELECT * FROM FnFList WHERE FirstName like '%"+keyword+"%' OR LastName like '%"+keyword+"%' OR Address like '%"+keyword+"%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgv.DataSource = dt;
        }

        private void btnAddToPriyoList_Click(object sender, EventArgs e)
        {
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtboxContactNo.Text;
            c.Adress = txtboxAddress.Text;
            c.Gender = cbGender.Text;

            bool success = c.Insert_priyo(c);
            if (success)
            {
                MessageBox.Show("Added to priyo list!");
            }
            else
            {
                MessageBox.Show("Failed to add new contact. Try again.");
            }

            DataTable dt = c.Select();
            dgv.DataSource = dt;

            Clear();
        }


        private void btnShowPriyoList_Click(object sender, EventArgs e)
        {
            formPriyoList o = new formPriyoList();
            o.Show();
        }
    }
}
