using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Networking.Shared
{
    class GetRequestConsts
    {
        public static string getCustomerByIdRequest = "SELECT * FROM MANUFACTURER WHERE IN_FIRM LIKE {0};";
        public static string getFabricByIdRequest = "SELECT * FROM FABRIC WHERE IN_FABRIC LIKE {0};";
        public static string getModelByIdRequest = "SELECT * FROM MODEL WHERE IN_MODEL LIKE {0};";
        public static string getClientByIdRequest = "SELECT * FROM CLIENT WHERE IN_CLINET LIKE {0};";
        public static string getCutterByIdRequest = "SELECT * FROM CUTTER WHERE IN_CUTTER LIKE {0};";
        public static string getBookingByIdRequest = "SELECT * FROM BOOKING WHERE IN_BOOKING LIKE {0};";
    }
}
