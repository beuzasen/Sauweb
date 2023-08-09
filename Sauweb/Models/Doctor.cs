using System.ComponentModel.DataAnnotations;

namespace SauWeb.Models
{
    public class Doctor
    {
        [Key]
        public int DoktorId { get; set; }
        [Required(ErrorMessage ="Boş Geçmeyiniz")]
        
        public string DoctorName { get; set; }

        public string Polikliniks { get; set; }
        public string HospitalName { get; set; }
        
        public ICollection<Appoinment> Appoinments { get; set; }






    }
}
