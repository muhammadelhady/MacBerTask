using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repos.Interfaces
{
    public interface IEmailSenderRepo
    {
        public Task<bool> SendEmail(SendEmailDto emailDto);

    }
}
