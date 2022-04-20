using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDictionary.Models
{
    public class WordViewModel
    {
        public int Id { get; set; }



        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Words { get; set; }



        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Description { get; set; }


        [Required(ErrorMessage ="Tel gir")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="tel 10 haneli olmalı")]
        public string Description2 { get; set; }
    }
}
