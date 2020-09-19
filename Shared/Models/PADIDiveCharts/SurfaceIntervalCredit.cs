using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLogBook.Shared.Models.PADIDiveCharts
{
    public class SurfaceIntervalCredit
    {
        public int Id { get; set; }
        public string StartingPressureGroup { get; set; }
        public Nullable<int> SurfaceInterval { get; set; }
        public string NewPressureGroup { get; set; }
    }
}
