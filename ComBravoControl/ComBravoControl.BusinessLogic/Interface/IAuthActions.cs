using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.User;

namespace ComBravo.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        AuthResponse LoginActionFlow(UserAuthDto auth);

    }
}
