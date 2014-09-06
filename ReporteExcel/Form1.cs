using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReporteExcel
{
    public partial class Form1 : Form
    {
        BackgroundWorker bgwReadExcel = new BackgroundWorker();
        BackgroundWorker bgwWriteExcel = new BackgroundWorker();
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private List<string> listaAsientos = new List<string>();
        private List<DataTable> listaDT;
        delegate void SetTextCallback(string text);
        string path;

        public Form1()
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "Excel File (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            InitializeComponent();
            bgwReadExcel.DoWork += new DoWorkEventHandler(bgwReadExcel_DoWork);
            bgwReadExcel.ProgressChanged += new ProgressChangedEventHandler(bgwReadExcel_ProgressChanged);
            bgwReadExcel.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwReadExcel_RunWorkerCompleted);

            bgwWriteExcel.DoWork += new DoWorkEventHandler(bgwWriteExcel_DoWork);
            bgwWriteExcel.ProgressChanged += new ProgressChangedEventHandler(bgwWriteExcel_ProgressChanged);
            bgwWriteExcel.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwWriteExcel_RunWorkerCompleted);

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            btnGenerar.Enabled = false;
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblStatus.Text = "";
                lblStatus.Visible = true;
                progressBar1.Visible = true;
                bgwReadExcel.WorkerReportsProgress = true;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
                btnCargar.Enabled = false;
                this.bgwReadExcel.RunWorkerAsync();                
            }

        }

        private void bgwReadExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            //var backgroundWorker = sender as BackgroundWorker;

            SetText("Leyendo archivo excel...");

            ExcelReader eReader = new ExcelReader();
            path = openFileDialog1.FileName;
            listaAsientos = eReader.ReadFile(path, this);
        }

        public void Progress(int progress)
        {
            if (bgwReadExcel.IsBusy)
                bgwReadExcel.ReportProgress(progress);

            if (bgwWriteExcel.IsBusy)
                bgwWriteExcel.ReportProgress(progress);
        }

        private void bgwReadExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwReadExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (listaAsientos.Count == 1)
            {
                MessageBox.Show(listaAsientos.FirstOrDefault());
            }
            else
            {
                Separar(listaAsientos);
                SetText("Datos cargados con exito.");
                listaDT = null;
                btnGenerar.Enabled = true;
            }
                        
            btnCargar.Enabled = true;            
            progressBar1.Visible = false;            
        }

        public void SetText(string text)
        {
            if (this.lblStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblStatus.Text = text;
            }
        }

        private void Separar(List<string> listaAsientos)
        {
            List<string> listaTrasera = new List<string>();
            List<string> listaFrontal = new List<string>();

            foreach (string linea in listaAsientos)
            {
                    switch (linea[4])
                    {
                        case 'T': case '5': case '6': case '7':
                            listaTrasera.Add(linea);
                            break;

                        default:
                            listaFrontal.Add(linea);
                            break;
                    }
            }

            listTraseras.DataSource = listaTrasera;
            listFrontales.DataSource = listaFrontal;
            listFrontales.SelectedIndex = -1;
            listTraseras.SelectedIndex = -1;

            return;
        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Creando el reporte de cada asiento...";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            GetData data = new GetData();
           

            saveFileDialog1.Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            System.Threading.Thread.Sleep(1);
            if (listaDT == null)
            {
                var result = await Task.Run(() => data.DataTable(listaAsientos, this));
                listaDT = result;
            }


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                path = saveFileDialog1.FileName;
                lblStatus.Visible = true;
                progressBar1.Visible = true;
                bgwWriteExcel.WorkerReportsProgress = true;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
                btnCargar.Enabled = false;
                btnGenerar.Enabled = false;
                bgwWriteExcel.RunWorkerAsync();
            }

            
        }

        private void bgwWriteExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            ExcelCreate create = new ExcelCreate();
            create.WriteDataTableToExcel(listaDT, "Reportes BOMS", path, "Reportes", this);
        }

        private void bgwWriteExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwWriteExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCargar.Enabled = true;
            btnGenerar.Enabled = true;
            SetText("Archivo generado con exito.");
            progressBar1.Visible = false;
        }
        
    }
}
