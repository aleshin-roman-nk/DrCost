using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Services
{
    public class RepoBase
    {
        protected readonly IAppDbFactory dbFactory;

        public RepoBase(IAppDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
    }
}
