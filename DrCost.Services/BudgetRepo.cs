using DrCost.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace DrCost.Services
{
	public class BudgetRepo: RepoBase
    {
		public BudgetRepo(IAppDbFactory dbFactory): base(dbFactory) { }

		public IEnumerable<Budget> GetBudgets()
		{
			using (var db = dbFactory.Create())
			{
				return db.Budgets.ToArray();
			}
		}

		public Budget? GetBudget(int id)
		{
            using (var db = dbFactory.Create())
			{
				return db.Budgets.FirstOrDefault(x => x.Id == id);
			}

        }

		public void Save(Budget b)
		{
			using (var db = dbFactory.Create())
			{
				db.Entry(b).State = b.Id == 0 ? EntityState.Added : EntityState.Modified;
				db.SaveChanges();
			}
		}

		public void Delete(Budget b)
		{
            using (var db = dbFactory.Create())
			{
				db.Entry(b).State = EntityState.Deleted;
				db.SaveChanges();
			}
        }

		//public void Create(Budget b)
		//{
		//	using (var db = dbFactory.Create())
		//	{
		//		db.Budgets.Add(b);
		//		db.SaveChanges();
		//	}
		//}

		//public void Update(Budget b)
		//{
		//	using (var db = dbFactory.Create())
		//	{
		//		db.Budgets.Attach(b);
		//		db.SaveChanges();
		//	}
		//}
	}
}
