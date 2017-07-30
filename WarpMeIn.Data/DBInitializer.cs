using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpMeIn.Data
{
    public static class DBInitializer
    {
        public static void Initialize(WarpMeInDBContext context)
        {
            context.Database.EnsureCreated();

            //Seed Data here
        }
    }
}
