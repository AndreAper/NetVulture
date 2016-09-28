using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Renci.SshNet;
using System.IO;

namespace NetVulture
{
    public static class NVManagementClass
    {
        /// <summary>
        /// Read and deserialize a csv file to an batch list.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>A list of batches.</returns>
        public static List<NVBatch> DeserializeFromCsv(string file)
        {
            //BatchName;BatchDescription;HostnameOrAddress;HostDescription;Building;Cabinet;Rack;PhysicalAddress;Maintenance;AutoFetchPhysicalAddress
            List<NVBatch> lst = new List<NVBatch>();
            List<string> lines = new List<string>(File.ReadAllLines(file));

            if (lines.First().Contains("BatchName"))
            {
                lines.RemoveAt(0);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                //BatchName [0]
                //BatchDescription [1]
                //HostnameOrAddress [2]
                //HostDescription [3]
                //Building [4]
                //Cabinet [5]
                //Rack [6]
                //PhysicalAddress [7]
                //Maintenance [8]
                //AutoFetchPhysicalAddress [9]

                string[] line = lines[i].Split(';');

                HostInformation hi = new HostInformation();
                hi.HostnameOrAddress = line[2];
                hi.Description = line[3];
                hi.Building = line[4];
                hi.Cabinet = line[5];
                hi.Rack = line[6];
                hi.PhysicalAddress = line[7];
                hi.MaintenanceActivated = bool.Parse(line[8]);
                hi.AutoFetchPhysicalAddress = bool.Parse(line[9]);

                //Wenn Batch mit Name schon vorhanden ist.
                if (lst.Exists(x => x.Name == line[0]))
                {
                    lst[lst.IndexOf(lst.Single(x => x.Name == line[0]))].HostList.Add(hi);
                }
                else //Wenn Batch mit Name NICHT vorhanden ist.
                {
                    NVBatch batch = new NVBatch();
                    batch.Name = line[0];
                    batch.Description = line[1];
                    batch.HostList = new List<HostInformation>();
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
        public static void SerializeToCsv(string file, List<NVBatch> batchList)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine("BatchName;BatchDescription;HostnameOrAddress;HostDescription;Building;Cabinet;Rack;PhysicalAddress;Maintenance;AutoFetchPhysicalAddress");

                    foreach (NVBatch batch in batchList)
                    {
                        foreach (HostInformation hi in batch.HostList)
                        {
                            sw.WriteLine(string.Join(";", batch.Name, batch.Description, hi.HostnameOrAddress, hi.Description, hi.Building, hi.Cabinet, hi.Rack, hi.PhysicalAddress, hi.MaintenanceActivated, hi.AutoFetchPhysicalAddress));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Sending mail message to registered address.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static async Task SendMail(string svr, string usr, string pw, string msg, params string[] to)
        {
            Ping p = new Ping();
            PingReply pr = await p.SendPingAsync(svr);

            if (pr.Status != IPStatus.Success)
            {
                //TODO: Rückmeldung wenn Methode abgebrochen wurde.
                //MessageBox.Show("SMS/Mail Gateway is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Renci.SshNet.Common.SshConnectionException("SMS/Mail Gateway is not available.");
            }

            try
            {
                //Set up the SSH connection
                using (SshClient _client = new SshClient(svr, usr, pw))
                {
                    //Start the connection
                    _client.Connect();

                    foreach (string address in to)
                    {
                        string command = string.Format("echo -e 'Subject: {0}\nFrom: {1}\nTo: {2}\n{3}\n\n' | sudo ssmtp '{4}'", "NetVulture Alerting System", "monitoring.bbs@gmail.com", address, msg, address);
                        SshCommand cmd = _client.RunCommand(command);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
