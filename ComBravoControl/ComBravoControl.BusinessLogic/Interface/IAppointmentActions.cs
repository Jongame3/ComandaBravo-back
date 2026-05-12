using ComBravo.Domains.Models.Appointment;
using ComBravo.Domains.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.BusinessLogic.Interface
{
    public interface IAppointmentActions
    {
        List<AppointmentDto> GetAllAppointmentsAction();
        List<AppointmentDto> GetAllAppointmentsByUserIdAction(int uId);
        List<AppointmentDto> GetAllAppointmentsByDateAction(DateOnly date);
        AppointmentDto GetAppointmentByIdAction(int id);
        ResponseAction CreateAppointmentAction(AppointmentDto appointment);
        ResponseMsg UpdateAppointmentAction(AppointmentDto appointment);
        ResponseMsg DeleteAppointmentAction(int id);
        List<int> GetEmptyHoursByDateAction(DateOnly date);
    }
}
