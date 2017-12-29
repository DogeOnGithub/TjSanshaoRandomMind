using System;
using System.Net;
using System.Net.Mail;

namespace RandomMind
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress("1305705188@qq.com", "TjSanshao");
            mailMsg.To.Add(new MailAddress("1485848825@qq.com", "TjSanshao2"));
            mailMsg.Subject = "mail test";
            mailMsg.Body = "test";
            SmtpClient client = new SmtpClient("smtp.qq.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("1305705188", "gdvwppuvfciciaag")
            };
            client.Send(mailMsg);
            Console.ReadKey();
        }
    }
}
