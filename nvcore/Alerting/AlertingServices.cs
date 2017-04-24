using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;

namespace nvcore.Alerting
{
    public static class AlertingServices
    {
        /// <summary>
        /// Sending email messag using outlook.
        /// </summary>
        /// <param name="body">The body content of the mail message.</param>
        /// <param name="recipients">The addresses of the receivers.</param>
        /// <returns></returns>
        public static bool SendOutlookMail(string body, string subject, params string[] recipients)
        {
            bool sendSucess = false;

            Application app = new OutlookApp();
            MailItem mailItem = app.CreateItem(OlItemType.olMailItem);
            mailItem.Subject = subject;

            foreach (string to in recipients)
            {
                mailItem.Recipients.Add(to);
            }

            mailItem.Body = body;
            mailItem.Display(false);
            mailItem.Importance = OlImportance.olImportanceHigh;

            try
            {
                mailItem.Send();
            }
            catch (System.Exception)
            {
                sendSucess = false;
                throw;
            }

            return sendSucess;
        }
    }
}
