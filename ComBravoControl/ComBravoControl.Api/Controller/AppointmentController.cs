using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComBravo.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentActions _apointment;

        public AppointmentController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _apointment = bl.GetAppointmentActions();
        }

        [HttpGet("All")]
        [Authorize(Roles = "Vet")]
        public IActionResult GetAll() 
        {
            var result = _apointment.GetAllAppointmentsAction();
            return Ok(result);
        }

        [HttpGet("by Id")]
        [Authorize(Roles = "Vet")]
        public IActionResult GetById(int id) 
        {
            var result = _apointment.GetAppointmentByIdAction(id);
            return Ok(result);
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int userId) 
        {
            var result = _apointment.GetAllAppointmentsByUserIdAction(userId);
            return Ok(result);
        }

        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateOnly date)
        {
            var result = _apointment.GetAllAppointmentsByDateAction(date);
            return Ok(result);
        }
        [HttpGet("GetFreeHours")]
        public IActionResult GetFreeHours(DateOnly date)
        {
            var result = _apointment.GetEmptyHoursByDateAction(date);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(AppointmentDto dto) 
        {
            var status = _apointment.CreateAppointmentAction(dto);
            return Ok(status);
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var status = _apointment.DeleteAppointmentAction(id);
            return Ok(status);
        }

        [HttpPut]
        [Authorize(Roles ="Vet")]
        public IActionResult Update(AppointmentDto dto) 
        {
            var status = _apointment.UpdateAppointmentAction(dto);
            return Ok(status);
        }
    }
}
