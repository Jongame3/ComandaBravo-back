using ComBravo.Domains.Enums;

namespace ComBravo.Domains.Models.Pet
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HealthProblems { get; set; }
        public int UserID { get; set; }
        public PetType Type {  get; set; }
    }
}
