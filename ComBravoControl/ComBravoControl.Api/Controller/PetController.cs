using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Pet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComBravo.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetController : ControllerBase
    {
        private IPetActions _pet;

        public PetController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _pet = bl.GetPetActions();
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var pets = _pet.GetAllPetsAction();
            return Ok(pets);
        }
        [HttpGet("By Id")]
        public IActionResult GetById(int id)
        {
            var pet = _pet.GetPetByIdAction(id);
            return Ok(pet);
        }
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int userId)
        {
            var pets = _pet.GetAllPetsByUserIdAction(userId);
            return Ok(pets);
        }
        [HttpPut]
        public IActionResult Update (PetDto pet)
        {
            var status = _pet.ResponsePetUpdateAction(pet);
            return Ok(status);
        }
        [HttpPost]
        public IActionResult Create ( PetDto pet)
        {
            var status = _pet.ResponsePetCreateAction(pet);
            return Ok(status);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var status = _pet.ResponsePetDeleteAction(id);
            return Ok(status);
        }
    }
}
