using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Word
    {
        public int Id { get; set; }

        public string Words { get; set; }
  
        public string Description { get; set; }
 
        public string Description2 { get; set; }
    }
}
