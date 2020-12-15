using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    class UserRegistratioModel : BaseModel
    {
        public UserRegistratioModel() { }

        public void load() { } 

        public Networking.Independent.Client sendUser(string name, string surname, string parentName, string email, string phoneNumber)
        {
            string userFullName = $"{name} {surname} {parentName}";
            return Networking.Independent.ClientNetworkProxy.Add(userFullName, phoneNumber, email);
        }
    }
}
