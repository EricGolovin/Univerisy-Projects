using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    class AuthorizationFormModel : BaseModel
    { 
        private Services.AuthorizationService authorization = new Services.AuthorizationService();
        public AuthorizationFormModel() { }

        public void load()
        {

        }

        public bool UsernameExists(string username)
        {
            return authorization.UserExists(username);
        }

        public bool ValidateUser(string password)
        {
            return authorization.ValidatePassword(password);
        }

        public Services.AccessType GetUserLevel()
        {
            return authorization.GetUserAccessType();
        }
    }
}
