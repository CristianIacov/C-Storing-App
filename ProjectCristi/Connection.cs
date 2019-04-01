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

namespace ProjectCristi
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection cnn;

           // cnn = new SqlConnection("Server =DESKTOP-DPQK64Q;Database=Employee;Trusted_Connection= True");
            cnn = new SqlConnection("Data Source=DESKTOP-DPQK64Q;Initial Catalog=Employee;User=sa;Password=12345");
            cnn.Open();
            MessageBox.Show("Connection Open  !");
           // Application.Run(new Interface());
            cnn.Close();
           


        }

        private void forma_Load(object sender, EventArgs e)
        {

        }
    }
}