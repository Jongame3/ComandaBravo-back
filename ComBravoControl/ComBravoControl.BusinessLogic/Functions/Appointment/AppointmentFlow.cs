using ComBravo.BusinessLogic.Core.Appointment;
using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Appointment;
using ComBravo.Domains.Models.Base;

namespace ComBravo.BusinessLogic.Functions.Appointment
{
    public class AppointmentFlow : AppointmentActions, IAppointmentActions
    {
        public List<AppointmentDto> GetAllAppointmentsAction()
        {
            return ExecuteGetAllAppointmentsAction();
        }
        public AppointmentDto GetAppointmentByIdAction(int id)
        {
            return ExecuteGetAppointmentByIdAction(id);
        }
        public ResponseAction CreateAppointmentAction(AppointmentDto appointment)
        {
            return ExecuteCreateAppointmentAction(appointment);
        }
        public ResponseMsg DeleteAppointmentAction(int id)
        {
            return ExecuteDeleteAppointmentAction(id);
        }
        public ResponseMsg UpdateAppointmentAction(AppointmentDto appointment)
        {
            return ExecuteUpdateAppointmentAction(appointment);
        }
    }
}
