using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTodoAppSample.Models
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255), Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}