using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteExcel
{
    class GetData
    {

        SqlConnection _dconn;
        private string _strCon = @"server=.\IRANSQL;database=LearFinanzas;integrated security=SSPI; MultipleActiveResultSets=True;";
        private string _query = string.Empty;
        private SqlDataReader reporte;
        private List<DataTable> tableList = new List<DataTable>();

        public List<DataTable> DataTable(List<string> listaAsientos, Form1 f1)
        {
            Task[] wait = new Task[listaAsientos.Count];
            int i = 0;
            foreach (string asiento in listaAsientos)
            {
                wait[i] = Task.Factory.StartNew(() => RowGenerator(i, asiento));
                i++;
            }
            Task.WaitAll(wait);
            return tableList;
        }

        private void RowGenerator(int i, string asiento)
        {
            SqlConnection _dconn = new SqlConnection(_strCon);
            
                    _dconn.Open();
                //CambiarListBox(asiento, f1);
                _query = "getReport '" + asiento + "'";
                DataTable dTable = new DataTable();
                SqlCommand comando = new SqlCommand(_query, _dconn);
                comando.CommandTimeout = 60;
                reporte = comando.ExecuteReader();
                //comando.Dispose();
                dTable.Load(reporte);
                //reporte.Dispose();
                tableList.Add(dTable);
                _dconn.Close();
        }

        private void CambiarListBox(string asiento, Form1 f1)
        {
            f1.listFrontales.SelectedIndex = -1;
            f1.listTraseras.SelectedIndex = -1;

            int indexF = f1.listFrontales.FindString(asiento);
            int indexT = f1.listTraseras.FindString(asiento);

            if (indexF > -1)
                f1.listFrontales.SetSelected(indexF, true);

            if (indexT > -1)
                f1.listTraseras.SetSelected(indexT, true);
        }
    }
}
