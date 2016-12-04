using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToDo.Domain.Entities
{
    public class ToDoTask
    {   
        [Key]
        public int TaskID { get; set; }

        public DateTime CreatingDate { get; set; }

        public DateTime RealizationDate { get; set; }

        public bool RealizationState { get; set; }

        public string Description { get; set; }
    }
}