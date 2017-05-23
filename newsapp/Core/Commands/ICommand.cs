using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newsapp.Core.Commands
{
    public interface ICommand
    {
        void execute();
    }
}
