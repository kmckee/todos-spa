using Microsoft.EntityFrameworkCore;
using System;

namespace Todos.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoTopic> TodoTopics { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=KMTodosv2;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString)
                          .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo() { Id = 1, Name = "Take out garbage" },
                new Todo() { Id = 2, Name = "Clean the mug" },
                new Todo() { Id = 3, Name = "Vacuum" },
                new Todo() { Id = 4, Name = "Wash the whiteboards" }
                );

            modelBuilder.Entity<Comment>().HasData(
                new Comment() { Id = 1, Text = "Vacuuming is the worst!", CreatedAt = new DateTime(2018, 11, 2), TodoId = 3 }
                );

            modelBuilder.Entity<Topic>().HasData(
                new Topic() { Id = 1, Title = "Work" },
                new Topic() { Id = 2, Title = "Home" }
                );
                 
            modelBuilder.Entity<TodoTopic>().HasData(
                new TodoTopic() { Id = 1, TodoId = 1, TopicId = 2 },
                new TodoTopic() { Id = 2, TodoId = 2, TopicId = 1 },
                new TodoTopic() { Id = 3, TodoId = 2, TopicId = 2 },
                new TodoTopic() { Id = 4, TodoId = 3, TopicId = 2 },
                new TodoTopic() { Id = 5, TodoId = 4, TopicId = 1 },
                new TodoTopic() { Id = 6, TodoId = 4, TopicId = 2 }
                );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
