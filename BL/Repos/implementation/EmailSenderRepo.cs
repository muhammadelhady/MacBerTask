using BL.Repos.Interfaces;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repos.implementation
{
    public class EmailSenderRepo : IEmailSenderRepo
    {
        public async Task<bool> SendEmail(SendEmailDto emailDto)
        {
            try
            {
                string [] address = ReciverAddressesSpliter(emailDto.To);
                if (address.Length == 0)
                    return false;
                bool result = await SMTP_SendEmail(address, emailDto.Subject, emailDto.Message);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string [] ReciverAddressesSpliter (string to)
        {
            to.Trim();
            return to.Split(';');
        }

        private async Task<bool> SMTP_SendEmail(string [] to , string subject , string message)
        {
            
            try
            {
                return true; //to use function remove this line and complete the missing cerdentials 


                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFromAddress = "Send From Address";
                string password = "Sender Password";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFromAddress, "Title");
                    foreach (string address in to)
                    {
                        mail.To.Add(address);
                    }
                   
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                        smtp.EnableSsl = enableSSL;
                        await Task.Run(() => smtp.SendMailAsync(mail));
                    }
                    return true;
                }
            }
            catch (Exception )
            {
                return false;
            }
        }

    }
}
