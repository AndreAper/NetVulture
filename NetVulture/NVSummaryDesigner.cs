﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVulture
{
    public class NvSummaryDesigner
    {
        protected StringBuilder SbOutput;

        public string Output { get
            {
                SbOutput.Append("</table></body></html>");
                return this.SbOutput.ToString();
            }
        }

        public NvSummaryDesigner()
        {
            SbOutput = new StringBuilder();

            //Adding header information
            SbOutput.Append(
                "<!DOCTYPE html><html><head><style>" +
                "h1 { font-family: arial, sans-serif;font-weight:normal;background-color:#00324b;color:#ffffff;text-align:center; }" +
                "table {font-family: arial, sans-serif;border-collapse: collapse;width: 100%;}" +
                "td, th {border: 1px solid #dddddd;text-align: left;padding: 8px;}" +
                ".header {background-color: #e3e3e3;}" +
                ".noneAlert {background-color: #8DD454;}" +
                ".warning {background-color: #FE9B33;}" +
                ".alert {color: #ffffff;background-color: #EA0043;}" +
                ".criticalAlert {color: #ffffff;background-color: #7330A4;}" +
                "</style></head><body>" +
                "<h1>IOB MONITORING DAILY SUMMARY</h1><table>"
                );
        }

        public void AddBatch(NvBatch batch)
        {
            if (batch != null)
            {
                if (batch.HostList != null && batch.HostList.Count > 0)
                {
                    IEnumerable<NvDevice> offlineDevices = batch.HostList.Where(x => x.ReplyData != null && x.ReplyData.Status != System.Net.NetworkInformation.IPStatus.Success);
                    IEnumerable<NvDevice> onlineDevices = batch.HostList.Where(x => x.ReplyData != null && x.ReplyData.Status == System.Net.NetworkInformation.IPStatus.Success);

                    if (offlineDevices.Count() > 0)
                    {
                        if (offlineDevices.Any(x => x.PriorityLevel == 0))
                        {
                            SbOutput.Append(
                                "<tr class='criticalAlert'>" +
                                string.Format("<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th>", batch.Name, batch.Description, batch.Maintenance, batch.HostList.Count(), onlineDevices.Count(), offlineDevices.Count()) +
                                "</tr>");
                        }
                        else
                        {
                            SbOutput.Append(
                                "<tr class='alert'>" +
                                string.Format("<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th>", batch.Name, batch.Description, batch.Maintenance, batch.HostList.Count(), onlineDevices.Count(), offlineDevices.Count()) +
                                "</tr>");
                        }
                    }
                    else
                    {
                        SbOutput.Append(
                            "<tr class='noneAlert'>" +
                            string.Format("<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th>", batch.Name, batch.Description, batch.Maintenance, batch.HostList.Count(), onlineDevices.Count(), offlineDevices.Count()) +
                            "</tr>");
                    }  
                }
                else
                {
                    SbOutput.Append(
                        "<tr class='noneAlert'>" +
                        string.Format("<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th>", batch.Name, batch.Description, batch.Maintenance, 0, 0, 0) +
                        "</tr>");
                }
            }
        }
    }
}