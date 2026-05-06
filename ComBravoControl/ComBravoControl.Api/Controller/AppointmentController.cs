using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComBravo.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentActions _apointment;

        public AppointmentController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _apointment = bl.GetAppointmentActions();
        }

        [HttpGet("All")]
        public IActionResult GetAll() 
        {
            var result = _apointment.GetAllAppointmentsAction();
            return Ok(result);
        }

        [HttpGet("by Id")]
        public IActionResult GetById(int id) 
        {
            var result = _apointment.GetAppointmentByIdAction(id);
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
        public IActionResult Put(AppointmentDto dto) 
        {
            var status = _apointment.UpdateAppointmentAction(dto);
            return Ok(status);
        }
    }
}
