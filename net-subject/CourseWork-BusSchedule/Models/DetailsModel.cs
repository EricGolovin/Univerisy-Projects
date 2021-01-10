using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_BusSchedule.Models
{
    class DetailsModel : BaseModel
    {
        private Networking.Models.CredentialsInfo credentialsInfo;
        public DetailsModel(Networking.Models.CredentialsInfo credentialsInfo)
        {
            this.credentialsInfo = credentialsInfo;
        }

        public override void Load()
        {

        }
    }
}
