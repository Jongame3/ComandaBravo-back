using ComBravo.DataAccess.Context;
using ComBravo.Domains.Entities.Pet;
using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.Pet;

namespace ComBravo.BusinessLogic.Core.Pet
{
    public class PetActions
    {
        protected List<PetDto> ExecuteGetAllPetsAction()
        {
            var pets = new List<PetDto>();
            List<PetData> petData;

            using( var db = new PetContext())
            {
                petData = db.Pets.ToList();
            }
            foreach (var pet in petData)
            {
                var pet_ = new PetDto
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    HealthProblems = pet.HealthProblems,
                    Type = pet.Type,
                    UserID = pet.UserID
                };
                pets.Add(pet_);
            }
            return pets;
        }


        protected List<PetDto> ExecuteGetPetByUserIdAction(int uId)
        {
            List<PetData> pets;
            var returnpets = new List<PetDto>();
            using (var db = new PetContext())
            {
                pets = db.Pets.ToList().FindAll(x => x.UserID == uId);
            }
            if (pets == null)
            {
                return null;
            }

            foreach (var pet in pets)
            {
                var pet_ = new PetDto
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    HealthProblems = pet.HealthProblems,
                    Type = pet.Type,
                    UserID = pet.UserID
                };
                returnpets.Add(pet_);
            }
            return returnpets;

        }

        protected PetDto ExecuteGetPetById(int id)
        {
            PetData? pet;
            using (var db = new PetContext()) 
            {
                pet = db.Pets.FirstOrDefault(p => p.Id == id);
            }
            if (pet == null)
            {
                return null;
            }
            return new PetDto()
            {
                Id = pet.Id,
                Name = pet.Name,
                HealthProblems = pet.HealthProblems,
                Type = pet.Type,
                UserID = pet.UserID
            }; 
        }

        protected ResponseAction ExecutePetCreateAction(PetDto pet)
        {
            PetData? pData;
            using (var db = new PetContext()) 
            {
                pData = db.Pets.FirstOrDefault(x => x.Name.Equals(pet.Name) && x.Type == pet.Type && x.UserID == pet.UserID);
            }
            if (pData != null)
            {
                return new ResponseAction() { IsSucces =  false , Id = 0, Message = "Same pet already exists in our system"};
            }
            var pLocalData = new PetData()
            {
                Id = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                HealthProblems = pet.HealthProblems,
                UserID = pet.UserID
            }; 

            using (var db  = new PetContext())
            {
                db.Pets.Add(pLocalData);
                db.SaveChanges();
            }
            return new ResponseAction() { IsSucces = true, Id = pet.Id, Message = "Pet was succesfully added" };
        }

        protected ResponseMsg ExecuteUpdatePetAction(PetDto pet)
        {
            using (var db = new PetContext()) 
            {
                var pData = db.Pets.FirstOrDefault(x => x.Id == pet.Id);
                if (pData == null)
                {
                    return new ResponseMsg() { IsSucces = false, Message = "There's no such pet in system" };
                }

                pData.Name = pet.Name;
                pData.HealthProblems = pet.HealthProblems;
                pData.Type = pet.Type;
                pData.UserID = pet.UserID;

                db.SaveChanges();
            }
            return new ResponseMsg() { IsSucces = true, Message = "Pet succesfully updated" };
        }

        protected ResponseMsg ExecuteDeletePetAction(int id)
        {
            using (var db = new PetContext())
            {
                var pData = db.Pets.FirstOrDefault(x => x.Id == id);
                if (pData == null)
                {
                    return new ResponseMsg() { IsSucces = false, Message = "There's no such pet in our system" };
                }
                db.Remove(pData);
                db.SaveChanges();
            }
            return new ResponseMsg() {IsSucces = true, Message = "Pet was succesfully deleted" };
        }

    }
}
