using BL.Repos.Interfaces;
using DAL.DTOs;
using DAL.Entites;
using MacBer.Models;
using MacBer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MacBer.Controllers
{
    public class EmailController : Controller
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IEmailRepo_BL _emailRepo_BL;
        private readonly IEmailSenderRepo _emailSenderRepo;

        public EmailController(ILogger<EmailController> logger,IEmailRepo_BL emailRepo_BL,IEmailSenderRepo emailSenderRepo)
        {
            _logger = logger;
            _emailRepo_BL = emailRepo_BL;
            _emailSenderRepo = emailSenderRepo;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var emailList = await _emailRepo_BL.GetAll();
                return View(emailList);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Index(SaveEmailViewModel model)
        {
            try
            {
                Email email = new Email
                {
                    Subject = model.subject,
                    Message = model.message
                };

                await _emailRepo_BL.New(email);

                return RedirectToAction("index");
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<IActionResult> Send(int id)
        {
            try
            {
                var email = await _emailRepo_BL.GetEmail(id);
                return View(email);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Send(SendEmailViewModel model)
        {
            try
            {
                SendEmailDto sendEmailDto = new SendEmailDto
                {

                    To=model.to,
                    Message=model.message,
                    Subject=model.subject
                };
                bool result = await _emailSenderRepo.SendEmail(sendEmailDto);
                if(result)                
                return RedirectToAction("SentSuccessfully");
                return RedirectToAction("Error");


            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult SentSuccessfully()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    
}
