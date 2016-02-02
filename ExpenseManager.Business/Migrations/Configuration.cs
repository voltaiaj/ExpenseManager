using System.Data.Entity.Migrations;
using ExpenseManager.Models;

namespace ExpenseManager.Business.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ExpenseManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpenseManagerDbContext context)
        {
            context.Tiers.AddOrUpdate(t => t.Name, new Tier
            {
                Id = (int) Tiers.MonthToMonth,
                Name = "Month-to-Month"
            }, new Tier
            {
                Id = (int) Tiers.Food,
                Name = "Food"
            }, new Tier
            {
                Id = (int) Tiers.UniqueExpenses,
                Name = "Unique Expenses"
            });

            context.Categories.AddOrUpdate(c => c.Name, 
                new Category
                {
                    Id = 1,
                    Name = "Gym",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category
                {
                    Id = 2,
                    Name = "Mortgage",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category
                {
                    Id = 3,
                    Name = "Car Insurance",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 4,
                    Name = "Satellite TV",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 5,
                    Name = "Cellphone",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 6,
                    Name = "Internet",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 7,
                    Name = "Spotify",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 8,
                    Name = "Gas for Home",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 9,
                    Name = "Electricity",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 10,
                    Name = "Water",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 11,
                    Name = "Home Security",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 12,
                    Name = "IdentityGuard",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 13,
                    Name = "Landscaping",
                    TierId = (int) Tiers.MonthToMonth
                },
                new Category()
                {
                    Id = 14,
                    Name = "Fast Food",
                    TierId = (int) Tiers.Food
                },
                new Category()
                {
                    Id = 15,
                    Name = "Groceries",
                    TierId = (int) Tiers.Food
                },
                new Category()
                {
                    Id = 16,
                    Name = "Entertainment",
                    TierId = (int) Tiers.UniqueExpenses
                },
                new Category()
                {
                    Id = 17,
                    Name = "Services",
                    TierId = (int) Tiers.UniqueExpenses
                },
                new Category()
                {
                    Id = 18,
                    Name = "Annual Renewals",
                    TierId = (int) Tiers.UniqueExpenses
                });

            context.TrainingSets.AddOrUpdate(t => t.CategoryId,
                //MonthToMonth
                new TrainingSet
                {
                    CategoryId = (int) Categories.Gym,
                    Keywords = "Lifetime"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.Mortgage,
                    Keywords = "Chase Mortgage"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.CarInsurance,
                    Keywords = "Progressive Auto"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.SatelliteTv,
                    Keywords = "DirectTV"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.CellPhone,
                    Keywords = "AT&T"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.Internet,
                    Keywords = "Comcast Xfinity"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.Spotify,
                    Keywords = "Spotify Paypal"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.GasForHome,
                    Keywords = "Centerpoint"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.Electricity,
                    Keywords = "Name of Electricy Company"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.Water,
                    Keywords = "HUD City"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.HomeSecurity,
                    Keywords = "ADT"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.IdentityGuard,
                    Keywords = "IdentityGuard"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.Landscaping,
                    Keywords = "Check"
                },
                //Food
                new TrainingSet
                {
                    CategoryId = (int) Categories.Groceries,
                    Keywords = "HEB"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.FastFood,
                    Keywords = "Chipotle Papa John's Subway KFC"
                },
                //Unique Expenses
                new TrainingSet
                {
                    CategoryId = (int) Categories.Entertainment,
                    Keywords = "Names of places I go"
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.Services,
                    Keywords = " "
                },
                new TrainingSet
                {
                    CategoryId = (int) Categories.AnnualRenewals,
                    Keywords = " "
                }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}