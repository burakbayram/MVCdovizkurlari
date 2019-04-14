using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class ExchangeRateData
    {
        [Key]
        public int Id { get; set; }
        public int? CrossOrder { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public double Buying { get; set; }
        public double Selling { get; set; }
        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public DateTime CreatedDate { get; set; }
      
    }
}
