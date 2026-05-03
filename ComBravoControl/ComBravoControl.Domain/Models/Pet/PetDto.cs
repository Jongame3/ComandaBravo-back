using ComBravo.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.Domains.Models.Pet
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HealthProblems { get; set; }
        public PetType Type {  get; set; }
    }
}
