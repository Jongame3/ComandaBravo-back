using ComBravo.DataAccess.Context;
using ComBravo.Domains.Entities.Appointment;
using ComBravo.Domains.Models.Appointment;
using ComBravo.Domains.Models.Base;

namespace ComBravo.BusinessLogic.Core.Appointment
{
    public class AppointmentActions
    {
        protected List<AppointmentDto> ExecuteGetAllAppointmentsAction()
        {
            var returnList = new List<AppointmentDto>();
            List<AppointmentData> aData;

            using ( var db = new AppointmentContext())
            {
                aData = db.Appointments.ToList();
            }

            foreach ( var item in aData)
            {
                var localdto = new AppointmentDto()
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    ProductInfo = item.ProductInfo,
                    StartTime = item.StartTime,
                    Date = item.Date,
                    Duration = item.Duration,
                    PetInfo = item.PetInfo
                };

                returnList.Add(localdto);
            }
            return returnList;
        }
        protected AppointmentDto ExecuteGetAppointmentByIdAction(int id) 
        {
            AppointmentData appointmentData;

            using (var db = new AppointmentContext()) 
            {
                appointmentData = db.Appointments.FirstOrDefault(x => x.Id == id);
            }

            if (appointmentData == null) 
            {
                return null;
            }

            return new AppointmentDto()
            {
                Id = appointmentData.Id,
                UserId = appointmentData.UserId,
                StartTime = appointmentData.StartTime,
                ProductInfo = appointmentData.ProductInfo,
                Duration = appointmentData.Duration,
                Date = appointmentData.Date,
                PetInfo= appointmentData.PetInfo
                
            };
        }
        protected ResponseAction ExecuteCreateAppointmentAction(AppointmentDto appointment)
        {
            AppointmentData aData; 
            using (var db = new AppointmentContext()) 
            {
                aData = db.Appointments.FirstOrDefault(x => x.Id == appointment.Id && x.UserId == appointment.UserId);
            }
            if (aData != null)
            {
                return new ResponseAction() { IsSucces = false, Id = 0, Message = "Same appointment already exists" };
            }
            var alocalData = new AppointmentData()
            {
                Id = appointment.Id,
                UserId = appointment.UserId,
                ProductInfo = appointment.ProductInfo,
                StartTime = appointment.StartTime,
                Date = appointment.Date,
                PetInfo = appointment.PetInfo,
                Duration = appointment.Duration
            };

            using (var db = new AppointmentContext()) 
            {
                db.Add(alocalData);
                db.SaveChanges();
            }
            return new ResponseAction() { IsSucces = true, Id = alocalData.Id, Message = "Apointment succesfully created" };
        }
        protected ResponseMsg ExecuteUpdateAppointmentAction(AppointmentDto appointment)
        {
            using (var db = new AppointmentContext())
            {
                var aData = db.Appointments.FirstOrDefault(x => x.Id == appointment.Id && x.UserId == appointment.UserId );

                if (aData == null)
                {
                    return new ResponseMsg() { IsSucces = false, Message = "There's no such appointment, or this appointment is already approved" };
                }

                aData.Id = appointment.Id;
                aData.UserId = appointment.UserId;
                aData.ProductInfo = appointment.ProductInfo;
                aData.StartTime = appointment.StartTime;
                aData.Duration = appointment.Duration;
                aData.PetInfo = appointment.PetInfo;
                aData.Date = appointment.Date;

                db.SaveChanges();
            }
            return new ResponseMsg() { IsSucces = true, Message = "Appointment succesfully updated" };
        }
        protected ResponseMsg ExecuteDeleteAppointmentAction(int id)
        {
            using (var db = new AppointmentContext()) 
            {
                var aData = db.Appointments.FirstOrDefault(x => x.Id == id);

                if(aData == null)
                {
                    return new ResponseMsg() { IsSucces = false, Message = "There's no appointment with this Id" };
                }

                db.Remove(aData);
                db.SaveChanges();
            }
            return new ResponseMsg() { IsSucces = true, Message = "Appointment succhesfully deleted" };
        }
    }   
}
