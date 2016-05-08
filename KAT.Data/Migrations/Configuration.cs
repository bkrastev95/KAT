using System.Collections.Generic;
using KAT.Data.CodeFirstModels;
using KAT.Data.CodeFirstModels.Nomenclatures;
using KAT.Data.KAT.Context;

namespace KAT.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<KatDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(KatDataContext context)
        {
            //// Independant
            //AddOrUpdateViolations(context);
            //AddOrUpdateCarTypes(context);
            //AddOrUpdateDocumentTypes(context);
            //AddOrUpdateBrands(context);
            //AddOrUpdateRanks(context);
            //AddOrUpdateCameras(context);
            //context.SaveChanges();

            ////Dependant
            //AddOrUpdateModels(context);
            //AddOrUpdatePolicemen(context);
            //AddOrUpdateCars(context);
            //context.SaveChanges();

            //// Dependant
            //AdddOrUpdateDrivers(context);
        }

        #region Nomenclatures

        private void AddOrUpdateRanks(KatDataContext context)
        {
            context.Ranks.AddOrUpdate(
                r => r.Name,
                new Rank { Name = RankEnum.Sergant.ToString() },
                new Rank { Name = RankEnum.Inspector.ToString() },
                new Rank { Name = RankEnum.Officer.ToString() });
        }

        private void AddOrUpdateViolations(KatDataContext context)
        {
            context.Violations.AddOrUpdate(
                v => v.Name,
                new Violation
                {
                    Description = "Превишение на скоростта с до 20 км/ч в и извън границите на населено място",
                    Name = "Превишение на скоростта с до 20 км/ч",
                    Note = "Пише се фиш!"
                },
                new Violation
                {
                    Description = "Управление на МПС без поставен предпазителен колан",
                    Name = "Без колан",
                    Note = "Пише се фиш!"
                },
                new Violation
                {
                    Description = "Превишение на скоростта с 50 км/ч и нагоре в и извън границите на населено място",
                    Name = "Превишение на скоростта с 50 км/ч и нагоре",
                    Note = "Пише се акт!"
                },
                new Violation
                {
                    Description = "Преминаване при червен сигнал на светофара",
                    Name = "Преминаване при червен сигнал на светофара",
                    Note = "Пише се акт!"
                }
                );
        }

        private void AddOrUpdateCarTypes(KatDataContext context)
        {
            context.CarTypes.AddOrUpdate(
                ct => ct.Name,
                new CarType
                {
                    Name = CarTypeEnum.Cabriolet.ToString()
                },
                new CarType
                {
                    Name = CarTypeEnum.SmallBus.ToString()
                });
        }

        private void AddOrUpdateDocumentTypes(KatDataContext context)
        {
            context.DocumentTypes.AddOrUpdate(
                dt => dt.Name,
                new DocumentType
                {
                    Name = DocumentTypeEnum.Ticket.ToString()
                },
                new DocumentType
                {
                    Name = DocumentTypeEnum.Act.ToString()
                },
                new DocumentType
                {
                    Name = DocumentTypeEnum.ElectronicTicket.ToString()
                });
        }

        private void AddOrUpdateBrands(KatDataContext context)
        {
            context.Brands.AddOrUpdate(
                b => b.Name,
                new Brand { Name = "Порше" },
                new Brand { Name = "Ауди" },
                new Brand { Name = "Ферари" });
        }

        private void AddOrUpdateModels(KatDataContext context)
        {
            context.Models.AddOrUpdate(
                m => m.Name,
                new Model
                {
                    Brand = new Brand { Name = "Порше" },
                    Name = "Панамера"
                },
                new Model
                {
                    Brand = new Brand { Name = "Порше" },
                    Name = "911"
                },
                new Model
                {
                    Brand = new Brand { Name = "Ауди" },
                    Name = "А4"
                },
                new Model
                {
                    Brand = new Brand { Name = "Ферари" },
                    Name = "458"
                },
                new Model
                {
                    Brand = new Brand { Name = "Ферари" },
                    Name = "250 GTO"
                });
        }

        private void AddOrUpdateCameras(KatDataContext context)
        {
            context.Cameras.AddOrUpdate(
                c => c.Location,
                new Camera
                {
                    Location = "Магистрала Тракия 95 км"
                },
                new Camera
                {
                    Location = "София, бул. 'Цариградско шосе'"
                },
                new Camera
                {
                    Location = "София, бул. 'България'"
                },
                new Camera
                {
                    Location = "Бургас, ул. 'Димитър Димов'"
                },
                new Camera
                {
                    Location = "Бургас, бул. 'Демокрация'"
                });
        }

        #endregion

        private void AddOrUpdatePolicemen(KatDataContext context)
        {
            context.Policemеn.AddOrUpdate(
                p => p.Name,
                new Policeman
                {
                    IsActive = true,
                    Name = "Тодор Стефанов",
                    Rank = new Rank { Name = RankEnum.Sergant.ToString() }
                },
                new Policeman
                {
                    IsActive = false,
                    Name = "Иван Петров",
                    Rank = new Rank { Name = RankEnum.Inspector.ToString() }
                },
                new Policeman
                {
                    IsActive = true,
                    Name = "Илия Маринов",
                    Rank = new Rank { Name = RankEnum.Officer.ToString() }
                });
        }

        private void AddOrUpdateCars(KatDataContext context)
        {
            context.Cars.AddOrUpdate(
                c => c.RegNumber,
                new Car
                {
                    Model = new Model
                    {
                        Brand = new Brand
                        {
                            Name = "Ферари"
                        },
                        Name = "Ла ферари"
                    },
                    RegNumber = "СА8888АС",
                    Type = new CarType
                    {
                        Name = CarTypeEnum.Sedan.ToString()
                    }
                },
                new Car
                {
                    Model = new Model
                    {
                        Brand = new Brand
                        {
                            Name = "Порше"
                        },
                        Name = "Кайен"
                    },
                    RegNumber = "А6666ЕР",
                    Type = new CarType { Name = CarTypeEnum.Hatchbag.ToString() }
                },
                new Car
                {
                    Model = new Model
                    {
                        Brand = new Brand
                        {
                            Name = "Ауди"
                        },
                        Name = "A7"
                    },
                    RegNumber = "А7777ЕР",
                    Type = new CarType { Name = CarTypeEnum.Coupe.ToString() }
                },
                new Car
                {
                    Model = new Model
                    {
                        Brand = new Brand
                        {
                            Name = "Ауди"
                        },
                        Name = "А5"
                    },
                    RegNumber = "СО4575ЕР",
                    Type = new CarType { Name = CarTypeEnum.Coupe.ToString() }
                });
        }

        private void AdddOrUpdateDrivers(KatDataContext context)
        {
            context.Drivers.AddOrUpdate(
                d => d.Egn,
                new Driver
                {
                    FirstName = "Христо",
                    SecondName = "Георгиев",
                    LastName = "Петров",
                    Egn = "8812091493",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Model = new Model
                            {
                                Brand = new Brand
                                {
                                    Name = "Ферари"
                                },
                                Name = "Ла ферари"
                            },
                            RegNumber = "СА8888АС",
                            Type = new CarType
                            {
                                Name = CarTypeEnum.Sedan.ToString()
                            }
                        }
                    }
                },
                new Driver
                {
                    FirstName = "Петър",
                    SecondName = "Илиев",
                    LastName = "Захариев",
                    Egn = "9012029334",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Model = new Model
                            {
                                Brand = new Brand
                                {
                                    Name = "Порше"
                                },
                                Name = "Кайен"
                            },
                            RegNumber = "А6666ЕР",
                            Type = new CarType { Name = CarTypeEnum.Hatchbag.ToString() }
                        },
                        new Car
                        {
                            Model = new Model
                            {
                                Brand = new Brand
                                {
                                    Name = "Ауди"
                                },
                                Name = "A7"
                            },
                            RegNumber = "А7777ЕР",
                            Type = new CarType { Name = CarTypeEnum.Coupe.ToString() }
                        }
                    }
                },
                new Driver
                {
                    FirstName = "Евгени",
                    SecondName = "Теодоров",
                    LastName = "Иванов",
                    Egn = "7804231943",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Model = new Model
                            {
                                Brand = new Brand
                                {
                                    Name = "Ауди"
                                },
                                Name = "А5"
                            },
                            RegNumber = "СО4575ЕР",
                            Type = new CarType { Name = CarTypeEnum.Coupe.ToString() }
                        }
                    }
                });
        }
    }
}
