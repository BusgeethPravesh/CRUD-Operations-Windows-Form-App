using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_CRUD_Operations.Update
{
    public partial class Update : Form
    {

        public Update()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmployeeIDMapped_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateID updateID = new UpdateID();

            SqlConnection cnn = new SqlConnection(@"Data Source=YASH\SQLEXPRESS;database=Employees;Integrated Security = true");
            SqlCommand cmd = new SqlCommand("Update dbo.Employees SET Firstname =@firstname,lastname = @lastname,Address=@Address,Contact=@Contact WHERE EmployeeID = @EmployeeID", cnn);
            cnn.Open();
            SqlParameter param = new SqlParameter();
            cmd.Parameters.AddWithValue("@EmployeeID", UpdateEmployeeID.Text);
            cmd.Parameters.AddWithValue("@Firstname", UpdatefirstName.Text);
            cmd.Parameters.AddWithValue("@Lastname", Updatelastname.Text);
            cmd.Parameters.AddWithValue("@Address", Updateaddress.Text);
            cmd.Parameters.AddWithValue("@Contact", Updatecontact.Text);

            if (UpdatefirstName.Text == "")
            {
                MessageBox.Show("Please enter an updated FirstName");
            }
            else
            {
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Record Updated Successfully");
                Close();
            }
           
            
            
            
        }

        private void Update_Load(object sender, EventArgs e)
        {

        }

    }
}
