namespace Moccacito.Migrations
{
    using Moccacito.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Moccacito.Models.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Moccacito.Models.ModelContext context)
        {
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

            context.Clients.AddOrUpdate(
                c => c.Id,
                new Client
                {
                    Name = "Lenovo",
                    City = "Warszawa",
                    Email = "kontakt@lenovo.pl",
                    NIP = "3947236472",
                    Street = "Daszyñskiego 20",
                    Telephone = "+48788123994",
                    Zipcode = "00-343"
                },
                new Client
                {
                    Name = "HP",
                    City = "Warszawa",
                    Email = "kontakt@hp.pl",
                    NIP = "9245551250",
                    Street = "Górnicza 9",
                    Telephone = "+48660231743",
                    Zipcode = "00-312"
                },
                new Client
                {
                    Name = "Samsung",
                    City = "Warszawa",
                    Email = "marek.watrobski@samsung.pl",
                    NIP = "2541770513",
                    Street = "S³oneczna 98",
                    Telephone = "+48789313553",
                    Zipcode = "00-002"
                },
                new Client
                {
                    Name = "Apple Inc",
                    City = "Warszawa",
                    Email = "kevin.culado@apple.com",
                    NIP = "9412305382",
                    Street = "Jab³kowa 21",
                    Telephone = "+48508233948",
                    Zipcode = "00-886"
                }
                );

            context.Locations.AddOrUpdate(
                l => l.Id,
                new Location
                {
                    Name = "Media Markt, CH Trzy Stawy",
                    City = "Katowice",
                    Zipcode = "40-289",
                    Street = "Genera³a Kazimierza Pu³askiego 60",
                    Email = "zbigniew.holdys@312-mm.com",
                    Telephone = "+48509213590",
                    TelephoneAlt = "+48669210531",
                    ContactName = "Zbigniew",
                    ContactSurname = "Ho³dys"
                },
                new Location
                {
                    Name = "Media Markt, CH M1",
                    City = "Zabrze",
                    Zipcode = "41-800",
                    Street = "Plutonowego R. Szkubacza 1",
                    Email = "jolanta.mleczko@336-mm.com",
                    Telephone = "+48327468256",
                    TelephoneAlt = "+48799234962",
                    ContactName = "Jolanta",
                    ContactSurname = "Mleczko"
                },
                new Location
                {
                    Name = "Media Expert",
                    City = "Chorzów",
                    Zipcode = "41-500",
                    Street = "3-go Maja 169",
                    Email = "lukasz.olender@mediaexpert.com",
                    Telephone = "+48322410037",
                    TelephoneAlt = "+48609288411",
                    ContactName = "£ukasz",
                    ContactSurname = "Olender"
                }
                );

            context.Projects.AddOrUpdate(
                p => p.Id,
                new Project
                {
                    ClientId = 1,
                    Name = "Lenovo - promocja styczeñ 2014",
                    DefaultHourRate = 12,
                    Description = "Promocja nowej linii notebooków z serii Y",
                    StartDate = new DateTime(2014, 1, 3),
                    EndDate = new DateTime(2014, 1, 26),
                    PlannedPaymentDate = new DateTime(2014, 3, 1)
                },
                new Project
                {
                    ClientId = 1,
                    Name = "Lenovo - promocja luty 2014",
                    DefaultHourRate = 12,
                    Description = "Promocja nowej linii notebooków serii Y",
                    StartDate = new DateTime(2014, 1, 31),
                    EndDate = new DateTime(2014, 2, 23),
                    PlannedPaymentDate = new DateTime(2014, 4, 1)
                },
                new Project
                {
                    ClientId = 3,
                    Name = "Samsung - promocja luty 2014",
                    DefaultHourRate = 12,
                    Description = "Promocja monitorów, notebooków i drukarek",
                    StartDate = new DateTime(2014, 1, 31),
                    EndDate = new DateTime(2014, 2, 23),
                    PlannedPaymentDate = new DateTime(2014, 4, 1)
                },
                new Project
                {
                    ClientId = 4,
                    Name = "Apple - promocja MacBook Pro",
                    DefaultHourRate = 16,
                    Description = "Promocja MacBook Pro dla Apple",
                    StartDate = new DateTime(2014, 2, 3),
                    EndDate = new DateTime(2014, 3, 6),
                    PlannedPaymentDate = new DateTime(2014, 4, 1)
                }
                );

            context.ProjectManagers.AddOrUpdate(
                p => p.Id,
                new ProjectManager
                {
                    Firstname = "Mariusz",
                    Lastname = "Dylong",
                    PictureUrl = "",
                    Email = "mariusz.dylong@mtsolutions.com.pl",
                    Telephone = "+48608393906"
                },
                new ProjectManager
                {
                    Firstname = "Magdalena",
                    Lastname = "Busz",
                    PictureUrl = "",
                    Email = "magdalena.busz@mtsolutions.com.pl",
                    Telephone = "+48603114009"
                }
                );

            context.Products.AddOrUpdate(
                p => p.Id,
                new Product
                {
                    ClientId = 1,
                    Name = "Y570",
                    PictureUrl = ""
                },
                new Product
                {
                    ClientId = 1,
                    Name = "Y580",
                    PictureUrl = ""
                },
                new Product
                {
                    ClientId = 1,
                    Name = "Z580",
                    PictureUrl = ""
                },
                new Product
                {
                    ClientId = 1,
                    Name = "Yoga",
                    PictureUrl = ""
                },
                new Product
                {
                    ClientId = 1,
                    Name = "G500",
                    PictureUrl = ""
                },
                new Product
                {
                    ClientId = 1,
                    Name = "G570",
                    PictureUrl = ""
                }
                );

            context.Workers.AddOrUpdate(
                w => w.Id,
                new Worker
                {
                    Firstname = "Tomasz",
                    Lastname = "Dylong",
                    Gender = Gender.Male,
                    PictureUrl = "",
                    PlaceWhereFound = "Prywatnie",
                    Street = "Ró¿owa 11/4",
                    City = "Œwiêtoch³owice",
                    Zipcode = "41-605",
                    Telephone = "+48510484421",
                    Email = "tomdyl@gmail.com"
                },
                new Worker
                {
                    Firstname = "Sylwia",
                    Lastname = "Lepsza",
                    Gender = Gender.Female,
                    PictureUrl = "",
                    PlaceWhereFound = "Facebook",
                    Street = "Obroñców Chorzowa 44/2",
                    City = "Chorzów",
                    Zipcode = "41-506",
                    Telephone = "+48512687329",
                    Email = "sylwia.lepsza@gmail.com"
                },
                new Worker
                {
                    Firstname = "Patrycja",
                    Lastname = "Janas",
                    Gender = Gender.Female,
                    PictureUrl = "",
                    PlaceWhereFound = "Facebook",
                    Street = "Obroñców Chorzowa 28/11",
                    City = "Chorzów",
                    Zipcode = "41-506",
                    Telephone = "+48507888212",
                    Email = "pattj_95@gmail.com"
                },
                new Worker
                {
                    Firstname = "Franciszek",
                    Lastname = "Malcher",
                    Gender = Gender.Male,
                    PictureUrl = "",
                    PlaceWhereFound = "Prywatnie",
                    Street = "Krakowska 41/9",
                    City = "Gliwice",
                    Zipcode = "44-100",
                    Telephone = "+48501120379",
                    Email = "malcherff@gmail.com"
                },
                new Worker
                {
                    Firstname = "Monika",
                    Lastname = "Kotulska",
                    Gender = Gender.Female,
                    PictureUrl = "",
                    PlaceWhereFound = "Prywatnie",
                    Street = "Krakowska 41/9",
                    City = "Gliwice",
                    Zipcode = "44-100",
                    Telephone = "+48504928883",
                    Email = "mkotulska@gmail.com"
                }
                );

            context.WorkUnits.AddOrUpdate(
                w => w.Id,
                new WorkUnit
                {
                    LocationId = 1,
                    ProjectId = 1,
                    WorkerId = 1,
                    StartTime = new DateTime(2014, 1, 3, 15, 0, 0),
                    EndTime = new DateTime(2014, 1, 3, 18, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                },
                new WorkUnit
                {
                    LocationId = 1,
                    ProjectId = 1,
                    WorkerId = 1,
                    StartTime = new DateTime(2014, 1, 4, 9, 0, 0),
                    EndTime = new DateTime(2014, 1, 4, 17, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                },
                new WorkUnit
                {
                    LocationId = 1,
                    ProjectId = 1,
                    WorkerId = 1,
                    StartTime = new DateTime(2014, 1, 5, 10, 0, 0),
                    EndTime = new DateTime(2014, 1, 5, 15, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                },
                new WorkUnit
                {
                    LocationId = 2,
                    ProjectId = 1,
                    WorkerId = 2,
                    StartTime = new DateTime(2014, 1, 3, 15, 0, 0),
                    EndTime = new DateTime(2014, 1, 3, 18, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                },
                new WorkUnit
                {
                    LocationId = 2,
                    ProjectId = 1,
                    WorkerId = 2,
                    StartTime = new DateTime(2014, 1, 4, 9, 0, 0),
                    EndTime = new DateTime(2014, 1, 4, 17, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                },
                new WorkUnit
                {
                    LocationId = 2,
                    ProjectId = 1,
                    WorkerId = 2,
                    StartTime = new DateTime(2014, 1, 5, 10, 0, 0),
                    EndTime = new DateTime(2014, 1, 5, 15, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                },
                new WorkUnit
                {
                    LocationId = 1,
                    ProjectId = 3,
                    WorkerId = 3,
                    StartTime = new DateTime(2014, 1, 3, 15, 0, 0),
                    EndTime = new DateTime(2014, 1, 3, 18, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                },
                new WorkUnit
                {
                    LocationId = 1,
                    ProjectId = 3,
                    WorkerId = 3,
                    StartTime = new DateTime(2014, 1, 4, 9, 0, 0),
                    EndTime = new DateTime(2014, 1, 4, 17, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                },
                new WorkUnit
                {
                    LocationId = 1,
                    ProjectId = 3,
                    WorkerId = 3,
                    StartTime = new DateTime(2014, 1, 5, 10, 0, 0),
                    EndTime = new DateTime(2014, 1, 5, 15, 0, 0),
                    HourRate = 12,
                    IsPaid = false,
                    PaymentDate = new DateTime(2014, 3, 1)
                }
                );

            context.SaveChanges();
        }
    }
}
