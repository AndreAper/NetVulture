using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Reflection;

namespace nvcore
{
    public class Batch
    {
        private string _name;
        private string _description;
        private List<EndPoint> _endPointList;
        private DateTime _lastExec;
        private int _timeOut;
        private byte[] _buffer;
        private bool _maintenance;
        private int _maxNodes;
        private bool _dontFragment;
        private bool _enableAlerting;

        /// <summary>
        /// Get or set the name of the batch
        /// </summary>
        [XmlElement(ElementName = "Name")]
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// Get or set a optionally description of the batch.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string Description { get { return _description; } set { _description = value; } }

        /// <summary>
        /// Get or set the list that contains all hosts to send the icmp echo messages.
        /// </summary>
        [XmlElement(ElementName = "EndPointList")]
        public List<EndPoint> EndPointList { get { return _endPointList; } set { _endPointList = value; } }

        /// <summary>
        /// Get the last execution of icmp echo request.
        /// </summary>
        [XmlElement(ElementName = "LastExecution")]
        public DateTime LastExecution { get { return _lastExec; } set { _lastExec = value; } }

        /// <summary>
        /// Get or set the time to wait until the icmp package received.
        /// </summary>
        [XmlElement(ElementName = "Timeout")]
        public int Timeout { get { return _timeOut; } set { _timeOut = value; } }

        /// <summary>
        /// Set the buffer of data that transmitted to the target and received in an Internet Control Message Protocol (ICMP) echo reply message. D
        /// </summary>
        [XmlElement(ElementName = "Buffer")]
        public byte[] Buffer { get { return _buffer; } set { _buffer = value; } }

        /// <summary>
        /// Get or set the indicator if maintenance is active or not.
        /// </summary>
        [XmlElement(ElementName = "Maintenance")]
        public bool Maintenance { get { return _maintenance; } set { _maintenance = value; } }

        /// <summary>
        /// True for enabling alerting messages.
        /// </summary>
        [XmlElement(ElementName = "EnableAlerting")]
        public bool EnableAlerting { get { return _enableAlerting; } set { _enableAlerting = value; } }

        /// <summary>
        /// Gets or sets the number of routing nodes that can forward the Ping data before it is discarded.
        /// </summary>
        [XmlElement(ElementName = "MaxNodes")]
        public int MaxNodes { get { return _maxNodes; } set { _maxNodes = value; } }

        /// <summary>
        /// Gets or sets a Boolean value that controls fragmentation of the data sent to the remote host.
        /// </summary>
        [XmlElement(ElementName = "DontFragment")]
        public bool DontFragment { get { return _dontFragment; } set { _dontFragment = value; } }

        /// <summary>
        /// Create a new instance of NetVultureBatch.
        /// </summary>
        public Batch()
        {
            _name = "New Batch";
            _timeOut = 2000;
            _buffer = Encoding.ASCII.GetBytes("123456789");
            _maxNodes = 32;
            _dontFragment = true;
            _endPointList = new List<EndPoint>();
            _enableAlerting = true;
        }

