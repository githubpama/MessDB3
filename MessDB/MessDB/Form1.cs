using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace MessDB
{
    public partial class Form1 : Form
    {
        private const string V = "Provider=Microsoft.ACE.OLEDB.12.0;data source=C:\\Users\\pama\\source\repos\\MessDB\\MessDB32\\MessDB\\MessDB\\Database21.accdb";
        private string dgv;
        private string filename;
        private object camellabs;


        public Form1()
        {
            InitializeComponent();
           
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form title
        }
        
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database21DataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.database21DataSet.Table1);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.table1TableAdapter.FillBy(this.database21DataSet.Table1);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.table1TableAdapter.Update(this.database21DataSet.Table1);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("osk.exe");
        }

        private void button3_Click(object sender, EventArgs e)

        {
            {
                moduleExcel excelImp = new moduleExcel();

                string title = " Excel Export by Camellabs";
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = "camellabs.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //to fix here
                    excelImp.ToCsV(dataGridView1, "camellabs.xls");
                    MessageBox.Show("Finish");
                }
            }

           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                string connString =
                    V;

                DataTable dataTableRes = new DataTable();

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Table1", conn);

                    conn.Open();

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                    adapter.Fill(dataTableRes);
                }

                dataGridView1.DataSource = dataTableRes;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }


}
    

