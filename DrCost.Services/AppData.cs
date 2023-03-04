using DrCost.Models;
using DrCost.Models.Stuff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Services
{
    public class AppData: DbContext
	{
		string? _path = null;

		public AppData(string fname): base()
		{
			_path = fname;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite($"Filename={_path}");

			//optionsBuilder.LogTo(Console.WriteLine);
			//optionsBuilder.EnableSensitiveDataLogging(true);
		}

		public DbSet<Budget> Budgets { get; set; }
		public DbSet<AppSettingValue> AppSettingValues { get; set; }
		public DbSet<StuffItem> StuffItems { get; set; }
		public DbSet<MonthlyBudgetProperty> MonthlyBudgetProperties { get; set; }
		public DbSet<AddedMoney> AddedMoneys { get; set; }
		public DbSet<KindOfTag> KindOfTags { get; set; }
	}
}
