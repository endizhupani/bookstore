using System.Collections.Generic;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.Domain.Entities.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStore.Domain.Entities.ApplicationDbContext context)
        {
            if (context.Tags.Any())
                return;

            List<Tag> tagsToAdd = new List<Tag>
            {
                new Tag()
                {
                    Name = "Science fiction"
                    
                },
                new Tag()
                {
                    Name = "Satire"
                },
                new Tag()
                {
                    Name = "Drama"
                },
                new Tag()
                {
                    Name = "Action and Adventure"
                },
                new Tag()
                {
                    Name = "Romance"
                },
                new Tag()
                {
                    Name = "Mystery"
                },
                new Tag()
                {
                    Name = "Horror"
                },
                new Tag()
                {
                    Name = "Self help"
                },
                new Tag()
                {
                    Name = "Health"
                },
                new Tag()
                {
                    Name = "Guide"
                },
                new Tag()
                {
                    Name = "Travel"
                },
                new Tag()
                {
                    Name = "Children&#39;s"
                },
                new Tag()
                {
                    Name = "Religion, Spirituality &amp; New Age"
                },
                new Tag()
                {
                    Name = "Science"
                },
                new Tag()
                {
                    Name = "History"
                },
                new Tag()
                {
                    Name = "Math"
                },
                new Tag()
                {
                    Name = "Anthology"
                },
                new Tag()
                {
                    Name = "Poetry"
                },
                new Tag()
                {
                    Name = "Encyclopedias"
                },
                new Tag()
                {
                    Name = "Dictionaries"
                },
                new Tag()
                {
                    Name = "Comics"
                },
                new Tag()
                {
                    Name = "Art"
                },
                new Tag()
                {
                    Name = "Cookbooks"
                },
                new Tag()
                {
                    Name = "Diaries"
                },
                new Tag()
                {
                    Name = "Journals"
                },
                new Tag()
                {
                    Name = "Series"
                },
                new Tag()
                {
                    Name = "Fantasy"
                }
            };

            context.Tags.AddRange(tagsToAdd);

            List<Book> booksToAdd = new List<Book>()
            {
                new Book()
                {
                    Author = "Suzanne Collins",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Description = "Against all odds, Katniss Everdeen has won the annual Hunger Games with fellow district tribute Peeta Mellark. But it was a victory won by defiance of the Capitol and their harsh rules. Katniss and Peeta should be happy. After all, they have just won for themselves and their families a life of safety and plenty. But there are rumors of rebellion among the subjects, and Katniss and Peeta, to their horror, are the faces of that rebellion. The Capitol is angry. The Capitol wants revenge.",
                    Title = "Catching Fire (The Hunger Games)",
                    NumberOfPages = 354,
                    PublicationDate = new DateTime(2009,9,1),
                    Tags = tagsToAdd.Where(t => t.Name == "Fantasy" || t.Name == "Series").ToList()
                },
                new Book()
                {
                    Author = "Paula Hawkings",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum.",
                    Title = "The girl on the train",
                    NumberOfPages = 268,
                    PublicationDate = new DateTime(2016,7,12),
                    Tags = tagsToAdd.Where(t => t.Name == "Travel" || t.Name == "Mystery" || t.Name == "Romance" || t.Name == "Drama").ToList()
                }
            };
            context.Books.AddRange(booksToAdd);
            context.SaveChanges();

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
