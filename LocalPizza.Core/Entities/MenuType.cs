using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LocalPizza.Core.Entities
{
    public class MenuType
    {
        [Key]
        public int MenuTypeId { get; set; }
        public string Name { get; set; }
    }
}
