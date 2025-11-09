using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabbitFlow.Utilities
{
    public interface IReceiveNavigationParameter
    {
        void ReceiveParameter(object parameter);
    }
}
