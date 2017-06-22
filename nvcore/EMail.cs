using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Office.Interop.Outlook;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.ComponentModel;


namespace nvcore
{
    public static class EMail
    {
        /// <summary>
        /// Allows applications to send e-mail by using the Simple Mail Transfer Protocol (SMTP).
        /// </summary>
        /// <param name="server">Name or IP address of the host used for SMTP transactions.</param>
        /// <param name="port">The port used for SMTP transactions.</param>
        /// <param name="msg">The specified message to an SMTP server for delivery.</param>
        /// <param name="from">The from address for this e-mail message.</param>
        /// <param name="recipients">The recipients for this e-mail message.</param>
        public static void SendMail(string server, int port, string msg, string from, params string[] recipients)
        {
            try
            {
                //Instantiate SmtpClient class with specific server and port.
                SmtpClient client = new SmtpClient(server);

                if (port > 0)
                {
                    client.Port = port; 
                }

                client.UseDefaultCredentials = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                foreach (string receiver in recipients)
                {
                    message.To.Add(receiver);
                }

                message.Subject = "IOB Monitoring Messaging System";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = msg;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                message.IsBodyHtml = false;

                client.Send(message);
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Allows applications to send e-mail by using the Simple Mail Transfer Protocol (SMTP) with specific credentials.
        /// </summary>
        /// <param name="server">Name or IP address of the host used for SMTP transactions.</param>
        /// <param name="port">The port used for SMTP transactions.</param>
        /// <param name="user">The specific user for SMTP transactions.</param>
        /// <param name="password">The specific password for SMTP transactions.</param>
        /// <param name="msg">The specified message to an SMTP server for delivery.</param>
        /// <param name="from">The from address for this e-mail message.</param>
        /// <param name="recipients">The recipients for this e-mail message.</param>
        public static void SendMail(string server, int port, string user, string password, string msg, string from, params string[] recipients)
        {
            try
            {
                //Instantiate SmtpClient class with specific server and port.
                SmtpClient client = new SmtpClient(server);

                if (port > 0)
                {
                    client.Port = port;
                }

                client.UseDefaultCredentials = false;
                NetworkCredential credentials = new NetworkCredential(user, password);
                client.Credentials = credentials;
                client.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                foreach (string receiver in recipients)
                {
                    message.To.Add(receiver);
                }

                message.Subject = "IOB Monitoring Messaging System";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = msg;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                message.IsBodyHtml = false;

                client.Send(message);
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Allows applications to send e-mail asynchronous by using the Simple Mail Transfer Protocol (SMTP).
        /// </summary>
        /// <param name="server">Name or IP address of the host used for SMTP transactions.</param>
        /// <param name="port">The port used for SMTP transactions.</param>
        /// <param name="msg">The specified message to an SMTP server for delivery.</param>
        /// <param name="from">The from address for this e-mail message.</param>
        /// <param name="recipients">The recipients for this e-mail message.</param>
        public static async Task SendMailAsync(string server, int port, string msg, string from, params string[] recipients)
        {
            try
            {
                //Instantiate SmtpClient class with specific server and port.
                SmtpClient client = new SmtpClient(server);

                if (port > 0)
                {
                    client.Port = port;
                }

                client.UseDefaultCredentials = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                foreach (string receiver in recipients)
                {
                    message.To.Add(receiver);
                }

                message.Subject = "IOB Monitoring Messaging System";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = msg;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                message.IsBodyHtml = false;

                await client.SendMailAsync(message);
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Allows applications to send e-mail asynchronousby using the Simple Mail Transfer Protocol (SMTP) with specific credentials.
        /// </summary>
        /// <param name="server">Name or IP address of the host used for SMTP transactions.</param>
        /// <param name="port">The port used for SMTP transactions.</param>
        /// <param name="user">The specific user for SMTP transactions.</param>
        /// <param name="password">The specific password for SMTP transactions.</param>
        /// <param name="msg">The specified message to an SMTP server for delivery.</param>
        /// <param name="from">The from address for this e-mail message.</param>
        /// <param name="recipients">The recipients for this e-mail message.</param>
        public static async Task SendMailAsync(string server, int port, string user, string password, string msg, string from, params string[] recipients)
        {
            try
            {
                //Instantiate SmtpClient class with specific server and port.
                SmtpClient client = new SmtpClient(server);

                if (port > 0)
                {
                    client.Port = port;
                }

                client.UseDefaultCredentials = false;
                NetworkCredential credentials = new NetworkCredential(user, password);
                client.Credentials = credentials;
                client.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                foreach (string receiver in recipients)
                {
                    message.To.Add(receiver);
                }

                message.Subject = "IOB Monitoring Messaging System";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = msg;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                message.IsBodyHtml = false;

                await client.SendMailAsync(message);
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Allows applications to send e-mail by using the Simple Mail Transfer Protocol (SMTP).
        /// </summary>
        /// <param name="server">Name or IP address of the host used for SMTP transactions.</param>
        /// <param name="port">The port used for SMTP transactions.</param>
        /// <param name="msg">The specified message to an SMTP server for delivery.</param>
        /// <param name="from">The from address for this e-mail message.</param>
        /// <param name="recipients">The recipients for this e-mail message.</param>
        public static void SendHtmlMail(string server, int port, string msg, string from, params string[] recipients)
        {
            try
            {
                //Instantiate SmtpClient class with specific server and port.
                SmtpClient client = new SmtpClient(server);

                if (port > 0)
                {
                    client.Port = port;
                }

                client.UseDefaultCredentials = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                foreach (string receiver in recipients)
                {
                    message.To.Add(receiver);
                }

                message.Subject = "IOB Monitoring Messaging System";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = msg;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                message.IsBodyHtml = true;

                client.Send(message);
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Allows applications to send e-mail by using the Simple Mail Transfer Protocol (SMTP) with specific credentials.
        /// </summary>
        /// <param name="server">Name or IP address of the host used for SMTP transactions.</param>
        /// <param name="port">The port used for SMTP transactions.</param>
        /// <param name="user">The specific user for SMTP transactions.</param>
        /// <param name="password">The specific password for SMTP transactions.</param>
        /// <param name="msg">The specified message to an SMTP server for delivery.</param>
        /// <param name="from">The from address for this e-mail message.</param>
        /// <param name="recipients">The recipients for this e-mail message.</param>
        public static void SendHtmlMail(string server, int port, string user, string password, string msg, string from, params string[] recipients)
        {
            try
            {
                //Instantiate SmtpClient class with specific server and port.
                SmtpClient client = new SmtpClient(server);

                if (port > 0)
                {
                    client.Port = port;
                }

                client.UseDefaultCredentials = false;
                NetworkCredential credentials = new NetworkCredential(user, password);
                client.Credentials = credentials;
                client.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                foreach (string receiver in recipients)
                {
                    message.To.Add(receiver);
                }

                message.Subject = "IOB Monitoring Messaging System";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = msg;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                message.IsBodyHtml = true;

                client.Send(message);
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Allows applications to send e-mail asynchronous by using the Simple Mail Transfer Protocol (SMTP).
        /// </summary>
        /// <param name="server">Name or IP address of the host used for SMTP transactions.</param>
        /// <param name="port"></param>
        /// <param name="msg">The specified message to an SMTP server for delivery.</param>
        /// <param name="from">The from address for this e-mail message.</param>
        /// <param name="recipients">The recipients for this e-mail message.</param>
        public static async Task SendHtmlMailAsync(string server, int port, string msg, string from, params string[] recipients)
        {
            try
            {
                //Instantiate SmtpClient class with specific server and port.
                SmtpClient client = new SmtpClient(server);

                if (port > 0)
                {
                    client.Port = port;
                }

                client.UseDefaultCredentials = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                foreach (string receiver in recipients)
                {
                    message.To.Add(receiver);
                }

                message.Subject = "IOB Monitoring Messaging System";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = msg;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                message.IsBodyHtml = true;

                await client.SendMailAsync(message);
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Allows applications to send e-mail asynchronous by using the Simple Mail Transfer Protocol (SMTP) with specific credentials.
        /// </summary>
        /// <param name="server">Name or IP address of the host used for SMTP transactions.</param>
        /// <param name="port">The port used for SMTP transactions.</param>
        /// <param name="user">The specific user for SMTP transactions.</param>
        /// <param name="password">The specific password for SMTP transactions.</param>
        /// <param name="msg">The specified message to an SMTP server for delivery.</param>
        /// <param name="from">The from address for this e-mail message.</param>
        /// <param name="recipients">The recipients for this e-mail message.</param>
        public static async Task SendHtmlMailAsync(string server, int port, string user, string password, string msg, string from, params string[] recipients)
        {
            try
            {
                //Instantiate SmtpClient class with specific server and port.
                SmtpClient client = new SmtpClient(server);

                if (port > 0)
                {
                    client.Port = port;
                }

                client.UseDefaultCredentials = false;
                NetworkCredential credentials = new NetworkCredential(user, password);
                client.Credentials = credentials;
                client.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);

                foreach (string receiver in recipients)
                {
                    message.To.Add(receiver);
                }

                message.Subject = "IOB Monitoring Messaging System";
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = msg;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                message.IsBodyHtml = true;

                await client.SendMailAsync(message);
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// Send a mail using microsoft outlook with html body format with specific username and password.
        /// </summary>
        /// <remarks>NOTE: This method kills all active outlook instances and create a new one.</remarks>
        /// <param name="msg">The body of the message in html format.</param>
        /// <param name="recipients">One or more receivers of the messages.</param>
        /// <param name="user">Username to send the mail message.</param>
        /// <param name="pw">The password to send the mail message.</param>
        /// <returns>Return true if message successfully sent.</returns>
        public static async Task<bool> SendOlMailAsync(string user, string pw, string msg, params string[] recipients)
        {
            bool sendSucess = false;
            Process olProcess = null;

            try
            {
                Process[] activeOlInstances = Process.GetProcessesByName("OUTLOOK");

                // Check whether there is an Outlook process running.
                if (activeOlInstances.Count() > 0)
                {
                    foreach (Process p in activeOlInstances)
                    {
                        p.Kill();
                    }
                }

                olProcess = new Process();
                olProcess.StartInfo.FileName = "OUTLOOK.EXE";
                olProcess.StartInfo.Arguments = "";
                olProcess.StartInfo.ErrorDialog = false;
                olProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                olProcess.Start();

                OutlookApp app = new OutlookApp();

                NameSpace nameSpace = app.GetNamespace("MAPI");
                nameSpace.Logon(user, pw, Missing.Value, Missing.Value);
                nameSpace = null;

                MailItem mailItem = app.CreateItem(OlItemType.olMailItem);
                mailItem.BodyFormat = OlBodyFormat.olFormatHTML;
                mailItem.Subject = "IOB Monitoring Messaging Service";

                foreach (string to in recipients)
                {
                    mailItem.Recipients.Add(to);
                }

                mailItem.Recipients.ResolveAll();

                mailItem.HTMLBody = msg;
                mailItem.Display(false);
                mailItem.Importance = OlImportance.olImportanceHigh;

                if (olProcess.Responding)
                {
                    mailItem.Send();
                }
            }
            catch (System.Exception)
            {
                sendSucess = false;
                throw;
            }
            finally
            {
                await Task.Delay(15000);

                if (olProcess != null && !olProcess.HasExited)
                {
                    olProcess.Kill();
                    sendSucess = true;
                }
            }

            return sendSucess;
        }

        /// <summary>
        /// Send a mail using microsoft outlook with html body format with default username and password.
        /// </summary>
        /// <remarks>NOTE: This method kills all active outlook instances and create a new one.</remarks>
        /// <param name="msg">The body of the message in html format.</param>
        /// <param name="recipients">One or more receivers of the messages.</param>
        /// <returns>Return true if message successfully sent and the outlook process has been terminated.</returns>
        public static async Task<bool> SendOlMailAsync(string msg, params string[] recipients)
        {
            bool sendSucess = false;
            Process olProcess = null;

            try
            {
                Process[] activeOlInstances = Process.GetProcessesByName("OUTLOOK");

                // Check whether there is an Outlook process running.
                if (activeOlInstances.Count() > 0)
                {
                    foreach (Process p in activeOlInstances)
                    {
                        p.Kill();
                    }
                }

                olProcess = new Process();
                olProcess.StartInfo.FileName = "OUTLOOK.EXE";
                olProcess.StartInfo.Arguments = "";
                olProcess.StartInfo.ErrorDialog = false;
                olProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                olProcess.Start();

                OutlookApp app = new OutlookApp();

                //NameSpace nameSpace = app.GetNamespace("MAPI");
                //nameSpace.Logon(user, pw, Missing.Value, Missing.Value);
                //nameSpace = null;

                MailItem mailItem = app.CreateItem(OlItemType.olMailItem);
                mailItem.BodyFormat = OlBodyFormat.olFormatHTML;
                mailItem.Subject = "IOB Monitoring Messaging Service";

                foreach (string to in recipients)
                {
                    mailItem.Recipients.Add(to);
                }

                mailItem.Recipients.ResolveAll();

                mailItem.HTMLBody = msg;
                mailItem.Display(false);
                mailItem.Importance = OlImportance.olImportanceHigh;

                if (olProcess.Responding)
                {
                    mailItem.Send();
                }
            }
            catch (System.Exception)
            {
                sendSucess = false;
                throw;
            }
            finally
            {
                await Task.Delay(15000);

                if (olProcess != null && !olProcess.HasExited)
                {
                    olProcess.Kill();
                    sendSucess = true;
                }
            }

            return sendSucess;
        }

        public const string TestMessageBody = "";
    }
}
