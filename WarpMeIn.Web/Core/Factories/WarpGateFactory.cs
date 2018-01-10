using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarpMeIn.Models;
using WarpMeIn.Models.Contracts;
using WarpMeIn.Web.Core.Providers;

namespace WarpMeIn.Web.Core.Factories
{
    public class WarpGateFactory
    {
        private IdProvider idProvider;

        public WarpGateFactory(IdProvider provider)
        {
            this.idProvider = provider;
        }

        public WarpGate Create(string url)
        {
            KeyValuePair<long, string> idAndKeyword = this.idProvider.GenerateValidIdAndKeyWord();

            WarpGate warpGate = new WarpGate(idAndKeyword.Key, idAndKeyword.Value, url);

            return warpGate;
        }
    }
}
