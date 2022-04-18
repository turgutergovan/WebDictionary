using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionary.Helpers
{
    public class RepositoryFactory
    {
        static WordRepository _repoWord;
        public static IRepositoryWord CreateRepo(string tip)
        {
            if (_repoWord == null)
            {
                if (tip == "WORD")
                {
                    lock (new object())
                    {
                        _repoWord = new WordRepository();
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
