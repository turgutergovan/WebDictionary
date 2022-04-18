using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WordRepository : IRepositoryWord
    {
        static List<Word> _word = new List<Word>();
        public void AddOrUpdate(Word word)
        {
            if (word.Id<=0)
            {
                if (!_word.Any())
                {
                    word.Id = 1;

                }
                else
                {
                    word.Id = _word.Max(c => c.Id) + 1;

                }
                _word.Add(word);
            }
            else
            {
                Word updateEdilecek = _word.First(c => c.Id == word.Id);
                updateEdilecek.Words = word.Words;
                updateEdilecek.Description = word.Description;
                updateEdilecek.Description2 = word.Description2;
            }
            SaveChanges();


        }

        public void Delete(Word word)
        {
            _word.Remove(word);
            SaveChanges();
        }

        public void Delete(int id)
        {
            Word silinecek = _word.FirstOrDefault(c => c.Id == id);
            //First : kayıt yoksa hata alır
            //FirstOrDefault :kayıt yoksa null döner
            //Single: kayıt 1 adet değilse hata alır

            if (silinecek != null)
            {
                Delete(silinecek);
            }
        }

        public List<Word> List()
        {
            string fileContent = File.ReadAllText(@"C:\Users\turgu\Desktop\DictionaryApp\WebDictionary\bin\Debug\net5.0\Kelimeler.json");
            _word = JsonSerializer.Deserialize<List<Word>>(fileContent);
            return _word.ToList();
        }

        public void SaveChanges()
        {
            string serializedKelimeler = JsonSerializer.Serialize(_word);
            File.WriteAllText(@"C:\Users\turgu\Desktop\DictionaryApp\WebDictionary\bin\Debug\net5.0\Kelimeler.json", serializedKelimeler);

        }
    }
}
