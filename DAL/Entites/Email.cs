using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entites
{
    public class Email : Audit
    {
        public string  Subject { get; set; }
        public string Message { get; set; }  
    }
}
