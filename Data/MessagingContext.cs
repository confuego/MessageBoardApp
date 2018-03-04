using System;
using System.Security.Cryptography.X509Certificates;
using Data.DbSets;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MessagingContext : DbContext
    {
        public MessagingContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Message> Messages { get; set; }
    }
}