using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication39.Models
{
    public class Calisan
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Çalışan Adı Boş Geçilemez.")]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Çalışan Şifresi Boş Geçilemez.")]
        public string Sifre { get; set; }

        public string Image { get; set; }
        [Display(Name = "Maaş")]
        public string MaasId { get; set; }
        public Maas Maas { get; set; }
    }
}
