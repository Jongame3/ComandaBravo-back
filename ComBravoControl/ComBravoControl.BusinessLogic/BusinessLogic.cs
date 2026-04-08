using ComBravoControl.BusinessLogic.Interface;
using ComBravoControl.BusinessLogic.Functions.Auth;
using ComBravoControl.BusinessLogic.Functions.User;


namespace ComBravoControl.BusinessLogic
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
        
    }
}
