using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.IO;
using System.Net.Mail;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net.Security;
using Microsoft.Office.Interop.Outlook;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;
using System.Runtime.InteropServices;

namespace NetVulture
{
    public static class NvManagementClass
    {
        /// <summary>
        /// Read and deserialize a csv file to an batch list.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>A list of batches.</returns>
        public static List<NvBatch> DeserializeFromCsv(string file)
        {
            List<NvBatch> lst = new List<NvBatch>();
            List<string> lines = new List<string>(File.ReadAllLines(file));

            if (lines.First().Contains("BatchName"))
            {
                lines.RemoveAt(0);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                string[] line = lines[i].Split(';');

                NvDevice hi = new NvDevice();
                hi.HostnameOrAddress = line[2];
                hi.AlternativeAddress = line[3];
                hi.PriorityLevel = int.Parse(line[4]);
                hi.IsStaticIp = bool.Parse(line[5]);
                hi.Description = line[6];
                hi.DeviceVendor = line[7];
                hi.DeviceModel = line[8];
                hi.DeviceSerial = line[9];
                hi.Building = line[10];
                hi.Cabinet = line[11];
                hi.Rack = line[12];
                hi.Panel = line[13];
                hi.ConnectedTo = line[14];
                hi.VlanId = line[15];
                hi.PhysicalAddress = line[16];
                hi.MaintenanceActivated = bool.Parse(line[17]);
                hi.AutoFetchPhysicalAddress = bool.Parse(line[18]);
                hi.Comment = line[19];
                hi.LastAvailability = DateTime.MinValue;
                hi.PingAttempts = 0;

                //Wenn Batch mit Name schon vorhanden ist.
                if (lst.Exists(x => x.Name == line[0]))
                {
                    lst[lst.IndexOf(lst.Single(x => x.Name == line[0]))].HostList.Add(hi);
                }
                else //Wenn Batch mit Name NICHT vorhanden ist.
                {
                    NvBatch batch = new NvBatch();
                    batch.Name = line[0];
                    batch.Description = line[1];
                    batch.HostList = new List<NvDevice>();
                    lst.Add(batch);

                    lst[lst.IndexOf(batch)].HostList.Add(hi);
                }
            }

            return lst;
        }

        /// <summary>
        /// Serialize and write a batch list to an csv file.
        /// </summary>
        /// <param name="file">The destination file to write.</param>
        /// <param name="batchList">The batch list to write.</param>
        public static void SerializeToCsv(string file, List<NvBatch> batchList)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine("BatchName;BatchDescription;HostnameOrAddress;AlternativeAddress;PriorityLevel;IsStaticIp;Description;DeviceVendor;DeviceModel;DeviceSerial;Building;Cabinet;Rack;Panel;ConnectedTo;VlanId;PhysicalAddress;MaintenanceActivated;AutoFetchPhysicalAddress;Comment;LastAvailability;PingAttempts");

