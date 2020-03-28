using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_CRUD_Operations
{
    public partial class Create : Form
    {


        public Create()
        {
            InitializeComponent();
           
        }


        #region Labels
        private void Create_Load(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void employeeId_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        } 
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

          
            string employee = employeeId.Text;


            if (String.IsNullOrEmpty(employee))
            {
                MessageBox.Show("EmployeeID cannot be null.");
            }
            else if (CheckDuplicateEmployeeID(employee))
            {
                MessageBox.Show("EmployeeID already exists");

            }
            else
            {
                AddNewEmployee();
            }
           
            Close();
            
        }


        bool CheckDuplicateEmployeeID(string EmployeeID)
        {

            SqlConnection cnn = new SqlConnection(@"Data Source=YASH\SQLEXPRESS;database=Employees;Integrated Security = true");
            cnn.Open();

            SqlCommand cmd = new SqlCommand("select * from dbo.Employees where EmployeeID = @EmployeeID", cnn);
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@EmployeeID", employeeId.Text);

            int EmployeeCount = Convert.ToInt32(cmd.ExecuteScalar());

            cnn.Close();

            if (EmployeeCount > 0)
                return true;
            return false;
        }

        void AddNewEmployee()
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=YASH\SQLEXPRESS;database=Employees;Integrated Security = true");
            SqlCommand cmd = new SqlCommand("Insert dbo.Employees (EmployeeID,FirstName,LastName,Address,Contact) values(@EmployeeID,@firstname,@lastname,@address,@Contact)", cnn);
            cnn.Open();
            SqlParameter param = new SqlParameter();
            cmd.Parameters.AddWithValue("@EmployeeID", employeeId.Text);
            cmd.Parameters.AddWithValue("@Firstname", firstName.Text);
            cmd.Parameters.AddWithValue("@Lastname", lastname.Text);
            cmd.Parameters.AddWithValue("@Address", address.Text);
            cmd.Parameters.AddWithValue("@Contact", contact.Text);
            cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Record Inserted Successfully");
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
