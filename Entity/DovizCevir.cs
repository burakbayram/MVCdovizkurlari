using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DovizCevir
    {
        [Key]
        public int Id { get; set; }
        public double Total { get; set; }
        public string dovizCinsi { get; set; }
        public double ParaMiktari { get; set; }
        public double Kur { get; set; }
        public DateTime date { get; set; }
        public DovizCevir()
        {
            date = DateTime.Now;
        }
    }
}
