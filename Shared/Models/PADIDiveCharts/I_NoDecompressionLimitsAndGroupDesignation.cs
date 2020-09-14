using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLogBook.Shared.Models.PADIDiveCharts
{
    public class I_NoDecompressionLimitsAndGroupDesignation
    {
        public int BottemTimeID { get; set; }
        public Nullable<int> Depth { get; set; }
        public Nullable<int> Time { get; set; }
        public string PressureGroup { get; set; }
        public bool SafetyStopReq { get; set; }
        public bool NoDecompresstionLimit { get; set; }
    }
}
