using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zezo.Models
{
    public partial class rsc_v2Context : DbContext
    {
        public rsc_v2Context()
        {
        }

        public rsc_v2Context(DbContextOptions<rsc_v2Context> options)
            : base(options)
        {
        }
        public virtual DbSet<Assignement> Assignements { get; set; } = null!;
        public virtual DbSet<ShippingordersStatus> ShippingordersStatuses { get; set; } = null!;

    }
}
