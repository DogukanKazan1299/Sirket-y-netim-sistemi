using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication39.Models
{
    public class Hakkımızda
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Metin Kısmı Boş Geçilemez.")]
        public string Hakkimizda { get; set; }
    }
}
