using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToDo.Domain.Entities
{
    public class ToDoTask
    {   
        [Key]
        //[HiddenInput(DisplayValue = false)]
        public int TaskID { get; set; }

        [Display(Name ="Data utworzenia")]
        public DateTime CreatingDate { get; set; }

        [Display(Name = "Data realizacji")]
        public DateTime RealizationDate { get; set; }

        [Display(Name = "Zrealizowane?")]
        public bool RealizationState { get; set; }

        [Display(Name = "Opis"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}