                    foreach (NvBatch batch in batchList)
                    {
                        foreach (NvDevice hi in batch.HostList)
                        {
                            sw.WriteLine(string.Join(";", batch.Name, batch.Description, hi.HostnameOrAddress, hi.AlternativeAddress, hi.PriorityLevel, hi.IsStaticIp, hi.Description, hi.DeviceVendor, hi.DeviceModel, hi.DeviceSerial, hi.Building, hi.Cabinet, hi.Rack, hi.Panel, hi.ConnectedTo, hi.VlanId, hi.PhysicalAddress, hi.MaintenanceActivated, hi.AutoFetchPhysicalAddress, hi.Comment, hi.LastAvailability, hi.PingAttempts));
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convert a batch to javascript array.
        /// </summary>
        /// <param name="batchList">The target batch to convert.</param>
        /// <returns>A string that contains all current information about a batch.</returns>
        public static string ConvertToJsArray(NvBatch batch)
        {
            string[] jsArrayElements = new string[batch.HostList.Count];

            for (int i = 0; i < batch.HostList.Count; i++)
            {
                PingReply pr = batch.HostList[i].ReplyData;

                string[] data;

                if (pr == null)
                {
                    data = new string[] {
                        batch.HostList[i].HostnameOrAddress,
                        batch.HostList[i].AlternativeAddress,
                        batch.HostList[i].PriorityLevel.ToString(),
                        batch.HostList[i].IsStaticIp.ToString(),
                        batch.HostList[i].Description,
                        batch.HostList[i].DeviceVendor,
                        batch.HostList[i].DeviceModel,
                        batch.HostList[i].DeviceSerial,
                        batch.HostList[i].Building,
                        batch.HostList[i].Cabinet,
                        batch.HostList[i].Rack,
                        batch.HostList[i].Panel,
                        batch.HostList[i].ConnectedTo,
                        batch.HostList[i].VlanId,
                        batch.HostList[i].PhysicalAddress,
                        batch.HostList[i].MaintenanceActivated.ToString(),
                        batch.HostList[i].AutoFetchPhysicalAddress.ToString(),
                        batch.HostList[i].Comment,
                        batch.HostList[i].LastAvailability.ToString(),
                        batch.HostList[i].PingAttempts.ToString(),
                        "",
                        "",
                        ""
                    };
                }
                else
                {
                    data = new string[] {
                        batch.HostList[i].HostnameOrAddress,
                        batch.HostList[i].AlternativeAddress,
                        batch.HostList[i].PriorityLevel.ToString(),
                        batch.HostList[i].IsStaticIp.ToString(),
                        batch.HostList[i].Description,
                        batch.HostList[i].DeviceVendor,
                        batch.HostList[i].DeviceModel,
                        batch.HostList[i].DeviceSerial,
                        batch.HostList[i].Building,
                        batch.HostList[i].Cabinet,
                        batch.HostList[i].Rack,
                        batch.HostList[i].Panel,
                        batch.HostList[i].ConnectedTo,
                        batch.HostList[i].VlanId,
                        batch.HostList[i].PhysicalAddress,
                        batch.HostList[i].MaintenanceActivated.ToString(),
                        batch.HostList[i].AutoFetchPhysicalAddress.ToString(),
                        batch.HostList[i].Comment,
                        batch.HostList[i].LastAvailability.ToString(),
                        batch.HostList[i].PingAttempts.ToString(),
                        batch.HostList[i].ReplyData.Status.ToString(),
                        batch.HostList[i].ReplyData.RoundtripTime.ToString(),
                        batch.HostList[i].ReplyData.Address.ToString()
                    };
                }

                //['Target Address or Name','ReceivedIp','RoundTrip','ExecutionTime','Status','Attemps']
                //jsArrayElements[i] = "['" + data[0] + "','" + data[1] + "','" + data[2] + "','" + data[3] + "','" + data[4] + "','" + data[5] + "']";
                jsArrayElements[i] = string.Format("['{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}']", data);
            }

            return "var " + batch.Name.Replace(" ", "_") + " = [" + string.Join(",", jsArrayElements) + "];";
        }

        /// <summary>
        /// Sending mail message to registered address.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [Obsolete()]
        public static async Task SendMailAsync(string msg, params string[] to)
        {
            if (to.Length > 0)
            {
                foreach (string recipient in to)
                {
                    try
                    {
                        Ping p = new Ping();
                        PingReply pr = p.Send(Properties.Settings.Default.MailServer);

                        if (pr.Status != IPStatus.Success)
                        {
                            throw new System.Exception("Mail server: " + Properties.Settings.Default.MailServer + " not available!", null);
                        }

                        SmtpClient client = new SmtpClient();
                        client.Port = Properties.Settings.Default.MailServerPort;
                        client.Host = Properties.Settings.Default.MailServer;
                        client.EnableSsl = true;
                        client.Timeout = 10000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.MailUser, Properties.Settings.Default.MailPassword);
                        await client.SendMailAsync(Properties.Settings.Default.MailUser, recipient, "IOB Monitoring Test Messsage", msg);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static void SendHtmlEmail(string body, params string[] recipients)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(Properties.Settings.Default.MailUser);

            foreach (string to in recipients)
            {
                message.To.Add(to);
            }

            message.Subject = "Html Email Test";
            message.IsBodyHtml = true;
            message.Body = body;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Host = Properties.Settings.Default.MailServer;
            smtpClient.Port = Properties.Settings.Default.MailServerPort;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.MailUser, Properties.Settings.Default.MailPassword);
            smtpClient.Send(message);
        }

        /// <summary>
        /// Send text mail using microsoft outlook
        /// </summary>
        /// <param name="msg">The body text of the message.</param>
        /// <param name="recipients">The receivers of the message.</param>
        /// <returns>Return true if message successfully sent.</returns>
        public static async Task<bool> SendOutlookMail(string msg, params string[] recipients)
        {
            bool sendSucess = false;

            Application app = new OutlookApp();
            MailItem mailItem = app.CreateItem(OlItemType.olMailItem);
            Inspector inspector = mailItem.GetInspector;

            mailItem.BodyFormat = OlBodyFormat.olFormatHTML;
            mailItem.Subject = "IOB Monitoring Messaging Service";

            Recipients oRecips = (Recipients)mailItem.Recipients;

            foreach (string to in recipients)
            {
                //mailItem.Recipients.Add(to);

                Recipient oRecip = (Recipient)oRecips.Add(to);
                oRecip.Resolve();
            }

            mailItem.Body = msg;
            mailItem.Display(false);
            mailItem.Importance = OlImportance.olImportanceHigh;

            try
            {
                mailItem.Send();
                await Task.Delay(10000);
            }
            catch (System.Exception)
            {
                sendSucess = false;
                throw;
            }

            return sendSucess;
        }

        /// <summary>
        /// Send mail using microsoft outlook with specific body format.
        /// </summary>
        /// <param name="format">Specifies the format of the body text.</param>
        /// <param name="msg">The body text of the message.</param>
        /// <param name="recipients">The receivers of the message.</param>
        /// <returns>Return true if message successfully sent.</returns>
        public static async Task<bool> SendOutlookMail(OlBodyFormat format, string msg, params string[] recipients)
        {
            bool sendSucess = false;

            Application app = new OutlookApp();
            MailItem mailItem = app.CreateItem(OlItemType.olMailItem);
            Inspector inspector = mailItem.GetInspector;

            mailItem.BodyFormat = format;
            mailItem.Subject = "IOB Monitoring Messaging Service";

            Recipients oRecips = (Recipients)mailItem.Recipients;

            foreach (string to in recipients)
            {
                //mailItem.Recipients.Add(to);

                Recipient oRecip = (Recipient)oRecips.Add(to);
                oRecip.Resolve();
            }

            mailItem.HTMLBody = msg;
            mailItem.Display(false);
            mailItem.Importance = OlImportance.olImportanceHigh;

            try
            {
                mailItem.Send();
                await Task.Delay(10000);
            }
            catch (System.Exception)
            {
                sendSucess = false;
                throw;
            }

            return sendSucess;
        }
    }

    public enum PriorityLevel
    {
        High,
        Medium,
        Low
    }
}
