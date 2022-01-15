using System;
using System.Collections.Generic;

namespace articles_app.Models
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();

        UserModel Add(UserModel user);
    }
}
