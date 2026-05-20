using mascarade.RentalService.Entities;
using Microsoft.EntityFrameworkCore;

namespace mascarade.RentalService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        SeedData(scope.ServiceProvider.GetService<RentalDbContext>());
    }

    private static void SeedData(RentalDbContext context)
    {
        context.Database.Migrate();
        if (context.Costumes.Any())
        {
            Console.WriteLine("Database has been seeded");
            return;
        }

        var costumes = new List<Costume>
        {
            new()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Batman Deluxe",
                Description = "Классический костюм Бэтмена с плащом и маской.",
                ImageUrl = "/images/costumes/batman.jpg",
                Size = "L",
                RentalPriceDay = 8000,
                IsAvailable = true
            },

            new()
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Spider-Man Classic",
                Description = "Костюм Человека-паука для тематических мероприятий.",
                ImageUrl = "/images/costumes/spiderman.jpg",
                Size = "M",
                RentalPriceDay = 7000,
                IsAvailable = true
            },

            new()
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Wonder Woman",
                Description = "Яркий костюм Чудо-женщины.",
                ImageUrl = "/images/costumes/wonderwoman.jpg",
                Size = "S",
                RentalPriceDay = 7500,
                IsAvailable = true
            },

            new()
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "Harry Potter",
                Description = "Мантия волшебника с шарфом факультета.",
                ImageUrl = "/images/costumes/harrypotter.jpg",
                Size = "M",
                RentalPriceDay = 5500,
                IsAvailable = true
            },

            new()
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Name = "Pirate Captain",
                Description = "Костюм капитана пиратов с аксессуарами.",
                ImageUrl = "/images/costumes/pirate.jpg",
                Size = "XL",
                RentalPriceDay = 6000,
                IsAvailable = false
            },

            new()
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                Name = "Princess Elsa",
                Description = "Детский костюм Эльзы из мультфильма.",
                ImageUrl = "/images/costumes/elsa.jpg",
                Size = "XS",
                RentalPriceDay = 4500,
                IsAvailable = true
            },

            new()
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                Name = "Vampire Lord",
                Description = "Готический костюм вампира для Halloween.",
                ImageUrl = "/images/costumes/vampire.jpg",
                Size = "L",
                RentalPriceDay = 6500,
                IsAvailable = true
            },

            new()
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                Name = "Santa Claus",
                Description = "Новогодний костюм Деда Мороза.",
                ImageUrl = "/images/costumes/santa.jpg",
                Size = "XL",
                RentalPriceDay = 9000,
                IsAvailable = false
            },

            new()
            {
                Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                Name = "Catwoman",
                Description = "Костюм Женщины-кошки из комиксов.",
                ImageUrl = "/images/costumes/catwoman.jpg",
                Size = "S",
                RentalPriceDay = 7200,
                IsAvailable = true
            },

            new()
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Medieval Knight",
                Description = "Средневековый рыцарь с плащом.",
                ImageUrl = "/images/costumes/knight.jpg",
                Size = "L",
                RentalPriceDay = 8500,
                IsAvailable = true
            }
        };

        context.Costumes.AddRange(costumes);
        context.SaveChanges();
    }
}