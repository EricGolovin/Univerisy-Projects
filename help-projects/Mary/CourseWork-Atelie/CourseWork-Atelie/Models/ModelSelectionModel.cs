using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    class ModelSelectionModel : BaseModel
    {
        private List<Networking.Independent.Model> items = new List<Networking.Independent.Model>();
        public ModelSelectionModel() { }

        public void load() {
            this.items = Networking.Independent.ModelNetworkProxy.GetAll();
            foreach(Networking.Independent.Model model in items)
            {
                Console.WriteLine("---------------");
                Console.WriteLine($"{model.id}");
                Console.WriteLine($"{model.name}");
                Console.WriteLine($"{model.consumption}");
                Console.WriteLine($"{model.price}");
                Console.WriteLine($"{model.price}");
                Console.WriteLine($"{model.photoLink}");
                Console.WriteLine("---------------");
            }
        }

        public List<string> getNames()
        {
            List<string> resultList = new List<string>();
            foreach(Networking.Independent.Model model in items)
            {
                resultList.Add(model.name);
            }
            return resultList;
        }

        public string getImageUrlFor(string name)
        {
            foreach (Networking.Independent.Model model in items)
            {
                if (model.name == name)
                {
                    return model.photoLink;
                }
            }
            return "";
        }
    }
}
