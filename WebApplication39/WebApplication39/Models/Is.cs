using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication39.Models
{
    public class Is
    {

        public string Id { get; set; }
        [Required(ErrorMessage = "Metin Kısmı Boş Geçilemez.")]
        public string UrunAdi { get; set; }
        public int SatisToplam { get; set; }
        [Required(ErrorMessage = "Metin Kısmı Boş Geçilemez.")]
        public int Ucret { get; set; }
    }
}
