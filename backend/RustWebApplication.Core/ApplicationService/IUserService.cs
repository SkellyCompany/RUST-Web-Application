using System;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService
{
    public interface IUserService
    {
        User ValidateUser(LoginInputModel loginInput);
    }
}
