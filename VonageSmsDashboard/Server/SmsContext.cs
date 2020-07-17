using Microsoft.EntityFrameworkCore;
using Nexmo.Api.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VonageSmsDashboard.Shared;

namespace VonageSmsDashboard.Server
{
    public class SmsContext : DbContext
    {
        public DbSet<InboundSmsModel> InboundSms { get; set; }

        public DbSet<DeliveryReceiptModel> Dlrs { get; set; }

        public DbSet<OutboundSms> OutboundSms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=VonageSms.db");
    }
}
