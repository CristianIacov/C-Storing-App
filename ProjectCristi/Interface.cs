using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCristi
{
    public partial class Interface : Form
    {
        Products4 product = new Products4();

        public Interface()
        {
            InitializeComponent();
        }
        void Reset()
        {
            Name.Text = Price.Text = Quantity.Text = null;
            product.id = 0;  
        }
        void ListDataGridView()
        {
            using(Produse2Entities pd=new Produse2Entities())
            {
                dgv.DataSource = pd.Products4.ToList<Products4>();


            }
        }
       
        private void Interface_Load(object sender, EventArgs e)
        {
            Reset();
            ListDataGridView();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                product.Name = Name.Text;
                product.Price = Double.Parse(Price.Text);
                product.Quantity = int.Parse(Quantity.Text);

                using (Produse2Entities pd = new Produse2Entities())
                {
                    pd.Products4.Add(product);
                    pd.SaveChanges();
                    MessageBox.Show("Succesful");
                    Reset();
                    ListDataGridView();
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Invalid Price");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Data");

            }
            catch (OverflowException)
            {
                MessageBox.Show("Invalid Quantity");
            }



           
           
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                product.Name = Name.Text;
                product.Price = Double.Parse(Price.Text);
                product.Quantity = int.Parse(Quantity.Text);
                using (Produse2Entities pd = new Produse2Entities())
                {
                    pd.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    pd.SaveChanges();
                    ListDataGridView();
                    MessageBox.Show("Edited");
                }
                
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Invalid Price");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Data");

            }
            catch (OverflowException)
            {
                MessageBox.Show("Invalid Quantity");
            }
        }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.CurrentRow.Index != -1)
            {
                product.id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                using (Produse2Entities pd = new Produse2Entities())
                {
                    product = pd.Products4.Where(aux => aux.id == product.id).FirstOrDefault();
                    Name.Text = product.Name;
                    Price.Text = product.Price.ToString();
                    Quantity.Text = product.Quantity.ToString();
                }
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
           using(Produse2Entities pd=new Produse2Entities())
            {
                var entrances = pd.Entry(product);
                if (entrances.State == System.Data.Entity.EntityState.Detached)
                    pd.Products4.Attach(product);
                pd.Products4.Remove(product);
                pd.SaveChanges();
                ListDataGridView();
                Reset();
                MessageBox.Show("Deleted");
            }
        }
    }
}
