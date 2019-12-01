using System;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.DomainService
{
    public interface IUserRepository
    {
        User Read(string username);
    }
}
