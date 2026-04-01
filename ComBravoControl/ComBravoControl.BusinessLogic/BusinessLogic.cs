using ComBravoControl.BusinessLogic.Interface;
using ComBravoControl.BusinessLogic.Functions.Auth;


namespace ComBravoControl.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }
    }
}
