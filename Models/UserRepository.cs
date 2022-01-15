using System;
using System.Collections.Generic;

namespace articles_app.Models
{
    public class UserRepository: IUserRepository
    {
        private List<UserModel> users = new List<UserModel>();
        private int _nextId = 1;

        public UserRepository()
        {
            Add(new UserModel { username = "Ryan" });
            Add(new UserModel { username = "Alma" });
            Add(new UserModel { username = "Francis" });
            Add(new UserModel { username = "Enigma" });
        }

        public UserModel Add(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.Id = _nextId++;
            users.Add(user);
            return user;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return users;
        }
    }
}
