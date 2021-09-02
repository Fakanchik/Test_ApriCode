using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class GameRequest
    {
        [Required(ErrorMessage = "Введите название игры")]
        [Display(Name = "Название игры")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите название студии разработчиков")]
        [Display(Name = "Название студии разработчиков")]
        public string StudioDeveloper { get; set; }
        [Required(ErrorMessage = "Введите категории игры")]
        [Display(Name = "Категории игр")]
        public string[] Genres { get; set; }
        
    }
}
