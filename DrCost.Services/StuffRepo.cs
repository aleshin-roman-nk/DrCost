using DrCost.Models.Stuff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Services
{
    public class StuffRepo : RepoBase
    {
        public StuffRepo(IAppDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<StuffItem> GetItems(int budgetid, DateTime d)
        {
            var dt1 = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
            var dt2 = dt1.AddDays(1);

            using (var db = dbFactory.Create())
            {
                return db.StuffItems.Where(x => x.budgetId == budgetid && dt1 <= x.Date && x.Date < dt2).ToArray();
            }
        }

        public StuffItem? Get(int id)
        {
            using (var db = dbFactory.Create())
            {
                return db.StuffItems.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Save(StuffItem s)
        {
            using (var db = dbFactory.Create())
            {
                db.Entry(s).State = s.Id == 0 ? EntityState.Added : EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(StuffItem o)
        {
            using (var db = dbFactory.Create())
            {
                db.Entry(o).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
