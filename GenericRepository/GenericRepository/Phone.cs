using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class Phone
    {
        public string Number { get; set; }

        public string Model { get; set; }

        public Phone(String number, String model)
        {
            Number = number;
            Model = model;
        }
        public override string ToString()
        {
         return $"{Number} {Model}";
        }
    }
}
