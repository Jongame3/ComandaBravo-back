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

            if (aData == null)
            {
                return null;
            }

            foreach ( var item in aData)
            {
                var localdto = new AppointmentDto()
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    Username = item.Username,
                    ProductInfo = item.ProductInfo,
                    StartTime = item.StartTime,
                    Date = item.Date,
                    Duration = item.Duration,
                    PetInfo = item.PetInfo,
                    PetType = item.PetType,
                    IsApproved = item.IsApproved
                    
                };

                returnList.Add(localdto);
            }
            return returnList;
        }

        protected List<int> ExecuteGetEmptyHoursByDateAction(DateOnly date)
        {
            var BusyHours = new List<int>();
            var EmptyHours = new List<int>();
            List<AppointmentData> aData;

            using (var db = new AppointmentContext())
            {
                aData = db.Appointments.ToList().FindAll(x=> x.Date == date);
            }

            foreach(var e in aData)
            {
                for(int i = 0; i<e.Duration; i++)
                {
                    BusyHours.Add(e.StartTime + i);
                }
            }

            for(int i = 9; i < 19 ;i++)
            {
                if (BusyHours.Find(x => x == i) == default(int))
                {
                    EmptyHours.Add(i);
                }
            }

            return EmptyHours;
        }
        protected List<AppointmentDto> ExecuteGetAllAppointmentsByUserIdAction(int uId)
        {
            var returnList = new List<AppointmentDto>();
            List<AppointmentData> aData;

            using (var db = new AppointmentContext())
            {
                aData = db.Appointments.ToList().FindAll(x=> x.UserId == uId);
            }

            if (aData == null)
            {
                return null;
            }

            foreach (var item in aData)
            {
                var localdto = new AppointmentDto()
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    Username = item.Username,
                    ProductInfo = item.ProductInfo,
                    StartTime = item.StartTime,
                    Date = item.Date,
                    Duration = item.Duration,
                    PetInfo = item.PetInfo,
                    PetType = item.PetType,
                    IsApproved = item.IsApproved
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
                Username= appointmentData.Username,
                StartTime = appointmentData.StartTime,
                ProductInfo = appointmentData.ProductInfo,
                Duration = appointmentData.Duration,
                Date = appointmentData.Date,
                PetInfo= appointmentData.PetInfo,
                PetType= appointmentData.PetType,
                IsApproved= appointmentData.IsApproved
                
            };
        }

        protected List<AppointmentDto> ExecuteGetAllAppointmentsByDateAction(DateOnly date)
        {
            var returnList = new List<AppointmentDto>();
            List<AppointmentData> aData;

            using (var db = new AppointmentContext())
            {
                aData = db.Appointments.ToList().FindAll(x => x.Date == date);
            }

            if (aData == null)
            {
                return null;
            }

            foreach (var item in aData)
            {
                var localdto = new AppointmentDto()
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    Username = item.Username,
                    ProductInfo = item.ProductInfo,
                    StartTime = item.StartTime,
                    Date = item.Date,
                    Duration = item.Duration,
                    PetInfo = item.PetInfo,
                    PetType = item.PetType,
                    IsApproved= item.IsApproved
                };

                returnList.Add(localdto);
            }
            return returnList;
        }
        protected ResponseAction ExecuteCreateAppointmentAction(AppointmentDto appointment)
        {
            AppointmentData? aData; 
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
                Username= appointment.Username,
                ProductInfo = appointment.ProductInfo,
                StartTime = appointment.StartTime,
                Date = appointment.Date,
                PetInfo = appointment.PetInfo,
                Duration = appointment.Duration,
                PetType = appointment.PetType,
                IsApproved = false
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
                aData.Username = appointment.Username;
                aData.ProductInfo = appointment.ProductInfo;
                aData.StartTime = appointment.StartTime;
                aData.Duration = appointment.Duration;
                aData.PetInfo = appointment.PetInfo;
                aData.PetType  = appointment.PetType;
                aData.Date = appointment.Date;
                aData.IsApproved = appointment.IsApproved;

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

        protected ResponseMsg ExecuteApproveAppointmentAction(int id)
        {
            using (var db = new AppointmentContext()) 
            {
                var aData = db.Appointments.FirstOrDefault(x => x.Id == id);
                if (aData == null)
                {
                    return new ResponseMsg() { IsSucces = false, Message = "there's no appointment with this id" };
                }

                aData.IsApproved = true;
                db.SaveChanges();
            }
            return new ResponseMsg() { IsSucces = true, Message = "Appointment approved" };
            
        }
    }   
}
