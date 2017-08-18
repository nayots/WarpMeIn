using System.Collections.Generic;
using WarpMeIn.Core.Utils.Contracts;
using WarpMeIn.Data;
using System.Linq;

namespace WarpMeIn.Core.Providers
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
