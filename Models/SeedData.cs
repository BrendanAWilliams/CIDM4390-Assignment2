using Microsoft.EntityFrameworkCore;
using Food2URazor.Data;

namespace Food2URazor.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Food2URazorContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<Food2URazorContext>>()))
        {
            if (context == null || context.Shoppers == null)
            {
                throw new ArgumentNullException("Null Food2URazprContext");
            }

            // Look for any shoppers.
            if (context.Shoppers.Any())
            {
                return;   // DB has been seeded
            }

            context.Shoppers.AddRange(
                new Shopper
                {
                    Username = "brendan",
                    Password = "1234",
                    Name = "Brendan Williams",
                    Email = "bwilliams@email.com",
                    Address = "123 Ace Blvd",
                    Phone = 8064565555
                }
            );

            context.Restaurants.AddRange(
                new Restaurant
                {
                    Name = "McDonalds",
                    Address = "456 Zed St",
                    Phone = 8061235555,
                    Menu = new Menu
                    {
                        Name = "McDonalds Menu",
                        Items = new List<Item>
                        {
                            new Item 
                            {
                                Name = "Burger",
                                Description = "Classic Burger",
                                Price = 5.99
                            },
                            new Item 
                            {
                                Name = "Fries",
                                Description = "Classic French Fries",
                                Price = 2.99
                            }
                        } 
                    }
                },
                new Restaurant
                {
                    Name = "Chipotle",
                    Address = "123 Hall Blvd",
                    Phone = 8067535555,
                    Menu = new Menu
                    {
                        Name = "Chipotle Menu",
                        Items = new List<Item>
                        {
                            new Item 
                            {
                                Name = "Burrito",
                                Description = "Our Signature Burrito",
                                Price = 7.99
                            },
                            new Item 
                            {
                                Name = "Burrito Bowl",
                                Description = "Everything in a our Burrito, without having to feel bad.",
                                Price = 8.99
                            }
                        } 
                    }
                },
                new Restaurant
                {
                    Name = "Panera",
                    Address = "789 Summit Cir.",
                    Phone = 8061595555,
                    Menu = new Menu
                    {
                        Name = "Panera Menu",
                        Items = new List<Item>
                        {
                            new Item 
                            {
                                Name = "Bread Bowl",
                                Description = "Soup in a Bowl of Carbs!",
                                Price = 5.99
                            },
                            new Item 
                            {
                                Name = "Macaroni",
                                Description = "EZ Cheesy",
                                Price = 4.99
                            }
                        } 
                    }
                }
            );
            context.SaveChanges();
        }
    }
}