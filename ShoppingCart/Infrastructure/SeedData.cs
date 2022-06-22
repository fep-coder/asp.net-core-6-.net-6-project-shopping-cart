using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Infrastructure
{
        public class SeedData
        {
                public static void SeedDatabase(DataContext context)
                {
                        context.Database.Migrate();

                        if (!context.Products.Any())
                        {
                                Category fruits = new Category { Name = "Fruits", Slug = "fruits" };
                                Category shirts = new Category { Name = "Shirts", Slug = "shirts" };

                                context.Products.AddRange(
                                        new Product
                                        {
                                                Name = "Apples",
                                                Slug = "apples",
                                                Description = "Juicy apples",
                                                Price = 1.50M,
                                                Category = fruits,
                                                Image = "apples.jpg"
                                        },
                                        new Product
                                        {
                                                Name = "Bananas",
                                                Slug = "bananas",
                                                Description = "Fresh bananas",
                                                Price = 3M,
                                                Category = fruits,
                                                Image = "bananas.jpg"
                                        },
                                        new Product
                                        {
                                                Name = "Watermelon",
                                                Slug = "watermelon",
                                                Description = "Juicy watermelon",
                                                Price = 0.50M,
                                                Category = fruits,
                                                Image = "watermelon.jpg"
                                        },
                                        new Product
                                        {
                                                Name = "Grapefruit",
                                                Slug = "grapefruit",
                                                Description = "Juicy grapefruit",
                                                Price = 2M,
                                                Category = fruits,
                                                Image = "grapefruit.jpg"
                                        },
                                        new Product
                                        {
                                                Name = "White shirt",
                                                Slug = "white-shirt",
                                                Description = "White shirt",
                                                Price = 5.99M,
                                                Category = shirts,
                                                Image = "white shirt.jpg"
                                        },
                                        new Product
                                        {
                                                Name = "Black shirt",
                                                Slug = "black-shirt",
                                                Description = "Black shirt",
                                                Price = 7.99M,
                                                Category = shirts,
                                                Image = "black shirt.jpg"
                                        },
                                        new Product
                                        {
                                                Name = "Yellow shirt",
                                                Slug = "yellow-shirt",
                                                Description = "Yellow shirt",
                                                Price = 11.99M,
                                                Category = shirts,
                                                Image = "yellow shirt.jpg"
                                        },
                                        new Product
                                        {
                                                Name = "Grey shirt",
                                                Slug = "grey-shirt",
                                                Description = "Grey shirt",
                                                Price = 12.99M,
                                                Category = shirts,
                                                Image = "grey shirt.jpg"
                                        }
                                );

                                context.SaveChanges();
                        }
                }
        }
}