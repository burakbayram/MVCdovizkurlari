using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RateContext:DbContext
    {
        public RateContext():base("ExchangeContext")
        {

        }

        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<ExchangeRateData> ExchangeRateDatas { get; set; }
        public virtual DbSet<DovizCevir> DovizCevirs { get; set; }

    }
}
