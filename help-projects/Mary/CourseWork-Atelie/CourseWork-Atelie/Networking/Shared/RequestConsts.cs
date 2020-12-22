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
            public class Client
            {
                public static string getAllRequest = "SELECT * FROM CLIENT;";
                public static string getByIRequest = "SELECT * FROM CLIENT WHERE IN_CLIENT LIKE {0};";
            }

            public class Manufacturer
            {
                public static string getByIdRequest = "SELECT * FROM MANUFACTURER WHERE IN_FIRM LIKE {0};";
                public static string getAllRequest = "SELECT * FROM MANUFACTURER;";
            }

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
                public static string getByIdsRequest = "SELECT *  FROM RECOMENDATION WHERE IN_MODEL LIKE {0} AND IN_FABRIC LIKE {1};";
                public static string getAllRequest = "SELECT * FROM RECOMENDATION";
            }

            public class Cutter
            {
                public static string getByIdRequest = "SELECT * FROM CUTTER WHERE IN_CUTTER LIKE {0};";
                public static string getAllRequest = "SELECT * FROM CUTTER";
            }

            public class Booking
            {
                public static string getByIdRequest = "SELECT * FROM BOOKING WHERE IN_BOOKING LIKE {0};";
                public static string getAllRequest = "SELECT * FROM BOOKING";
            }

            public class Fitting
            {
                public static string getByIdRequest = "SELECT * FROM FITTING WHERE IN_FITTING LIKE {0};";
                public static string getAllRequest = "SELECT * FROM FITTING";
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
                public static string putBookingRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO BOOKING(RECEPTION_DATE, ISSUE_DATE, MARK, SUM_BOOKING, IN_CUTTER, IN_CLIENT, IN_MODEL, IN_FABRIC) values ('{0}', '{1}', '{2}', {3}, {4}, {5}, {6}, {7});";
                public static string putFittingRequest = "SET IDENTITY_INSERT CLIENT ON INSERT INTO FITTING(IN_BOOKING, IN_FITTING, COMMENT) values ({0}, {1}, '{2}');";
            }
        }

        public class Update
        {
            public class Cutter
            {
                public static string updateNumOfOrdersByIdRequest = "SET IDENTITY_INSERT CLIENT ON UPDATE CUTTER SET NUMBER_OF_ORDERS = {0} WHERE IN_CUTTER = {1};";
            }
            public class Fabric
            {
                public static string updateLenghtByIdRequest = "UPDATE FABRIC SET LENGTH_FABRIC = {0} WHERE IN_FABRIC = {1};";
            }
        }

        public class Delete
        {
            public class Fitting
            {
                public static string deleteByIdRequest = $"DELETE FROM FITTING WHERE IN_FITTING LIKE({0});";
            }
        }

        public static string spasificValueRecvest01 = "SELECT FIO_CUTTER, case when NUMBER_OF_ORDERS >=5 then 'Cannot accept order' when NUMBER_OF_ORDERS >=4 then 'Free for one order' when NUMBER_OF_ORDERS >=1 then 'Ready to take order' 50 else 'Free' end as OPPORTUNITY from CUTTER;";
        public static string spasificValueRecvest02 = "SELECT MANUFACTURER.NAME_FIRM,COUNT(FABRIC.IN_FIRM) FROM MANUFACTURER INNER JOIN FABRIC ON MANUFACTURER.IN_FIRM = FABRIC.IN_FIRM GROUP BY MANUFACTURER.NAME_FIRM ORDER BY COUNT(FABRIC.IN_FIRM) DESC;";
        public static string spasificValueRecvest03 = "SELECT FABRIC.NAME_FABRIC,COUNT(RECOMENDATION.IN_FABRIC) FROM FABRIC INNER JOIN RECOMENDATION ON FABRIC.IN_FABRIC = RECOMENDATION.IN_FABRIC GROUP BY FABRIC.NAME_FABRIC ORDER BY COUNT(RECOMENDATION.IN_FABRIC) DESC;";
        public static string spasificValueRecvest04 = "SELECT MODEL.NAME_MODEL,COUNT(RECOMENDATION.IN_MODEL) FROM MODEL INNER JOIN RECOMENDATION ON MODEL.IN_MODEL = RECOMENDATION.IN_MODEL GROUP BY MODEL.NAME_MODEL  ORDER BY COUNT(RECOMENDATION.IN_MODEL) DESC;";
        public static string spasificValueRecvest05 = "SELECT FIO_CLIENT,(SELECT COUNT(IN_CLIENT) FROM BOOKING WHERE CLIENT.IN_CLIENT = BOOKING.IN_CLIENT) FROM CLIENT;";
        public static string spasificValueRecvest06 = "SELECT FIO_CUTTER,NUMBER_OF_ORDERS FROM CUTTER ORDER BY NUMBER_OF_ORDERS DESC;";
        public static string spasificValueRecvest07 = $"SELECT COUNT(IN_BOOKING) FROM BOOKING WHERE RECEPTION_DATE BETWEEN {0} AND {1} ;";
        public static string spasificValueRecvest08 = $"SELECT COUNT(SUM_BOOKING) FROM BOOKING WHERE RECEPTION_DATE BETWEEN {0} AND {1} ;";
    }
}
