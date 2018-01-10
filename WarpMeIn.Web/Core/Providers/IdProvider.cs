using System.Collections.Generic;
using System.Linq;
using WarpMeIn.Data;
using WarpMeIn.Web.Core.Utils.Contracts;

namespace WarpMeIn.Web.Core.Providers
{
    public class IdProvider
    {
        private IGenerator stringGenerator;
        private IBaseConverter baseConverter;
        private WarpMeInDBContext dbContext;

        public IdProvider(IGenerator generator, IBaseConverter converter, WarpMeInDBContext dbContext)
        {
            this.stringGenerator = generator;
            this.baseConverter = converter;
            this.dbContext = dbContext;
        }

        public KeyValuePair<long, string> GenerateValidIdAndKeyWord()
        {
            long id = -1;
            string keyword = string.Empty;

            while (true)
            {
                keyword = this.stringGenerator.Generate(5);
                id = this.baseConverter.FromBase(keyword);

                if (IdIsValid(id))
                {
                    break;
                }
            }

            return new KeyValuePair<long, string>(id, keyword);
        }

        private bool IdIsValid(long id)
        {
            return !this.dbContext.WarpGates.Any(w => w.Id == id);
        }
    }
}