using System;
using System.Collections.Generic;
using System.Text;

namespace Wydatkii
{
    public class Cost
    {
        public Cost()
        {
        }

        public Cost(int id, string name, decimal value, DateTime dateTime )
        {
            ID = id;
            Name= name;
            Value= value;
            Date = dateTime;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public  DateTime Date { get; set; }
        

    }
}
