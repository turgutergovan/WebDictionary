using DataAccessLayer;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionary.Helpers
{
    public class RepositoryFactory
    {
        static IRepositoryWord _repoWord;
        public static IRepositoryWord CreateRepo(string tip)
        {
            if (_repoWord == null)
            {
                if (tip == "WORD")
                {
                    lock (new object())
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<WordDbContext>();
                        optionsBuilder.UseSqlServer("Server=DESKTOP-R2IBTOP;Database=SozlukApp;Trusted_Connection=True;MultipleActiveResultSets=true");
                        WordDbContext context = new WordDbContext(optionsBuilder.Options);
                        _repoWord = new WordRepositoryNew(context);
                    }
                    return _repoWord;
                }
                else
                    return null;
            }
            else
                return _repoWord;
        }
    }
}
