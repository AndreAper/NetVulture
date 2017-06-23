using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace nvcore
{
    public class Summary
    {
        public const string HtmlHeader = "<!DOCTYPE html>" +
                                         "<html>" +
                                         "<head>" +
                                         "<style>" +
                                         "h1 {font-family: Segoe, \"Segoe UI\", \"DejaVu Sans\", \"Trebuchet MS\", Verdana, \"sans-serif\"; font-weight:bold; background-color:#00324b; color:#ffffff; text-align:center; padding:5px;}" +
                                         "table {font-family: Segoe, \"Segoe UI\", \"DejaVu Sans\", \"Trebuchet MS\", Verdana, \"sans-serif\"; border-collapse:collapse; min-width: 100%; max-width: 100%; text-align:left;}" +
                                         "td, th {border: 1px solid; padding: 5px;}" +
                                         ".header {background-color: #e3e3e3; font-weight: bold; min-width: 25%; max-width: 25%;}" +
                                         ".noneAlert {background-color: #8DD454; font-weight: normal; min-width: 25%; max-width: 25%;}" +
                                         ".warning {background-color: #FE9B33; font-weight: normal; min-width: 25%; max-width: 25%;}" +
                                         ".alert {background-color: #EA0043; color: #ffffff; margin: 0px 0px 5px 0px; padding:10px; min-width: 25%; max-width: 25%;}" +
                                         ".criticalAlert {background-color: #7330A4; color: #ffffff; font-weight: normal; min-width: 25%; max-width: 25%;}" +
                                         ".batchHeader {color: #ffffff; background-color: #EA0043; font-family: Segoe, \"Segoe UI\", \"DejaVu Sans\", \"Trebuchet MS\", Verdana, \"sans-serif\"; font-weight:normal; margin: 0px; padding:5px; font-size: 22px;}" +
                                         ".batchDescription {font-family: arial, sans-serif;font-weight:normal; margin: 0px; padding:5px; background-color: #e3e3e3;}" +
                                         "</style>" +
                                         "</head>" +
                                         "<body>" +
                                         "<div style=\"min-width: 100%; max-width: 100%;\">" +
                                         "<h1>IOB MONITORING ALERTING MESSAGE</h1>";

        public static string Create(List<Batch> batchList)
        {
            StringBuilder sbOutput = new StringBuilder();

            sbOutput.Append(
                "<!DOCTYPE html><html><head><style>" +
                "h1 { font-family: arial, sans-serif;font-weight:lighter;background-color:#00324b;color:#ffffff;text-align:center; padding:5px}" +
                "table {font-family: arial, sans-serif;border-collapse: collapse;width: 100%;}" +
                "td, th {border: 1px solid; text-align: left; padding: 8px;}" +
                ".header {background-color: #e3e3e3;}" +
                ".noneAlert {background-color: #8DD454;}" +
                ".warning {background-color: #FE9B33;}" +
                ".alert {color: #ffffff;background-color: #EA0043;}" +
                ".criticalAlert {color: #ffffff;background-color: #7330A4;}" +
                "</style></head><body>" +
                "<h1>IOB MONITORING DAILY SUMMARY</h1><table>" +
                "<tr class='header'><th>Batch Name</th><th>Description</th><th>Maintenance</th><th>Hosts Count</th><th>Hosts Online</th><th>Hosts Offline</th><th style='width: 40%'>Information</th></tr>"
            );

            foreach (Batch batch in batchList)
            {
                if (batch.EndPointList != null && batch.EndPointList.Count > 0)
                {
                    IEnumerable<EndPoint> offlineDevices = batch.EndPointList.Where(x => x.Status != IPStatus.Success);
                    IEnumerable<EndPoint> onlineDevices = batch.EndPointList.Where(x => x.Status == IPStatus.Success);

                    if (offlineDevices.Count() > 0)
                    {
                        StringBuilder sbInfo = new StringBuilder();

                        foreach (EndPoint d in offlineDevices)
                        {
                            sbInfo.Append(string.Format("<p>Hostname: {0}; Last Availability: {1};<br/>Building: {2}; Cabinet {3}; Rack: {4}</p>", d.PrimaryAddress, d.LastAvailability, d.Building, d.Cabinet, d.Rack));
                        }

                        if (offlineDevices.Any(x => x.PriorityLevel == 0))
                        {
                            sbOutput.Append(string.Format("<tr class='criticalAlert'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                                batch.Name, batch.Description, batch.Maintenance, batch.EndPointList.Count(), onlineDevices.Count(), offlineDevices.Count(), sbInfo.ToString()));
                        }
                        else
                        {
                            sbOutput.Append(string.Format("<tr class='alert'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                                batch.Name, batch.Description, batch.Maintenance, batch.EndPointList.Count(), onlineDevices.Count(), offlineDevices.Count(), sbInfo.ToString()));
                        }
                    }
                    else
                    {
                        if (batch.EndPointList.Count - onlineDevices.Count() > 0)
                        {
                            sbOutput.Append(string.Format("<tr class='warning'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                                batch.Name, batch.Description, batch.Maintenance, batch.EndPointList.Count(), onlineDevices.Count(), offlineDevices.Count(), ""));
                        }
                        else
                        {
                            sbOutput.Append(string.Format("<tr class='noneAlert'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                                batch.Name, batch.Description, batch.Maintenance, batch.EndPointList.Count(), onlineDevices.Count(), offlineDevices.Count(), ""));
                        }
                    }
                }
                else
                {
                    sbOutput.Append(string.Format("<tr class='noneAlert'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                        batch.Name, batch.Description, batch.Maintenance, batch.EndPointList.Count(), "", "", "No hosts are added to this batch."));
                }
            }

            sbOutput.Append("</table></body></html>");

            return sbOutput.ToString();
        }

        public static string CreateAlertingMessage(Batch batch)
        {
            StringBuilder sb = new StringBuilder();

            if (batch != null)
            {
                //Add styles und title
                sb.Append(HtmlHeader);

                //Batch information area
                sb.Append("<div style =\"border: thin; border-style: solid; min-width: 100%; max-width: 100%; margin-bottom: 10px\">");
                sb.Append($"<p class=\"batchHeader\">An alarm was triggered by the batch: {batch.Name}</p>");
                sb.Append($"<p class=\"batchDescription\">Description: {batch.Description}</p>");
                sb.Append($"<p class=\"batchDescription\">Hosts Count: {batch.EndPointList.Count}&emsp;Hosts Online: {batch.EndPointList.Count(x => x.Status == IPStatus.Success)}&emsp;Hosts Offline {batch.EndPointList.Count(x => x.Status != IPStatus.Success)}</p>");
                sb.Append("</div>");

                //Column titles
                sb.Append("<table>");
                sb.Append("<tr class=\"header\">");
                sb.Append("<th>Host Information</th>");
                sb.Append("<th>Device Information</th>");
                sb.Append("<th>Location</th>");
                sb.Append("<th>Status</th>");
                sb.Append("</tr>");

                foreach (EndPoint ep in batch.EndPointList)
                {
                    string hostInfo = $"Primary Adress: {ep.PrimaryAddress}\r\nSecondary Address: {ep.SecondaryAddress}\r\nPriority Level: {ep.PriorityLevel}\r\nIs static IP: {ep.IsStaticIp}\r\nDescription: {ep.Description}";
                    string deviceInfo = $"Type: {ep.DeviceType}\r\nVendor: {ep.DeviceVendor}\r\nModel: {ep.DeviceModel}\r\nSerial: {ep.DeviceSerial}";
                    string locationInfo = $"Building: {ep.Building}\r\nCabinet: {ep.Cabinet}\r\nRack: {ep.Rack}\r\nPanel: {ep.Panel}\r\nConnected To: {ep.ConnectedTo}\r\nVlanId: {ep.VlanId}";
                    string statusInfo = $"IP Status: {ep.Status}\r\nReply Address: {ep.ReplyAddress}\r\nReply Message:{ep.ReplyMessage}";

                    if (ep.Status == IPStatus.Success)
                    {
                        sb.Append("<tr class=\"noneAlert\">");
                        sb.Append($"<td>{hostInfo}</td>");
                        sb.Append($"<td>{deviceInfo}</td>");
                        sb.Append($"<td>{locationInfo}</td>");
                        sb.Append($"<td>{statusInfo}</td>");
                    }
                    else
                    {
                        switch (ep.PriorityLevel)
                        {
                            case 0:
                                sb.Append("<tr class=\"criticalAlert\">");
                                sb.Append($"<td>{hostInfo}</td>");
                                sb.Append($"<td>{deviceInfo}</td>");
                                sb.Append($"<td>{locationInfo}</td>");
                                sb.Append($"<td>{statusInfo}</td>");
                                break;

                            case 1:
                                sb.Append("<tr class=\"alert\">");
                                sb.Append($"<td>{hostInfo}</td>");
                                sb.Append($"<td>{deviceInfo}</td>");
                                sb.Append($"<td>{locationInfo}</td>");
                                sb.Append($"<td>{statusInfo}</td>");
                                break;

                            case int n when (n >= 2):
                                sb.Append("<tr class=\"warning\">");
                                sb.Append($"<td>{hostInfo}</td>");
                                sb.Append($"<td>{deviceInfo}</td>");
                                sb.Append($"<td>{locationInfo}</td>");
                                sb.Append($"<td>{statusInfo}</td>");
                                break;

                            default:
                                sb.Append("<tr class=\"noneAlert\">");
                                sb.Append($"<td>{hostInfo}</td>");
                                sb.Append($"<td>{deviceInfo}</td>");
                                sb.Append($"<td>{locationInfo}</td>");
                                sb.Append($"<td>{statusInfo}</td>");
                                break;
                        }
                    }
                }

                sb.Append("</table>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</body>");
                sb.Append("</html>");

                return sb.ToString(); 
            }
            else
            {
                throw new ArgumentNullException("batch", "Batch instance is null.");
            }
        }
    }
}
