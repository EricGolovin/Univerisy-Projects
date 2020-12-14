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

        public void sendUser(string name, string surname, string parentName, string email, string phoneNumber)
        {
            Networking.Independent.ClientNetworkProxy.Add($"{name} {surname} {parentName}", phoneNumber, email);
        }
    }
}
