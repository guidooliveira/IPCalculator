using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace IPCalculator
{
    [Cmdlet(VerbsCommon.New, "NetworkSegment")]
    [OutputType(typeof(IReadOnlyCollection<NetworkSegment>))]
    public class NewNetworkSegment : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Type in the Segment Name", Position = 1)]
        public string Name { get; set; }
        [Parameter(Mandatory = true, HelpMessage = "Type in the Amount of hosts needed in the segment", Position = 2)]
        public int SizeNeeded { get; set; }

        protected override void ProcessRecord()
        {
            NetworkSegment Segment = new NetworkSegment(Name, SizeNeeded);
            
            WriteObject(Segment);
        }
    }
}
