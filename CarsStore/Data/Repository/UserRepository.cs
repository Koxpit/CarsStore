using CarsStore.Interfaces;
using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Data.Repository
{
    public class UserRepository : IAllUsers
    {
        private readonly CarsStoreContext context;
        public UserRepository(CarsStoreContext context)
        {
            this.context = context;
        }

        public void AddUser(UserInfo user)
        {
            user.IsLoginUser = true;
            context.User.Add(user);
            context.SaveChanges();
        }

        public bool LogAccess(UserInfo user)
        {
            foreach (var _user in context.User)
                if (_user.Login == user.Login && _user.Password == user.Password)
                    return true;
            return false;
        }
    }
}
