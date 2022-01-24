using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MacBer.ViewModels
{
    public class SaveEmailViewModel
    {
        public string subject { get; set; }
        public string message { get; set; }
    }
}
