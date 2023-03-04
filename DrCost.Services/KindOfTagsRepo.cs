using DrCost.Models.Stuff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Services
{
    public class KindOfTagsRepo : RepoBase
    {
        public KindOfTagsRepo(IAppDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void Save(KindOfTag o)
        {
            using(var db = dbFactory.Create())
            {
                db.Entry(o).State = o.Id == 0 ? EntityState.Added : EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<KindOfTag> Get()
        {
            using (var db = dbFactory.Create())
            {
                return db.KindOfTags.ToArray();
            }
        }

        public KindOfTag Get(int id)
        {
            using (var db = dbFactory.Create())
            {
                return db.KindOfTags.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Delete(KindOfTag o) 
        {
            using (var db = dbFactory.Create())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
