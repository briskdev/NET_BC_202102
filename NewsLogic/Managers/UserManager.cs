using NewsLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsLogic.Managers
{
    public class UserManager
    {
        //3. Create UserManager with method Register(string username, string email, string password) :

        public void Register(string username, string email, string password)
        {
            using (var db = new NewsDb())
            {
                //3.1. Check if there isn't a user with the same username already
                var existingUser = db.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
                if(existingUser != null)
                {
                    throw new LogicException("That username is already in use!");
                }
                //3.2. Check if there isn't a user with the same e-mail already
                existingUser = db.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
                if(existingUser != null)
                {
                    throw new LogicException("That e-mail is already in use!");
                }
                //3.3. (Optional) Check if password is at least 6 symbols
                if(!password.IsPasswordOk())
                {
                    throw new LogicException("Password should be at least 6 symbols!");
                }

                //3.4. Add user if all OK
                db.Users.Add(new Users()
                {
                    Email = email,
                    Password = password,
                    Username = username,
                });
                db.SaveChanges();
            }
        }

        public Users GetUser(string username, string password)
        {
            using(var db = new NewsDb())
            {
                return db.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower() && u.Password == password);
            }
        }
    }
}
