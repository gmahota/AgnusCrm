using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AgnusCrm.Web.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace AgnusCrm.Web.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }

        public static Task SendEmailInvoice(this IEmailSender emailSender, string subject,string email,string pathToFile, string linhas)
        {

            var builder = new StringBuilder();

            using (var reader = File.OpenText(pathToFile))
            {
                builder.Append(reader.ReadToEnd());
            }

            builder.Replace("{{linhas}}", linhas);

            return emailSender.SendEmailAsync(email, subject, builder.ToString());
        }
    }
}
