using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
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
            //Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form title
            label1.Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form title
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

        //csvFileWriter = StreamWriter
        //scannerDataGridView = DataGridView   
        {
            string CsvFpath = @"C:\scanner\CSV-EXPORT.csv";
            try
            {
                System.IO.StreamWriter csvFileWriter = new StreamWriter(CsvFpath, false);

                string columnHeaderText = "";

                int countColumn = dataGridView1.ColumnCount - 1;

                if (countColumn >= 0)
                {
                    columnHeaderText = dataGridView1.Columns[0].HeaderText;
                }

                for (int i = 1; i <= countColumn; i++)
                {
                    columnHeaderText = columnHeaderText + ',' + dataGridView1.Columns[i].HeaderText;
                }


                csvFileWriter.WriteLine(columnHeaderText);

                foreach (DataGridViewRow dataRowObject in dataGridView1.Rows)
                {
                    if (!dataRowObject.IsNewRow)
                    {
                        string dataFromGrid = "";

                        dataFromGrid = dataRowObject.Cells[0].Value.ToString();

                        for (int i = 1; i <= countColumn; i++)
                        {
                            dataFromGrid = dataFromGrid + ',' + dataRowObject.Cells[i].Value.ToString();

                            csvFileWriter.WriteLine(dataFromGrid);
                        }
                    }
                }


                csvFileWriter.Flush();
                csvFileWriter.Close();
            }
            catch (Exception exceptionObject)
            {
                MessageBox.Show(exceptionObject.ToString());
            }
        }
            private void groupBox1_Enter(object sender, EventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }
        }
    }


    

