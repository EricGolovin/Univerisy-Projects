using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Networking.Shared
{
    interface NetworkRequest<out T>
    {
        T Get(string request);
        void Add(string request);
    }
}
