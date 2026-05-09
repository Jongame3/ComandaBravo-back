using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.Pet;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.BusinessLogic.Interface
{
    public interface IPetActions
    {
        List<PetDto> GetAllPetsAction();
        List<PetDto> GetAllPetsByUserIdAction(int userId);
        PetDto GetPetByIdAction(int id);
        ResponseAction ResponsePetCreateAction(PetDto pet);
        ResponseMsg ResponsePetUpdateAction (PetDto pet);
        ResponseMsg ResponsePetDeleteAction(int id);
    }
}
