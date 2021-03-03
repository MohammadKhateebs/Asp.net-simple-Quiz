using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Pleas Provied User Name",AllowEmptyStrings =false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Pleas Provied Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string password { get; set; }

    }
}
