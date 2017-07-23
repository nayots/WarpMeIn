using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarpMeIn.ViewModels
{
    public class UrlViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(4000)]
        public string Url { get; set; }
    }
}
