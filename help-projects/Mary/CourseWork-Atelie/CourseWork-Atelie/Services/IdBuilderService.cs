using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Services
{
    class IdBuilderService
    {
        public static int GetRandomId()
        {
            int uniqueId = Guid.NewGuid().GetHashCode();
            if (uniqueId < 0) { uniqueId = -uniqueId; }
            return uniqueId;
        }
    }
}
