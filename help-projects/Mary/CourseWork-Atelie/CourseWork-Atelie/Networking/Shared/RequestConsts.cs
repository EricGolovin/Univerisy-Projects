using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Networking.Shared
{
    class RequestConsts
    {
        public class Get
        {
            public static string getManufacturerByIdRequest = "SELECT * FROM MANUFACTURER WHERE IN_FIRM LIKE {0};";
            public static string getClientByIdRequest = "SELECT * FROM CLIENT WHERE IN_CLINET LIKE {0};";
            public static string getCutterByIdRequest = "SELECT * FROM CUTTER WHERE IN_CUTTER LIKE {0};";
            public static string getBookingByIdRequest = "SELECT * FROM BOOKING WHERE IN_BOOKING LIKE {0};";

            public class Model
            {
                public static string getByIdRequest = "SELECT * FROM MODEL WHERE IN_MODEL LIKE {0};";
                public static string getAllRequest = "SELECT * FROM MODEL";
            }

            public class Fabric
            {
                public static string getByIdRequest = "SELECT * FROM FABRIC WHERE IN_FABRIC LIKE {0};";
                public static string getAllRequest = "SELECT * FROM FABRIC";
            }

            public class Recommendation
            {
                public static string getRecommendationByIdsRequest = "SELECT *  FROM RECOMENDATION WHERE IN_MODEL LIKE {0} AND IN_FABRIC LIKE {1};";
                public static string getAllRequest = "SELECT *  FROM RECOMENDATION";
            }
        }
        public class Put
        {
            public class Independent
            {
                public static string putClientRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO CLIENT(IN_CLIENT, FIO_CLIENT, PHONE, EMAIL) values({0}, '{1}', '{2}','{3}');";
                public static string putCutterRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO CUTTER(IN_CUTTER, FIO_CUTTER, SALARY, NUMBER_OF_ORDERS) values (,'NAME',,);";
                public static string putManufacturerRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO MANUFACTURER(IN_FABRIC, NAME_FIRM, COUNTRY) values ({0},'{1}','{2}');";
                public static string putModelRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO MODEL(IN_MODEL, NAME_MODEL, CONSUMPTION, PRICE_MODEL, PHOTO_MODEL) values (,'NAME',,,'');";
            }

            public class Dependable
            {
                public static string putFabricRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO FABRIC(IN_FABRIC, NAME_FABRIC, LENGTH_FABRIC, PRICE_FABRIC, IN_FIRM, PHOTO_FABRIC) values ({0}, '{1}', {2}, {3}, {4}, '{5}');";
                public static string putRecomendationRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO RECOMENDATION(IN_MODEL, IN_FABRIC) values({0}, {1});";
                public static string putBookingRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO BOOKING(RECEPTION_DATE, ISSUE_DATE, MARK, SUM_BOOKING, IN_CUTTER, IN_CLIENT, IN_MODEL, IN_FABRIC) values ('',,'',,,,,);";
            }
        }
    }
}
