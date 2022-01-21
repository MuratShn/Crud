using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.Models
{
    public class Bolum
    {
        [Key]
        public int Id { get; set; }
        public string BolumAd { get; set; }

        public List<Ogrenci> Ogrenciler { get; set; }
    }
}
