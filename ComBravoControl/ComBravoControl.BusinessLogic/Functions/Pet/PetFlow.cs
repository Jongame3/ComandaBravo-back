using ComBravo.BusinessLogic.Core.Pet;
using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.Pet;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.BusinessLogic.Functions.Pet
{
    public class PetFlow : PetActions, IPetActions
    {
        public List<PetDto> GetAllPetsAction()
        {
            return ExecuteGetAllPetsAction();
        }

        public PetDto GetPetByIdAction(int id)
        {
            return ExecuteGetPetById(id);
        }

        public ResponseAction ResponsePetCreateAction(PetDto pet)
        {
            return ExecutePetCreateAction(pet);
        }

        public ResponseMsg ResponsePetDeleteAction(int id)
        {
            return ExecuteDeletePetAction(id);
        }

        public ResponseMsg ResponsePetUpdateAction(PetDto pet)
        {
            return ExecuteUpdatePetAction(pet);
        }
    }
}
