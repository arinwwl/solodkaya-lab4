using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solodkaya_lab4
{
    public class Train<T> : ICloneable,IComparable<Train<T>>
    {
        public string Destination { get; set; }
        public T TrainNumber { get; set; }
        public DateTime DepartureTime { get; set; }

        public object Clone()

        {
            return new Train<T>
            {
                Destination = this.Destination,
                TrainNumber = this.TrainNumber,
                DepartureTime = this.DepartureTime
            };
        }

        public int CompareTo(Train<T> other)
        {
            return this.DepartureTime.CompareTo(other.DepartureTime);
        }
    }
   
}
