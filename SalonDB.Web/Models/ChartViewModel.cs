using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.Models
{
    [Serializable]
    public class ChartViewModel
    {
        public ChartViewModel(double id, string name, double value1, double value2 = 0, double value3 = 0, double value4 = 0, double value5 = 0)
        {
            this.ID = id;
            this.Name = name;
            this.Value1 = value1;
            this.Value2 = value2;
            this.Value3 = value3;
            this.Value4 = value4;
            this.Value5 = value5;
        }
        public double ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public double Value1
        {
            get;
            set;
        }

        public double Value2
        {
            get;
            set;
        }
        public double Value3
        {
            get;
            set;
        }
        public double Value4
        {
            get;
            set;
        }
        public double Value5
        {
            get;
            set;
        }

    }
}