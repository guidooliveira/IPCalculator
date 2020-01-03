using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;


namespace IPCalculator
{
    [Cmdlet(VerbsCommon.New, "Network")]
    [OutputType(typeof(IReadOnlyCollection<Subnet>))]
    public class NewNetwork : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Type in the Segment Name", Position = 1)]
        public NetworkSegment[] NetworkSegments { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Type in the Address Space in CIDR notation", Position = 2)]
        [ValidatePattern("^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])(\\/([0-9]|[1-2][0-9]|3[0-2]))$")]
        public string AddressSpace { get; set; }
        
        protected override void ProcessRecord()
        {
            var Segments = NetworkSegments.ToList<NetworkSegment>();
            AddressSpace Subnets = new AddressSpace(Segments, AddressSpace);
            
            foreach (Subnet subnet in Subnets.getNetworks())
            {
                WriteObject(new
                {
                    Name = subnet.getSubnetName(),
                    Subnet = $"{subnet.getSubnet()}/{subnet.getPrefix().ToString()}",
                    FirstIp = subnet.getFirstIP(),
                    LastIP = subnet.getLastIP(),
                    Broadcast = subnet.getBroadcast(),
                    NeededSize = subnet.getNeededSize(),
                    AllocatedSize = subnet.getAllocatedSize()
                });
            }

        }
    }
}