        /// <summary>
        /// Sending requests to all endpoints that added to the endpoinlist.
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public async Task SendRequest()
        {
            //Check if network available.
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                Ping ping = null;
                IPHostEntry primaryTarget = null;
                PingOptions po = new PingOptions(_maxNodes, _dontFragment);

                //Check if endpoints added to the endpoint list.
                if (_endPointList != null && _endPointList.Count > 0)
                {
                    //Set the timestamp for last execution of all ping requests of this batch.
                    _lastExec = DateTime.Now;
                    ping = new Ping();

                    EndPoint endPoint = new EndPoint();

                    try
                    {
                        for (int j = 0; j < _endPointList.Count; j = j + 1)
                        {
                            endPoint = _endPointList[j];

                            //Checking if the nested list for failed requests are null or not.
                            if (endPoint.FailedRequests == null)
                            {
                                endPoint.FailedRequests = new List<DateTime>();
                            }

                            if (endPoint.MaintenanceActivated == false)
                            {
                                //Trying to get host entry from primary address.
                                primaryTarget = Dns.GetHostEntry(_endPointList[j].PrimaryAddress);

                                //First ping request
                                if (primaryTarget.AddressList.Length > 0)
                                {

                                    PingReply reply = await ping.SendPingAsync(_endPointList[j].PrimaryAddress, _timeOut, _buffer, po);

                                    if (reply.Status != IPStatus.Success)
                                    {
                                        endPoint.Status = IPStatus.Unknown;
                                        endPoint.PingAttempts++;
                                        endPoint.FailedRequests.Add(DateTime.Now);
                                    }
                                    else
                                    {
                                        endPoint.ReplyAddress = reply.Address.ToString();
                                        endPoint.ReplyMessage = Encoding.ASCII.GetString(reply.Buffer);
                                        endPoint.RoundtripTime = reply.RoundtripTime;
                                        endPoint.Status = reply.Status;
                                        endPoint.LastAvailability = DateTime.Now;
                                        endPoint.PingAttempts = 0;
                                    }
                                }
                            } 
                        }
                    }
                    catch (SocketException ex)
                    {
                        if (ex.ErrorCode == 11001)
                        {
                            endPoint.Status = IPStatus.Unknown;
                            endPoint.PingAttempts++;
                            endPoint.FailedRequests.Add(DateTime.Now);
                        }
                        else
                        {
                            throw;
                        }
                    }
                    catch (Exception)
                    {
                        endPoint.Status = IPStatus.Unknown;
                        endPoint.PingAttempts++;
                        endPoint.FailedRequests.Add(DateTime.Now);
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Send ping requests to all endpoints that added to the endpointlist.
        /// </summary>
        public void SendAll()
        {
            _lastExec = DateTime.Now;

            if (_endPointList.Count > 0)
            {
                Task<EndPoint>[] workingBees = new Task<EndPoint>[_endPointList.Count];

                for (int i = 0; i < _endPointList.Count; i++)
                {
                    int index = i;
                    workingBees[index] = Task<EndPoint>.Factory.StartNew(() => Send(_endPointList[index]));
                }

                Task.WaitAll(workingBees);

                //Updating Endpointlist
                for (int i = 0; i < workingBees.Length; i++)
                {
                    _endPointList[i] = workingBees[i].Result;
                }
            }
        }

        /// <summary>
        /// Send a ping request asynchronoue to specific endpoint and updates the same enpoint in the endpointlist with the ping reply data.
        /// </summary>
        /// <param name="ping">A ping instance to send an icmp echo message.</param>
        /// <param name="ep">A endpoint instance for send a icmp echo message.</param>
        /// <returns></returns>
        public async Task SendAsync(Ping ping, EndPoint ep)
        {
            EndPoint endPoint = ep;

            //Checking if the nested list for failed requests are null or not.
            if (endPoint.FailedRequests == null)
            {
                endPoint.FailedRequests = new List<DateTime>();
            }

            if (endPoint.MaintenanceActivated == false)
            {
                IPHostEntry primaryTarget = null;
                PingOptions po = new PingOptions(_maxNodes, _dontFragment);

                try
                {
                    //Trying to get host entry from primary address.
                    primaryTarget = Dns.GetHostEntry(endPoint.PrimaryAddress);

                    //First ping request
                    if (primaryTarget.AddressList.Length > 0)
                    {
                        PingReply reply = await ping.SendPingAsync(primaryTarget.AddressList[0], _timeOut, _buffer);

                        if (reply.Status != IPStatus.Success)
                        {
                            endPoint.Status = reply.Status;
                            endPoint.PingAttempts++;
                            endPoint.FailedRequests.Add(DateTime.Now);
                        }
                        else
                        {
                            endPoint.ReplyAddress = reply.Address.ToString();
                            endPoint.ReplyMessage = Encoding.ASCII.GetString(reply.Buffer);
                            endPoint.RoundtripTime = reply.RoundtripTime;
                            endPoint.Status = reply.Status;
                            endPoint.LastAvailability = DateTime.Now;
                            endPoint.PingAttempts = 0;
                        }
                    }
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode == 11001)
                    {
                        endPoint.Status = IPStatus.DestinationUnreachable;
                        endPoint.ReplyMessage = "Exception: " + ex.Message;
                        endPoint.PingAttempts++;
                        endPoint.FailedRequests.Add(DateTime.Now);
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception e)
                {
                    endPoint.Status = IPStatus.IcmpError;
                    endPoint.ReplyMessage = "Exception: " + e.Message;
                    endPoint.PingAttempts++;
                    endPoint.FailedRequests.Add(DateTime.Now);

                    throw;
                }
            }

            _endPointList[_endPointList.IndexOf(ep)] = ep;
        }

        /// <summary>
        /// Send a ping request to specific endpoint and returns the same endpoint with updated ping reply data.
        /// </summary>
        /// <param name="ep">A endpoint instance for send a icmp echo message.</param>
        /// <returns>Returns a endpoint instance with added ping reply data.</returns>
        public EndPoint Send(EndPoint ep)
        {
            EndPoint endPoint = ep;

            //Checking if the nested list for failed requests are null or not.
            if (endPoint.FailedRequests == null)
            {
                endPoint.FailedRequests = new List<DateTime>();
            }

            if (endPoint.MaintenanceActivated == false)
            {
                IPHostEntry primaryTarget = null;
                PingOptions po = new PingOptions(_maxNodes, _dontFragment);
                Ping ping = new Ping();

                try
                {
                    //Trying to get host entry from primary address.
                    primaryTarget = Dns.GetHostEntry(endPoint.PrimaryAddress);

                    //First ping request
                    if (primaryTarget.AddressList.Length > 0)
                    {
                        
                        PingReply reply = ping.Send(primaryTarget.AddressList[0], _timeOut, _buffer, new PingOptions(_maxNodes, _dontFragment));

                        if (reply.Status != IPStatus.Success)
                        {
                            endPoint.Status = reply.Status;
                            endPoint.PingAttempts++;
                            endPoint.FailedRequests.Add(DateTime.Now);
                        }
                        else
                        {
                            endPoint.ReplyAddress = reply.Address.ToString();
                            endPoint.ReplyMessage = Encoding.ASCII.GetString(reply.Buffer);
                            endPoint.RoundtripTime = reply.RoundtripTime;
                            endPoint.Status = reply.Status;
                            endPoint.LastAvailability = DateTime.Now;
                            endPoint.PingAttempts = 0;
                        }
                    }
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode == 11001)
                    {
                        endPoint.Status = IPStatus.Unknown;
                        endPoint.PingAttempts++;
                        endPoint.FailedRequests.Add(DateTime.Now);
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    endPoint.Status = IPStatus.Unknown;
                    endPoint.PingAttempts++;
                    endPoint.FailedRequests.Add(DateTime.Now);

                    throw;
                }
            }

            return ep;
        }

        /// <summary>
        /// Send a ping request asynchronous to specific endpoint and returns the same endpoint with updated ping reply data.
        /// </summary>
        /// <param name="ep">A endpoint instance for send a icmp echo message.</param>
        /// <returns>Returns a endpoint instance with added ping reply data.</returns>
        public async Task<EndPoint> SendAsync(EndPoint ep)
        {
            EndPoint endPoint = ep;

            //Checking if the nested list for failed requests are null or not.
            if (endPoint.FailedRequests == null)
            {
                endPoint.FailedRequests = new List<DateTime>();
            }

            if (endPoint.MaintenanceActivated == false)
            {
                IPHostEntry primaryTarget = null;
                PingOptions po = new PingOptions(_maxNodes, _dontFragment);

                try
                {
                    //Trying to get host entry from primary address.
                    primaryTarget = Dns.GetHostEntry(endPoint.PrimaryAddress);

                    //First ping request
                    if (primaryTarget.AddressList.Length > 0)
                    {
                        Ping ping = new Ping();
                        PingReply reply = await ping.SendPingAsync(primaryTarget.AddressList[0], _timeOut, _buffer, new PingOptions(_maxNodes, _dontFragment));

                        if (reply.Status != IPStatus.Success)
                        {
                            endPoint.Status = reply.Status;
                            endPoint.PingAttempts++;
                            endPoint.FailedRequests.Add(DateTime.Now);
                        }
                        else
                        {
                            endPoint.ReplyAddress = reply.Address.ToString();
                            endPoint.ReplyMessage = Encoding.ASCII.GetString(reply.Buffer);
                            endPoint.RoundtripTime = reply.RoundtripTime;
                            endPoint.Status = reply.Status;
                            endPoint.LastAvailability = DateTime.Now;
                            endPoint.PingAttempts = 0;
                        }
                    }
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode == 11001)
                    {
                        endPoint.Status = IPStatus.Unknown;
                        endPoint.PingAttempts++;
                        endPoint.FailedRequests.Add(DateTime.Now);
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    endPoint.Status = IPStatus.Unknown;
                    endPoint.PingAttempts++;
                    endPoint.FailedRequests.Add(DateTime.Now);

                    throw;
                }
            }

            return ep;
        }

        /// <summary>
        /// Returns a javascript array that represents the current batch instance.
        /// </summary>
        /// <returns>A string that represents the current batch instance.</returns>
        public string ToJsArrayString()
        {
            // Get the type handle of a specified class.
            Type type = typeof(EndPoint);

            // Get the fields of the specified class.
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            List<string> arrayElements = new List<string>();

            foreach (EndPoint ep in this.EndPointList)
            {
                string[] data = new string[fields.Length];

                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i].GetValue(ep) != null)
                    {
                        data[i] = "'" + fields[i].GetValue(ep).ToString() + "'";
                    }
                    else
                    {
                        data[i] = "'NULL'";
                    }
                }

                arrayElements.Add("[" + string.Join(",", data) + "]");
            }

            return "var " + this.Name.Replace(" ", "_").ToLower() + " = [" + string.Join(",", arrayElements.ToArray()) + "];";
        }
    }
}
