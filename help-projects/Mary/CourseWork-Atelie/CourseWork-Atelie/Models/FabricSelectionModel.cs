using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    class FabricSelectionModel : BaseModel
    {
        private List<Networking.SingleDependable.Fabric> items = new List<Networking.SingleDependable.Fabric>();
        private Networking.SingleDependable.Fabric selectedFabric;
        public Networking.Independent.Model selectedModel;
        public FabricSelectionModel() { }

        public void load()
        {
            this.items = Networking.SingleDependable.FabricNetworkProxy.GetAll();
            foreach(Networking.SingleDependable.Fabric fabric in items)
            {
                Console.WriteLine("---------------");
                Console.WriteLine($"{fabric.id}");
                Console.WriteLine($"{fabric.name}");
                Console.WriteLine($"{fabric.length}");
                Console.WriteLine($"{fabric.price}");
                Console.WriteLine($"manufacturer: {fabric.manufacturer.country}");
                Console.WriteLine($"{fabric.photoLink}");
                Console.WriteLine("---------------");
            }
        }

        public List<string> getNames()
        {
            List<string> resultList = new List<string>();
            foreach(Networking.SingleDependable.Fabric fabric in items)
            {
                if (fabric.length >= selectedModel.consumption)
                {
                    resultList.Add(fabric.name);
                }
            }
            return resultList;
        }

        public string getImageUrlFor(string name)
        {
            foreach(Networking.SingleDependable.Fabric fabric in items)
            {
                if (fabric.name == name)
                {
                    selectedFabric = fabric;
                    return fabric.photoLink;
                }
            }
            return "";
        }

        public void sendData()
        {
            Networking.MultipleDependable.RecommendationNetworkProxy.Add(selectedModel, selectedFabric);
        }

        public Networking.MultipleDependable.Recommendation getReccomendation()
        {
            return new Networking.MultipleDependable.Recommendation(selectedModel, selectedFabric);
        }
    }
}
