using ComBravo.Domains.Enums;
using ComBravo.Domains.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComBravo.Domains.Entities.Pet
{
    public class PetData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Required, StringLength(20)]
        public string? Name { get; set; }
        public string? HealthProblems { get; set; }
        [Required]
        public PetType Type { get; set; }
        [ForeignKey("UserID")]
        [Required]
        public string? UserID { get; set; }
        [Required]
        public UserData? Owner { get; set; }

    }
}
