using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpMeIn.Web.Core.Utils.Contracts
{
    public interface IGenerator
    {
        string Generate(int length);
    }
}
