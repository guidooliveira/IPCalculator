using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCalculator
{
    public class Subnet
    {
        private int power = 0;
        private int neededSize;
        private int prefix = 32;
        private int allocatedSize = 0;
        private string SubnetName;
        private int netWorkMultiplie = 1;
        private string majorNetwork = "";
        private int majorNetworkPrefix = 0;
        private int[] ipOctets;
        private int octetIndex;

        public Subnet(int neededSize, string SubnetName ,string majorNetwork)
        {
            this.neededSize = neededSize;
            this.majorNetwork = majorNetwork;
            this.SubnetName = SubnetName;
            this.doMath();
        }

        public int getNeededSize() => this.neededSize;
        
        public string getSubnetName() => this.SubnetName;
        
        public int getAllocatedSize() => this.allocatedSize;

        public int getPrefix() => this.prefix;

        public int getNetworkMultiple() => this.netWorkMultiplie;

        public int getMask() => 256 - this.getNetworkMultiple();

        public string getSubnetMask()
        {
            if (this.getPrefix() < 9)
                return this.getMask().ToString() + ".0.0.0";

            if (this.getPrefix() < 17)
                return "255." + this.getMask().ToString() + ".0.0";

            if (this.getPrefix() < 25)
                return "255.255." + this.getMask().ToString() + ".0";

            return "255.255.255." + this.getMask().ToString();
        }

        public bool isValidMajorNetwork()
        {
            string[] ip = this.majorNetwork.Split('/');

            if (!(ip.Length == 2))
                return false;

            try
            {
                this.ipOctets = this.ipToInt(ip[0]);
            }
            catch (Exception)
            {
                return false;
            }
            this.majorNetworkPrefix = System.Convert.ToInt32(ip[1]);

            if (!(this.ipOctets.Length == 4))
                return false;

            foreach (int octet in this.ipOctets)
            {
                if (!(octet >= 0 && octet <= 255))
                    return false;
            }
            return true;
        }

        public string getSubnet()
        {
            if (!this.isValidMajorNetwork())
                return "";

            string[] ip = this.ipOctets.Select(x => x.ToString()).ToArray();

            if (this.majorNetworkPrefix > 0 && this.majorNetworkPrefix <= 8)
                return this.ipOctets[0].ToString() + ".0.0.0";

            if (this.majorNetworkPrefix <= 16)
                return String.Join(".", ip, 0, 2) + ".0.0";

            if (this.majorNetworkPrefix <= 24)
                return String.Join(".", ip, 0, 3) + ".0";

            return String.Join(".", ip, 0, 4);
        }

        public string getNextNetwork()
        {
            string[] network = this.getSubnet().Split('.');

            if (this.getPrefix() > 0 && this.getPrefix() <= 8)
                this.octetIndex = 0;

            if (this.getPrefix() > 8 && this.getPrefix() <= 16)
                this.octetIndex = 1;

            if (this.getPrefix() > 16 && this.getPrefix() <= 24)
                this.octetIndex = 2;

            if (this.getPrefix() > 24)
                this.octetIndex = 3;

            network[this.octetIndex] = (Convert.ToInt32(network[this.octetIndex]) + this.netWorkMultiplie).ToString();
            return String.Join(".", network, 0, 4);
        }

        public string getBroadcast()
        {
            int[] broadcast = this.ipToInt(this.getNextNetwork());
            broadcast[this.octetIndex]--;

            if (this.octetIndex > 0 && this.octetIndex < 3)
            {
                for (int i = this.octetIndex + 1; i <= 3; i++)
                {
                    if (broadcast[i] == 0)
                        broadcast[i] = 255;
                    else
                        broadcast[i]--;
                }
            }

            return String.Join(".", broadcast);
        }

        public string getFirstIP()
        {
            int[] ip = this.ipToInt(this.getSubnet());
            ip[3]++;
            return String.Join(".", ip);
        }

        public string getLastIP()
        {
            int[] ip = this.ipToInt(this.getBroadcast());
            ip[3]--;
            return String.Join(".", ip);
        }

        public int getMajorNetworkPrefix() => this.majorNetworkPrefix;

        private void doMath()
        {
            if (this.neededSize < 2)
                return;

            if (!this.isValidMajorNetwork())
                return;

            while (true)
            {
                this.allocatedSize = Convert.ToInt32(Math.Pow(2, power));
                if (this.neededSize <= this.allocatedSize - 2)
                    break;
                this.power++;
                this.prefix--;
                this.netWorkMultiplie = this.netWorkMultiplie * 2;
                if (this.netWorkMultiplie > 128)
                    this.netWorkMultiplie = 1;
            }
        }

        private int[] ipToInt(string ip)
        {
            return Array.ConvertAll<string, int>(
                ip.Split('.'),
                int.Parse
            );
        }
    }
}
