using ComBravo.BusinessLogic.Interface;
using ComBravo.BusinessLogic.Functions.Auth;
using ComBravo.BusinessLogic.Functions.User;
using ComBravo.BusinessLogic.Functions.Product;
using ComBravo.BusinessLogic.Functions.Pet;
using ComBravo.BusinessLogic.Functions.Appointment;


namespace ComBravo.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }
        public IUserActions GetUserActions() 
        {
            return new UserFlow();    
        }

        public IProductActions GetProductActions() 
        {
            return new ProductFlow();
        }

        public IPetActions GetPetActions()
        {
            return new PetFlow();
        }

        public IAppointmentActions GetAppointmentActions() 
        {
            return new AppointmentFlow();
        }
    }
}
