using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPCalculator;

namespace IPCalculator
{
    public class AddressSpace
    {
        private int needed;
        private List<NetworkSegment> hostsEachSubnet;
        private string majorNetwork;
        private List<Subnet> networks = new List<Subnet>();
        private int subnetCreated = 0;
        private int power = 0;
        private int majorNetworkPrefix = 0;

        public AddressSpace(List<NetworkSegment> hostsEachSubnet, string majorNetwork)
        {
            this.needed = hostsEachSubnet.Count;
            this.hostsEachSubnet = hostsEachSubnet;
            this.majorNetwork = majorNetwork;
            this.doMath();
        }

        public int getSubnetCreated()
        {
            return this.subnetCreated;
        }

        public bool isValid()
        {
            if (!this.isValidMajorNetwork())
                return false;

            return this.power <= (30 - this.majorNetworkPrefix);
        }

        public List<Subnet> getNetworks()
        {
            return this.networks;
        }

        public bool isValidMajorNetwork()
        {
            string[] ip = this.majorNetwork.Split('/');
            int[] ipOctets;

            if (!(ip.Length == 2))
                return false;

            if (!int.TryParse(ip[1], out this.majorNetworkPrefix))
                return false;

            try
            {
                ipOctets = Array.ConvertAll<string, int>(
                ip[0].Split('.'),
                int.Parse
            );
            }
            catch (Exception)
            {
                return false;
            }
            this.majorNetworkPrefix = System.Convert.ToInt32(ip[1]);

            if (!(ipOctets.Length == 4))
                return false;

            foreach (int octet in ipOctets)
            {
                if (!(octet >= 0 && octet <= 255))
                    return false;
            }
            return true;
        }

        private void doMath()
        {
            if (!this.isValid())
            {
                return;
            }
                
            string majorNetwork = this.majorNetwork;
            //this.hostsEachSubnet = this.hostsEachSubnet.OrderByDescending(x => x).ToList();
            
            foreach (var hosts in this.hostsEachSubnet)
            {
                Subnet network = new Subnet(hosts.numberOfHosts, hosts.Name, majorNetwork);
                this.networks.Add(network);
                majorNetwork = network.getNextNetwork() + "/" + network.getPrefix().ToString();
            }

            while(true)
            {
                this.subnetCreated = Convert.ToInt32(Math.Pow(2, this.power));
                if (this.needed <= this.subnetCreated)
                    break;
                this.power++;
            }
        }
    }
}
