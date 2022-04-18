using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepositoryWord
    {
        void AddOrUpdate(Word word);
        void Delete(Word word);
        List<Word> List();
        void SaveChanges();
        void Delete(int id);
    }
}
