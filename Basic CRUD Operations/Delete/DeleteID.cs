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

namespace Basic_CRUD_Operations.Delete
{
    public partial class DeleteID : Form
    {
        public DeleteID()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void DeleteID_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeID = DeleteEmployeeId.Text;

            if (String.IsNullOrEmpty(DeleteEmployeeId.Text))
            {
                MessageBox.Show("Enter a valid ID");   
            }
            else if (CheckEmployeeIDexists(employeeID))
            {
                DeleteEmployee();
            }
            else
            {
                MessageBox.Show("EmployeeID doesn't exists.");
            }

        }

        bool CheckEmployeeIDexists(string EmployeeID)
        {

            SqlConnection cnn = new SqlConnection(@"Data Source=YASH\SQLEXPRESS;database=Employees;Integrated Security = true");
            cnn.Open();

            SqlCommand cmd = new SqlCommand("select * from dbo.Employees where EmployeeID = @EmployeeID", cnn);
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@EmployeeID", DeleteEmployeeId.Text);

            int EmployeeCount = Convert.ToInt32(cmd.ExecuteScalar());

            cnn.Close();

            if (EmployeeCount > 0)
                return true;
            return false;
        }

        void DeleteEmployee()
        {
            {
                SqlConnection cnn = new SqlConnection(@"Data Source=YASH\SQLEXPRESS;database=Employees;Integrated Security = true");

                SqlCommand cmd = new SqlCommand("Delete from dbo.Employees Where EmployeeID = @EmployeeID", cnn);
                cnn.Open();
                SqlParameter param = new SqlParameter();
                cmd.Parameters.AddWithValue("@EmployeeID", DeleteEmployeeId.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Record deleted Successfully");
            }
        }

        private void DeleteEmployeeId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
