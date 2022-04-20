using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebDictionary.Helpers;
using WebDictionary.Models;

namespace WebDictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepositoryWord _wordRepository;
        public HomeController(ILogger<HomeController> logger,IRepositoryWord repositoryWord)
        {
            _logger = logger;
            _wordRepository = repositoryWord;
           // _wordRepository = RepositoryFactory.CreateRepo("WORD");
        }

        public IActionResult Index(string order,string searchBox)
        {
            //  IRepositoryWord _repository = RepositoryFactory.CreateRepo("WORD");

            List<Word> liste = _wordRepository.List();


            if (order == "Words")
            {
                liste = liste.OrderBy(c => c.Words).ToList();
            }
            else if (order == "Description")
            {
                liste = liste.OrderBy(c => c.Description).ToList();
            }
            else if (order == "Description2")
            {
                liste = liste.OrderBy(c => c.Description2).ToList();
            }
            else
            {
                liste = liste.OrderBy(c => c.Id).ToList();
            }


            if (!String.IsNullOrEmpty(searchBox))
            {
                liste = liste.Where(c => c.Words.StartsWith(searchBox) || c.Description.StartsWith(searchBox)).ToList();
            }

            List<WordViewModel> model = new List<WordViewModel>();

            foreach (var item in liste)
            {
                WordViewModel wv = new WordViewModel() { Id = item.Id, Words = item.Words, Description = item.Description, Description2 = item.Description2 };
                model.Add(wv);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateWord(int? id)//? şey demek null olabilir demek
        {
            WordViewModel model = new WordViewModel();
            if (id.HasValue && id > 0)
            {
                List<Word> kelimeler = _wordRepository.List();
                var word = kelimeler.First(c => c.Id == id);
                model.Id = word.Id;
                model.Words = word.Words;
                model.Description = word.Description;
                model.Description2= word.Description2;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateWord(Word word)
        {
            
            _wordRepository.AddOrUpdate(word);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            _wordRepository.Delete(id);
            return RedirectToAction("Index");
        }



        public IActionResult Privacy(KelimeTest kelimetest)
        {
            return View(kelimetest);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
