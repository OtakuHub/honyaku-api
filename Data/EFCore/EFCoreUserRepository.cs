using honyaku_api.Models;

namespace honyaku_api.Data.EFCore
{
    public class EFCoreUserRepository : EFCoreRepository<User, honyakuapiContext>
    {
        public EFCoreUserRepository(honyakuapiContext context) : base(context)
        {
        }
    }
}