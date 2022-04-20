using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    
     public class WordDbContext:DbContext  // burası bize tablo üretcek 
    {
        public WordDbContext(DbContextOptions<WordDbContext> options) : base(options)
        {

        }
        public DbSet<Word> Words { get; set; }
    }
}
