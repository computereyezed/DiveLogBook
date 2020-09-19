using DiveLogBook.Shared.Models.DiveInfo;
using DiveLogBook.Shared.Models.DiverInfo;
using DiveLogBook.Shared.Models.DiveSites;
using DiveLogBook.Shared.Models.Images;
using DiveLogBook.Shared.Models.PADIDiveCharts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiveLogBook.Server.Data
{
    public class DiveCtx : DbContext
    {
        public DiveCtx(DbContextOptions<DiveCtx> options) : base(options)
        {
        }

        //Divelog
        public DbSet<Dives> Dives { get; set; }
        public DbSet<DiveDropdownData> DDD { get; set; }

        // DiverInfo
        public DbSet<DiverInformation> DiverInformation { get; set; }
        public DbSet<Certifications> Certifications { get; set; }

        //Dive Locations
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Countries> Countries { get; set; }

        //Images
        public DbSet<Pictures> Pictures { get; set; }

        //PADIDiveCharts
        public DbSet<I_NoDecompressionLimitsAndGroupDesignation> I_NoDecompressionLimitsAndGroupDesignation { get; set; }
        public DbSet<I_RepetitiveDiveTimetable> I_RepetitiveDiveTimetable { get; set; }
        public DbSet<M_NoDecompressionLimitsAndGroupDesignation> M_NoDecompressionLimitsAndGroupDesignation { get; set; }
        public DbSet<M_RepetitiveDiveTimetable> M_RepetitiveDiveTimetable { get; set; }
        public DbSet<SurfaceIntervalCredit> SurfaceIntervalCredit { get; set; }
    }
}
