using Microsoft.EntityFrameworkCore;
using SimpleChatroomAPI_SignalR.Models;
using System.Collections.Generic;

namespace SimpleChatroomAPI_SignalR.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
    }
}