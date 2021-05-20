using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication39.Models
{
    public class Musteri
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Müşteri Adı Boş Geçilemez.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Müşteri Soyadı Boş Geçilemez.")]
        public string Soyad { get; set; }
        public int Ucret { get; set; }
        public string Adres { get; set; }
    }
}
