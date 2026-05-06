using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ComBravo.Domains.Entities.Product;

namespace ComBravo.Domains.Entities.Appointment
{
    public class AppointmentData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ProductInfo { get; set; }
        [Required]
        public int StartTime { get; set; }
        [Required]
        public DateOnly Date {  get; set; }
        [Required]
        public string PetInfo { get; set; }
        [Required]
        public int Duration { get; set; }
    }
}
