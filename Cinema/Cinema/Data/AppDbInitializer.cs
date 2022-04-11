using CinemaApp.Data.Enums;
using CinemaApp.Data.Static;
using CinemaApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //context.Database.EnsureDeleted();

                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://www.logolynx.com/images/logolynx/85/853a8914e65d033b634147191727b11d.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "https://image.shutterstock.com/image-vector/movie-time-260nw-324455369.jpg",
                            Description = "This is the description of the second cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "https://img2.thaipng.com/20180419/tdq/kisspng-film-cinema-logo-cinema-x-chin-5ad8baa1dec9f4.9139666015241529939126.jpg",
                            Description = "This is the description of the third cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "https://thumbs.dreamstime.com/b/cinema-camera-flat-clipart-vector-illustration-235196018.jpg",
                            Description = "This is the description of the fourth cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "https://images.pond5.com/cinema-4k-ultra-hd-exclusive-footage-043563059_prevstill.jpeg",
                            Description = "This is the description of the fifth cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Adam Sandler",
                            Bio = "This is the Bio of the Adam Sandler",
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Adam_Sandler_Cannes_2017.jpg/250px-Adam_Sandler_Cannes_2017.jpg"

                        },
                        new Actor()
                        {
                            FullName = "Kevin James",
                            Bio = "This is the Bio of Kevin James",
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ed/Kevin_James_2011_%28Cropped%29.jpg/220px-Kevin_James_2011_%28Cropped%29.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Chris Rock",
                            Bio = "This is the Bio of Chris Rock",
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/57/Chris_Rock_WE_2012_Shankbone.JPG/250px-Chris_Rock_WE_2012_Shankbone.JPG"
                        },
                        new Actor()
                        {
                            FullName = "David Spade",
                            Bio = "This is the Bio of David Spade",
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/David_Spade.jpg/250px-David_Spade.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Ryan Reynolds",
                            Bio = "This is the Bio of Ryan Reynolds",
                            PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/14/Deadpool_2_Japan_Premiere_Red_Carpet_Ryan_Reynolds_%28cropped%29.jpg/220px-Deadpool_2_Japan_Premiere_Red_Carpet_Ryan_Reynolds_%28cropped%29.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            PictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            PictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            PictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            PictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            PictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Grown Ups 2",
                            Description = "This is the Grown Ups 2 movie description",
                            Price = 39.50,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/29/Grown_Ups_2_Poster.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "I Now Pronounce You Chuck & Larry",
                            Description = "This is the Chuck & Larry description",
                            Price = 29.50,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/e/e9/Chuckandlarrymp.jpg/220px-Chuckandlarrymp.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 2,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Zookeeper",
                            Description = "This is the Zookeeper movie description",
                            Price = 39.50,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/f/fa/Zookeeper_Poster.jpg/220px-Zookeeper_Poster.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 3,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "The Do-Over",
                            Description = "This is the The Do-Over movie description",
                            Price = 39.50,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/1/12/The_Do-Over_Poster.png/220px-The_Do-Over_Poster.png",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 4,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Croods",
                            Description = "This is the Croods movie description",
                            Price = 39.50,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/6/63/The_Croods.png/220px-The_Croods.png",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 5,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Big Daddy",
                            Description = "This is the Big Daddy movie description",
                            Price = 39.50,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/ca/Big_Daddy_film.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        // Grown Ups
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                         new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        //"I Now Pronounce You Chuck & Larry"
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 4
                        },


                        //"Zookeeper"
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        //"The Do-Over"
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 2
                        },

                        //The Croods
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        

                        //"BigDaddy"
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                        
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //User
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                string adminUserEmail = "admin@cinema.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAdminUser, "@Code1234@");

                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                var appUserEmail = "user@cinema.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);

                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        FullName = "App User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAppUser, "@Code1234@");

                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
