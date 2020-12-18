using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace CourseWork_Atelie.Models
{
    using Networking.Independent;
    using Networking.SingleDependable;
    using Networking.MultipleDependable;

    partial class GetInfoModel : BaseModel
    {
        private string selectedType = "";
        private Fabric selectedFabric;
        private List<Fabric> allFabrics = new List<Fabric>();
        private bool isFabricSelected = false;
        public void load() {
            allFabrics = FabricNetworkProxy.GetAll();
        }

        public List<string> GetAllTypes()
        {
            return ModelType.allTypes;
        }

        public List<string> GetAllFormattedFabricIds()
        {
            List<string> resultList = new List<string>();
            foreach(Fabric fabric in allFabrics)
            {
                resultList.Add(fabric.id.ToString());
            }
            return resultList;
        }

        public void SetSelectedFitting(string id)
        {
            int selectedId = Convert.ToInt32(id);
            foreach (Fabric fabric in allFabrics)
            {
                if (fabric.id == selectedId)
                {
                    isFabricSelected = true;
                    selectedFabric = fabric;
                    break;
                }
            }
        }

        public string UpdateFabric(string newValue)
        {
            try
            {
                int newNumeralValue = Convert.ToInt32(newValue.RemoveWhitespace());
                FabricNetworkProxy.UpdateLengthValueById(selectedFabric.id, newNumeralValue);
                return "";
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return $"{exception.Message}";
            }
        }

        public string GetFormattedInfo()
        {
            string resultString = "";
            switch (selectedType)
            {
                case string booking when booking == ModelType.booking:
                    foreach(Booking item in BookingNetworkProxy.GetAll())
                    {
                        resultString += $"{Consts.lineBraker}\n";
                        resultString += $"{item.GetDescription()}\n";
                        resultString += $"{Consts.lineBraker}\n";
                    }
                    break;
                case string client when client == ModelType.client:
                    foreach (Client item in ClientNetworkProxy.GetAll())
                    {
                        resultString += $"{Consts.lineBraker}\n";
                        resultString += $"{item.GetDescription()}\n";
                        resultString += $"{Consts.lineBraker}\n";
                    }
                    break;
                case string cutter when cutter == ModelType.cutter:
                    foreach (Cutter item in CutterNetworkProxy.GetAll())
                    {
                        resultString += $"{Consts.lineBraker}\n";
                        resultString += $"{item.GetDescription()}\n";
                        resultString += $"{Consts.lineBraker}\n";
                    }
                    break;
                case string model when model == ModelType.model:
                    foreach (Model item in ModelNetworkProxy.GetAll())
                    {
                        resultString += $"{Consts.lineBraker}\n";
                        resultString += $"{item.GetDescription()}\n";
                        resultString += $"{Consts.lineBraker}\n";
                    }
                    break;
                case string fabric when fabric == ModelType.fabric:
                    foreach (Fabric item in FabricNetworkProxy.GetAll())
                    {
                        resultString += $"{Consts.lineBraker}\n";
                        resultString += $"{item.GetDescription()}\n";
                        resultString += $"{Consts.lineBraker}\n";
                    }
                    break;
                case string manufacturer when manufacturer == ModelType.manufacturer:
                    foreach (Manufacturer item in ManufacturerNetworkProxy.GetAll())
                    {
                        resultString += $"{Consts.lineBraker}\n";
                        resultString += $"{item.GetDescription()}\n";
                        resultString += $"{Consts.lineBraker}\n";
                    }
                    break;
                case string fitting when fitting == ModelType.fitting:
                    foreach (Fitting item in FittingNetworkProxy.GetAll())
                    {
                        resultString += $"{Consts.lineBraker}\n";
                        resultString += $"{item.GetDescription()}\n";
                        resultString += $"{Consts.lineBraker}\n";
                    }
                    break;
            }
            return resultString;
        }

        public void SetSelectedType(string type)
        {
            selectedType = type;
        }

        public bool IsFabricSelected()
        {
            return selectedType == ModelType.fabric;
        }

        public bool IsTypeSelected()
        {
            return selectedType != "";
        }
    }

    partial class GetInfoModel
    {
        struct Consts
        {
            public static string lineBraker = "----------------------";
        }
    }

    struct ModelType
    {
        public static string booking = "Booking";
        public static string client = "Client";
        public static string cutter = "Cutter";
        public static string model = "Model";
        public static string fabric = "Fabric";
        public static string manufacturer = "Manufacturer";
        public static string fitting = "Fitting";
        public static List<string> allTypes = new List<string>() { booking, client, cutter, model, fabric, manufacturer, fitting };
    }
}
