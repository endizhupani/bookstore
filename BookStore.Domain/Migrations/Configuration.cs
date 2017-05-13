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
                    Name = "Science fiction",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Satire",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Drama",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Action and Adventure",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Romance",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Mystery",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Horror",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Self help",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Health",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Guide",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Travel",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Children&#39;s",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Religion, Spirituality &amp; New Age",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Science",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "History",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Math",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Anthology",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Poetry",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Encyclopedias",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Dictionaries",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Comics",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Art",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Cookbooks",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Diaries",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Journals",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Series",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
                },
                new Tag()
                {
                    Name = "Fantasy",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dolor ipsum, tincidunt nec quam nec, imperdiet placerat nulla. Duis ultricies porta enim non tempor. Mauris a finibus nibh, eu rutrum tortor. Nunc nibh sapien, pellentesque in viverra quis, hendrerit nec urna. Praesent gravida ante non elit tristique, nec tincidunt dui hendrerit. Quisque feugiat dictum arcu in placerat. Curabitur at tortor sit amet turpis aliquet vestibulum."
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
