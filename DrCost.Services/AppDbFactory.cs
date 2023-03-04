using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Services
{
    public class AppDbFactory: IAppDbFactory
    {
        private readonly string dbpath;

        public AppDbFactory(IAppSystemProperties sysprops) 
        {
            dbpath = sysprops.DbPath;
        }
        public AppData Create()
        {
            return new AppData(dbpath);
        }
    }
}
