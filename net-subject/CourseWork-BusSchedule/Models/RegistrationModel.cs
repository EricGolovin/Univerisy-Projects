using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork_BusSchedule.Services;

namespace CourseWork_BusSchedule.Models
{
    class RegistrationModel : BaseModel
    {
        private string name = "";
        private string password = "";
        public override void Load()
        {

        }

        public void SetName(string newName)
        {
            name = newName;
        }

        public void SetPassword(string newPassword)
        {
            password = newPassword;
        }

        public bool ValidateUser()
        {
            return CredentialsManagerService.shared.ValidateUser(name, password);
        }
    }
}
