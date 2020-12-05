using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulletinBoard.Models
{
    public class Ad
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Тип объявления")]
        public string Type { get; set; }

        [Display(Name = "Описание")]
        public string Text { get; set; }

        [Required]
        [RegularExpression(@"^[+][0-9]{1,3}[0-9]{3,3}[0-9]{7,7}$", ErrorMessage = "Неверный номер. Пример: +79009875432 ")]
        [Display(Name = "Контактный телефон")]
        public string ContactPhone { get; set; }
    }
}