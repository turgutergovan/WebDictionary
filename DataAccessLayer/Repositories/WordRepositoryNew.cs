using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WordRepositoryNew : IRepositoryWord
    {
        WordDbContext _context;
        public WordRepositoryNew(WordDbContext context)
        {
            _context = context;
        }
        public void AddOrUpdate(Word word)
        {
            if (word.Id<=0)
            _context.Set<Word>().Add(word);
            else 
            { 
               var updateEdilecek = _context.Set<Word>().FirstOrDefault(c=>c.Id == word.Id); 
                updateEdilecek.Words = word.Words;
                updateEdilecek.Description = word.Description;
                updateEdilecek.Description2 = word.Description2;
            }
            SaveChanges();
                

        }

        public void Delete(Word word)
        {
            _context.Set<Word>().Remove(word);
            SaveChanges();
            
        }

        public void Delete(int id)
        {
            Word silinecek = _context.Set<Word>().First(c => c.Id == id);
            Delete(silinecek);
        }

        public List<Word> List()
        {
            return _context.Set<Word>().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
