using ComBravo.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.Domains.Models.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string ProductInfo { get; set; }
        public int StartTime { get; set; }
        public DateOnly Date {  get; set; }
        public string PetInfo { get; set; }
        public PetType PetType { get; set; }
        public int Duration { get; set; }
        public bool IsApproved { get; set; }
    }
}
