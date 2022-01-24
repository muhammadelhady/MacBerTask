using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTOs
{
    public class SendEmailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
