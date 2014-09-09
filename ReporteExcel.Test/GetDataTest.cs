using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReporteExcel;
using ReporteExcel.Model;
using System.Collections.Generic;

namespace ReporteExcel.Test
{
    [TestClass]
    public class GetDataTest
    {
        private List<string> asientos = new List<string>();

        [TestInitialize]
        public void Initialize()
        {
            asientos.Add("95OZ4IA");
        }

        [TestMethod]
        public void ConvertDataTableToListOK()
        {
            GetData getData = new GetData();
            var asientosDT = getData.DataTable(asientos, new Form1());


            var result = getData.ConvertDataTableToList(asientosDT[0]);
            Asiento firstResult = result[0];

            //Asserts
            Assert.AreEqual("SIDESHIELD LH 10WP CD533", firstResult.Descripcion);
            Assert.AreEqual(491,result.Count);
        }

        [TestMethod]
        public void OrderListOK()
        {
            GetData getData = new GetData();
            var asientosDT = getData.DataTable(asientos, new Form1());
            var asientosList = getData.ConvertDataTableToList(asientosDT[0]);

            var result = getData.OrderList(asientosList);

            Assert.AreEqual(491, result.Count);
            Assert.AreEqual(3,result[99].EmpLevel);
        }
    }
}
