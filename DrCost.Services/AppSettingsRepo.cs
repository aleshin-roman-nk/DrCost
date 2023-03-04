using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Services
{
    public class AppSettingsRepo: RepoBase
    {

        public AppSettingsRepo(IAppDbFactory dbFactory): base(dbFactory)
        {
        }

        public int GetInt(string name)
        {
            using (var db = dbFactory.Create())
            {
                var p = db.AppSettingValues.FirstOrDefault(x => x.name.Equals(name));
                return int.Parse(p.value);
            }
        }

        public decimal GetDecimal(string name)
        {
            using (var db = dbFactory.Create())
            {
                var p = db.AppSettingValues.FirstOrDefault(x => x.name.Equals(name));
                if(p == null)
                    return 0;
                return decimal.Parse(p.value);
            }
        }

        public string GetString(string name)
        {
            using (var db = dbFactory.Create())
            {
                var p = db.AppSettingValues.FirstOrDefault(x => x.name.Equals(name));
                if(p == null)
                    return string.Empty;
                return p.value;
            }
        }

        public void Set(string name, string value)
        {
            using (var db = dbFactory.Create())
            {
                var p = db.AppSettingValues.FirstOrDefault(x => x.name.Equals(name));

                if (p == null)
                {
                    db.AppSettingValues.Add(new Models.AppSettingValue { name = name, value = value });
                    db.SaveChanges();
                    return;
                }

                p.value = value;
                db.SaveChanges();
            }
        }
    }
}
