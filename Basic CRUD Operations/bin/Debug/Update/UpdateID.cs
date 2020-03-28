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
    public partial class UpdateID : Form
    {
        

        public UpdateID()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string employeeID = MappedEmployeeID.Text; 

            if (String.IsNullOrEmpty(MappedEmployeeID.Text))
            {
                MessageBox.Show("Enter a valid ID");
            }

            
            else if (CheckEmployeeIDexists(employeeID))
            {
                Update update = new Update();
                update.UpdateEmployeeID.Text = MappedEmployeeID.Text;
                update.ShowDialog();

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
            cmd.Parameters.AddWithValue("@EmployeeID", MappedEmployeeID.Text);

            int EmployeeCount = Convert.ToInt32(cmd.ExecuteScalar());

            cnn.Close();

            if (EmployeeCount > 0)
                return true;
            return false;
        }
    }
}
