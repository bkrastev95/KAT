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
                    Description = "���������� �� ��������� � �� 20 ��/� � � ����� ��������� �� �������� �����",
                    Name = "���������� �� ��������� � �� 20 ��/�",
                    Note = "���� �� ���!"
                },
                new Violation
                {
                    Description = "���������� �� ��� ��� �������� ������������� �����",
                    Name = "��� �����",
                    Note = "���� �� ���!"
                },
                new Violation
                {
                    Description = "���������� �� ��������� � 50 ��/� � ������ � � ����� ��������� �� �������� �����",
                    Name = "���������� �� ��������� � 50 ��/� � ������",
                    Note = "���� �� ���!"
                },
                new Violation
                {
                    Description = "����������� ��� ������ ������ �� ���������",
                    Name = "����������� ��� ������ ������ �� ���������",
                    Note = "���� �� ���!"
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
                new Brand { Name = "�����" },
                new Brand { Name = "����" },
                new Brand { Name = "������" });
        }

        private void AddOrUpdateModels(KatDataContext context)
        {
            context.Models.AddOrUpdate(
                m => m.Name,
                new Model
                {
                    Brand = new Brand { Name = "�����" },
                    Name = "��������"
                },
                new Model
                {
                    Brand = new Brand { Name = "�����" },
                    Name = "911"
                },
                new Model
                {
                    Brand = new Brand { Name = "����" },
                    Name = "�4"
                },
                new Model
                {
                    Brand = new Brand { Name = "������" },
                    Name = "458"
                },
                new Model
                {
                    Brand = new Brand { Name = "������" },
                    Name = "250 GTO"
                });
        }

        private void AddOrUpdateCameras(KatDataContext context)
        {
            context.Cameras.AddOrUpdate(
                c => c.Location,
                new Camera
                {
                    Location = "���������� ������ 95 ��"
                },
                new Camera
                {
                    Location = "�����, ���. '����������� ����'"
                },
                new Camera
                {
                    Location = "�����, ���. '��������'"
                },
                new Camera
                {
                    Location = "������, ��. '������� �����'"
                },
                new Camera
                {
                    Location = "������, ���. '����������'"
                });
        }

        #endregion

        private void AddOrUpdatePolicemen(KatDataContext context)
        {
            context.Policem�n.AddOrUpdate(
                p => p.Name,
                new Policeman
                {
                    IsActive = true,
                    Name = "����� ��������",
                    Rank = new Rank { Name = RankEnum.Sergant.ToString() }
                },
                new Policeman
                {
                    IsActive = false,
                    Name = "���� ������",
                    Rank = new Rank { Name = RankEnum.Inspector.ToString() }
                },
                new Policeman
                {
                    IsActive = true,
                    Name = "���� �������",
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
                            Name = "������"
                        },
                        Name = "�� ������"
                    },
                    RegNumber = "��8888��",
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
                            Name = "�����"
                        },
                        Name = "�����"
                    },
                    RegNumber = "�6666��",
                    Type = new CarType { Name = CarTypeEnum.Hatchbag.ToString() }
                },
                new Car
                {
                    Model = new Model
                    {
                        Brand = new Brand
                        {
                            Name = "����"
                        },
                        Name = "A7"
                    },
                    RegNumber = "�7777��",
                    Type = new CarType { Name = CarTypeEnum.Coupe.ToString() }
                },
                new Car
                {
                    Model = new Model
                    {
                        Brand = new Brand
                        {
                            Name = "����"
                        },
                        Name = "�5"
                    },
                    RegNumber = "��4575��",
                    Type = new CarType { Name = CarTypeEnum.Coupe.ToString() }
                });
        }

        private void AdddOrUpdateDrivers(KatDataContext context)
        {
            context.Drivers.AddOrUpdate(
                d => d.Egn,
                new Driver
                {
                    FirstName = "������",
                    SecondName = "��������",
                    LastName = "������",
                    Egn = "8812091493",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Model = new Model
                            {
                                Brand = new Brand
                                {
                                    Name = "������"
                                },
                                Name = "�� ������"
                            },
                            RegNumber = "��8888��",
                            Type = new CarType
                            {
                                Name = CarTypeEnum.Sedan.ToString()
                            }
                        }
                    }
                },
                new Driver
                {
                    FirstName = "�����",
                    SecondName = "�����",
                    LastName = "��������",
                    Egn = "9012029334",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Model = new Model
                            {
                                Brand = new Brand
                                {
                                    Name = "�����"
                                },
                                Name = "�����"
                            },
                            RegNumber = "�6666��",
                            Type = new CarType { Name = CarTypeEnum.Hatchbag.ToString() }
                        },
                        new Car
                        {
                            Model = new Model
                            {
                                Brand = new Brand
                                {
                                    Name = "����"
                                },
                                Name = "A7"
                            },
                            RegNumber = "�7777��",
                            Type = new CarType { Name = CarTypeEnum.Coupe.ToString() }
                        }
                    }
                },
                new Driver
                {
                    FirstName = "������",
                    SecondName = "��������",
                    LastName = "������",
                    Egn = "7804231943",
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Model = new Model
                            {
                                Brand = new Brand
                                {
                                    Name = "����"
                                },
                                Name = "�5"
                            },
                            RegNumber = "��4575��",
                            Type = new CarType { Name = CarTypeEnum.Coupe.ToString() }
                        }
                    }
                });
        }
    }
}
