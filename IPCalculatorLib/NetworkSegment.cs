using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCalculator
{
    public class NetworkSegment:IComparable
    {
        public string Name { get; set; }
        public int numberOfHosts { get; set; }
        public NetworkSegment (string Name, int numberOfHosts){
            this.Name = Name;
            this.numberOfHosts = numberOfHosts;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherTemperature = obj;
            if (otherTemperature != null)
                return this.numberOfHosts.CompareTo(otherTemperature);
            else
                throw new ArgumentException("Object is not a numberofHosts");
        }
    }
}
