using Bogus;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using FastTicket.Domain.Entities;
using FastTicket.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FastTicket.Persistence.Contexts;

public class SeedData
{
    private class CategoriesModel
    {
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
    //100 random user.
    private static List<User> GetUsers()
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash("123123", out passwordHash, out passwordSalt);
        var result = new Faker<User>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.LastName, i => i.Person.LastName)
                .RuleFor(i => i.Email, i => i.Internet.Email())
                .RuleFor(i => i.Status, i => i.PickRandom(true,false))
                .RuleFor(i => i.PasswordHash, i => passwordHash)
                .RuleFor(i => i.PasswordSalt, i => passwordSalt)
                .RuleFor(i => i.AuthenticatorType, i => AuthenticatorType.Email)
            .Generate(100);
        return result;
    }

    private static CategoriesModel GetCategories()
    {
        var list = new List<string> { "Music", "Stage", "Sports", "Family", "Education & More" };
        var musicList = new List<string> { "Pop", "Rock", "Jazz", "Classical", "Alternative" };
        var stageList = new List<string> { "Theater", "Show", "Ballet - Dance", "Stand-Up", "Alternative" };
        var sportsList = new List<string> { "Football", "Basketball", "Volleyball", "Motorsports" };
        var familyList = new List<string> { "Show", "Circus", "Theater", "Musical Show", "Zorr", "Theme Park", "Attraction Center", "Minimaster" };
        var edumoreList = new List<string> { "Museum", "Club", "Onstage", "Minimaster" };

        var dict = new Dictionary<string, List<string>>();

        dict.Add(list[0], musicList);
        dict.Add(list[1], stageList);
        dict.Add(list[2], sportsList);
        dict.Add(list[3], familyList);
        dict.Add(list[4], edumoreList);

        var categories = new List<Category>();
        var subCategories = new List<SubCategory>();

        for (int index = 0; index < dict.Count; index++)
        {
            var item = dict.ElementAt(index);
            var itemKey = item.Key;
            var itemValue = item.Value;
            var category = new Category { Id = Guid.NewGuid(), Name = itemKey };
            categories.Add(category);
            for (int i = 0; i < itemValue.Count; i++)
            {
                subCategories.Add(new SubCategory { Id = Guid.NewGuid(), CategoryId = category.Id, Name = itemValue[i] });
            }

        }
        var result = new CategoriesModel { Categories = categories, SubCategories = subCategories };
        return result;
    }

    private static List<City> GetCities()
    {
        var list = new List<string> {"Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin",
            "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale",
            "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir",
            "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir",
            "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya",
            "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya",
            "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak",
            "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak",
            "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };

        var cities = new List<City>();

        for (int i = 0; i < list.Count; i++)
        {
            cities.Add(new City() { Id = Guid.NewGuid(), Code = (i + 1).ToString(), Name = list[i] });
        }
        return cities;
    }

    private static List<Venue> GetVenues(List<Guid> cityIds)
    {

        var result = new Faker<Venue>("tr")
                        .RuleFor(i => i.Id, i => Guid.NewGuid())
                        .RuleFor(i => i.Name, i => i.Company.CompanyName())
                        .RuleFor(i => i.LogoImagePath, i => "venue-logo-default.png")
                        .RuleFor(i => i.VenueImagePath, i => "venue-image-default.png")
                        .RuleFor(i => i.SeatingArrangementImagePath, i => "venue-seating-default.png")
                        .RuleFor(i => i.Address, i => i.Address.FullAddress())
                        .RuleFor(i => i.Description, i => i.Lorem.Paragraph(2))
                        .RuleFor(i => i.CityId, i => i.PickRandom(cityIds))
                    .Generate(500);
        return result;
    }

    private static List<Event> GetEvents(List<Guid> venueIds, List<Guid> eventGroupIds, List<Guid> categoryIds)
    {
        var result = new Faker<Event>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.Name, i => i.Person.FullName)
                .RuleFor(i => i.Status, i => i.PickRandom(EventStatusEnum.OnSale, EventStatusEnum.Soon, EventStatusEnum.Canceled))
                .RuleFor(i => i.VenueId, i => i.PickRandom(venueIds))
                .RuleFor(i => i.StartDate, i => i.Date.Between(DateTime.Now, DateTime.Now.AddDays(7)))
                .RuleFor(i => i.EndDate, i => i.Date.Between(DateTime.Now, DateTime.Now.AddDays(7)))
                .RuleFor(i => i.ImagePath, i => "event-image-default.png")
                .RuleFor(i => i.Description, i => i.Lorem.Paragraph(2))
                .RuleFor(i => i.Rules, i => i.Lorem.Paragraph(4))
                .RuleFor(i => i.EventGroupId, i => i.PickRandom(eventGroupIds))
                .RuleFor(i => i.CategoryId, i => i.PickRandom(categoryIds))
            .Generate(100);

       
        Random rnd = new Random();


        var result2 = new Faker<Event>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.Name, i => i.Person.FullName)
                .RuleFor(i => i.Status, i => i.PickRandom(EventStatusEnum.OnSale, EventStatusEnum.Soon, EventStatusEnum.Canceled))
                .RuleFor(i => i.VenueId, i => i.PickRandom(venueIds))
                .RuleFor(i => i.StartDate, i => i.Date.Between(DateTime.Now, DateTime.Now.AddDays(7)))
                .RuleFor(i => i.EndDate, i => i.Date.Between(DateTime.Now, DateTime.Now.AddDays(7)))
                .RuleFor(i => i.ImagePath, i => "event-image-default.png")
                .RuleFor(i => i.Description, i => i.Lorem.Paragraph(2))
                .RuleFor(i => i.Rules, i => i.Lorem.Paragraph(4))
                .RuleFor(i => i.EventGroupId, i => null)
                .RuleFor(i => i.Description, i => i.Lorem.Paragraph(2))
                .RuleFor(i => i.CategoryId, i => i.PickRandom(categoryIds))
            .Generate(100);
        foreach (var item in result2)
        {
            item.EndDate = item.StartDate.AddHours(rnd.Next(1, 5));
        }
        result.AddRange(result2);
        return result;
    }

    private static List<EventGroup> GetEventGroups(List<Guid> categoryIds)
    {
        var result = new Faker<EventGroup>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.Name, i => i.Person.FullName)
                .RuleFor(i => i.Status, i => i.PickRandom(EventStatusEnum.OnSale, EventStatusEnum.Soon, EventStatusEnum.Canceled))
                .RuleFor(i => i.StartDate, i => i.Date.Between(DateTime.Now, DateTime.Now.AddDays(7)))
                .RuleFor(i => i.EndDate, i => i.Date.Between(DateTime.Now, DateTime.Now.AddDays(7)))
                .RuleFor(i => i.ImagePath, i => "event-image-default.png")
                .RuleFor(i => i.Description, i => i.Lorem.Paragraph(2))
                .RuleFor(i => i.OfficalWebSiteUrl, i => "https://www.google.com/")
                .RuleFor(i => i.CategoryId, i => i.PickRandom(categoryIds))
            .Generate(100);
       
        return result;
    }

    private static List<Performance> GetPerformances(List<Guid> eventIds)
    {

        var result = new Faker<Performance>("tr")
                        .RuleFor(i => i.Id, i => Guid.NewGuid())
                        .RuleFor(i => i.EventId, i => i.PickRandom(eventIds))
                    .Generate(eventIds.Count);
        return result;
    }

    private static List<Ticket> GetTickets(List<Guid> eventIds)
    {

        var result = new Faker<Ticket>("tr")
                        .RuleFor(i => i.Id, i => Guid.NewGuid())
                        .RuleFor(i => i.EventId, i => i.PickRandom(eventIds))
                    .Generate(eventIds.Count);
        return result;
    }

    private static List<TicketCategory> GetTicketCategories(List<Guid> ticketIds)
    {
        var list = new List<string> { "General Center", "1.Category", "2.Category" };
        var result = new Faker<TicketCategory>("tr")
                        .RuleFor(i => i.Id, i => Guid.NewGuid())
                        .RuleFor(i => i.Name, i => i.PickRandom(list))
                        .RuleFor(i => i.Price, i => new Random().Next(50, 500))
                        .RuleFor(i => i.Stock, i => new Random().Next(20, 200))
                        .RuleFor(i => i.TicketId, i => i.PickRandom(ticketIds))
                    .Generate(ticketIds.Count);
        return result;
    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseSqlServer(configuration.GetConnectionString("FastTicketConnectionString"));
        var context = new FastTicketDbContext(dbContextBuilder.Options, configuration);


        //Users added.
        var users = GetUsers();
        var userIds = users.Select(i => i.Id).ToList();
        await context.Users.AddRangeAsync(users);

        //Categories and SubCategories added.
        var categories = GetCategories();
        var categoryIds = categories.Categories.Select(i => i.Id).ToList();
        await context.Categories.AddRangeAsync(categories.Categories);
        await context.SubCategories.AddRangeAsync(categories.SubCategories);

        //Cities added.
        var cities = GetCities();
        var cityIds = cities.Select(i => i.Id).ToList();
        await context.Cities.AddRangeAsync(cities);

        //Venues added.
        var venues = GetVenues(cityIds);
        var venueIds = venues.Select(i => i.Id).ToList();
        await context.Venues.AddRangeAsync(venues);

        //EventGroups added.
        var eventGroups = GetEventGroups(categoryIds);
        var eventGroupIds = eventGroups.Select(i => i.Id).ToList();
        await context.EventGroups.AddRangeAsync(eventGroups);

        //Events added.
        var events = GetEvents(venueIds, eventGroupIds, categoryIds);
        var eventIds = events.Select(i => i.Id).ToList();
        await context.Events.AddRangeAsync(events);
        await context.SaveChangesAsync();


        //Performances added.
        var performances = GetPerformances(eventIds);
        var performanceIds = performances.Select(i => i.Id).ToList();
        await context.Performances.AddRangeAsync(performances);

        //Tickets added.
        var tickets = GetTickets(eventIds);
        var ticketIds = tickets.Select(i => i.Id).ToList();
        await context.Tickets.AddRangeAsync(tickets);

        //TicketCategories added.
        var ticketCategories = GetTicketCategories(ticketIds);
        var ticketCategoryIds = ticketCategories.Select(i => i.Id).ToList();
        await context.TicketCategories.AddRangeAsync(ticketCategories);


        await context.SaveChangesAsync();
    }

}
