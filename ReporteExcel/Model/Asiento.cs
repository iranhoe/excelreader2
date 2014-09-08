using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteExcel.Model
{
    public class Asiento
    {
        private int empLevel;

        public int EmpLevel
        {
            get { return empLevel; }
            set { empLevel = value; }
        }


        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        

        private string componentPart;

        public string ComponentPart
        {
            get { return componentPart; }
            set { componentPart = value; }
        }

        private string itemType;

        public string ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        private double quantity;

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string parentPort;

        public string ParentPort
        {
            get { return parentPort; }
            set { parentPort = value; }
        }

        private int family;

        public int Family
        {
            get { return family; }
            set { family = value; }
        }


    }
}
