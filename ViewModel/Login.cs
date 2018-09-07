using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediumClone.ViewModel
{
    public class Login
    {
        [Required]
        [Display(Name = "Kullanıcı Adınız")]
        public string username { get; set; }
        [Required]
        [Display(Name ="Parolanız")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
