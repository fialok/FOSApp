using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOSApp.Abstractions
{
    public interface IProcessor
    {
        List<string> FilterData(List<string> inputList);
    }
}
