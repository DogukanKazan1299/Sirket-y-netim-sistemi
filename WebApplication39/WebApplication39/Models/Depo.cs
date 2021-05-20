using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication39.Models
{
    public class Depo
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Ürün Adı Boş Geçilemez.")]
        public string UrunAdi { get; set; }
        public string DepoNo { get; set; }
        public string DepoAdres { get; set; }

    }
}
