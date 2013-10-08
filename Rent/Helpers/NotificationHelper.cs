using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using log4net;

namespace Rent
{
    public static class NotificationHelper
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(NotificationHelper));
 
        public static void NotifyMe(string mailTo, RentedApartment item, string siteDomain)
        {
            if (!String.IsNullOrEmpty(mailTo))
            {
                if (mailTo.Contains('@'))
                {
                    try
                    {
                        MailMessage message = new MailMessage();
                        message.To.Add(mailTo);
                        message.Subject = "Rent. Новое предложение по аренде жилья от " + item.AdCreated.ToString("HH:mm dd.MM.yyyy");

                        message.Body = "#" + item.AdId + "\n" + item.AdCreated.ToString("HH:mm dd.MM.yyyy") + "\n" +
                            "Владелец: - " + item.AdOwnerLoginName + "( " + siteDomain + item.AdOwnerUserUrl + " )\n" +
                            "Описание ( " + siteDomain + item.AdUrl + " ):\n" +
                            item.Title + "\n\n" + item.Description;
                     
                            SmtpClient smtp = new SmtpClient();
                            smtp.Send(message);
                     }
                     catch (Exception ex)
                     {
                         Logging.Log.Error(item, ex);
                     }
                }
            }
        }
    }
}
