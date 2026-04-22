using ComBravo.BusinessLogic.Interface;
using ComBravo.BusinessLogic.Functions.Auth;
using ComBravo.BusinessLogic.Functions.User;
using ComBravo.BusinessLogic.Functions.Product;


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
    }
}
