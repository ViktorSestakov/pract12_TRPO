using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_TRPO
{
    public class BaseDbService
    {
        private static BaseDbService instance;
        private AppDbContext context;   

        private BaseDbService()
        {
            context = new AppDbContext();
        }

        public static BaseDbService Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaseDbService();
                return instance;
            }
        }

        public AppDbContext Context => context;
    }
}
