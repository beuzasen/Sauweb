using System.ComponentModel.DataAnnotations;

namespace SauWeb.Models
{
    public class Appoinment
    {
        [Key]
        public int AppomentId { get; set; } 

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }  

        public string Day { get; set; }

        public string Time { get; set; }

        [Display(Name ="Randevuyu almak için tıklayınız")]
        public string Full { get; set; } 





    }
}

