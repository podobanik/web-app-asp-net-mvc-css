using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAppAspNetMvcHtml.Models
{
    public class Citizenship
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        [Display(Name = "Название", Order = 5)]
        public string Name { get; set; }

        


        /// <summary>
        /// Список клиентов
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Client> Clients { get; set; }
    }
}