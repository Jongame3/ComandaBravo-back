using ComBravoControl.BusinessLogic.Interface;
using ComBravoControl.BusinessLogic.Functions.Auth;
using ComBravoControl.BusinessLogic.Functions.User;
using ComBravoControl.BusinessLogic.Functions.Product;


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

        public IProductActions GetProductActions() 
        {
            return new ProductFlow();
        }
    }
}
