using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;

namespace nvcore
{
    public static class FileIO
    {
        /// <summary>
        /// Read and deserializ a batchlist file that stored to the application directory. 
        /// </summary>
        /// <param name="file">The file to open for reading.</param>
        /// <returns>A <see cref="List{Batch}"/> instance with readed and serialized xml file.</returns>
        public static List<Batch> CsvReader(string file)
        {
            List<Batch> lst = new List<Batch>();
            List<string> lines = new List<string>(File.ReadAllLines(file));
            
            // Get the type handle of a specified class.
            Type type = typeof(EndPoint);

            // Get the fields of the specified class.
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (lines.First().Contains("BatchName"))
            {
                lines.RemoveAt(0);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                EndPoint ep = new EndPoint();

                //Split a line to an array
                string[] line = lines[i].Split(';');
                List<string> epLine = line.ToList();
                epLine.RemoveRange(0,3);

                for (int j = 0; j < fields.Length; j++)
                {
                    TypeConverter tc = new TypeConverter();
                    Type t = fields[j].FieldType;

                    switch (t.FullName)
                    {
                        case "System.Int32":
                            int intValue;
                            Int32.TryParse(epLine[j], out intValue);
                            fields[j].SetValue(ep, intValue);
                            break;

                        case "System.Boolean":
                            bool boolValue;
                            bool.TryParse(epLine[j], out boolValue);
                            fields[j].SetValue(ep, boolValue);
                            break;

                        case "nvcore.DeviceTypes":
                            DeviceTypes devType = (DeviceTypes)Enum.Parse(typeof(DeviceTypes), epLine[j]);
                            fields[j].SetValue(ep, devType);
                            break;
                        case "System.DateTime":
                            DateTime dtValue = DateTime.Parse(epLine[j]);
                            fields[j].SetValue(ep, dtValue);
                            break;

                        case "System.Net.NetworkInformation.IPStatus":
                            System.Net.NetworkInformation.IPStatus statusValue = (System.Net.NetworkInformation.IPStatus)Enum.Parse(typeof(System.Net.NetworkInformation.IPStatus), epLine[j]);
                            fields[j].SetValue(ep, statusValue);
                            break;

                        case "System.Int64":
                            long longValue;
                            Int64.TryParse(epLine[j], out longValue);
                            fields[j].SetValue(ep, longValue);
                            break;

                        default:
                            object value = tc.ConvertTo(epLine[j], t);
                            fields[j].SetValue(ep, value);
                            break;
                    }
                }

                //Wenn Batch mit Name schon vorhanden ist.
                if (lst.Exists(x => x.Name == line[0]))
                {
                    lst[lst.IndexOf(lst.Single(x => x.Name == line[0]))].EndPointList.Add(ep);
                }
                else //Wenn Batch mit Name NICHT vorhanden ist.
                {
                    Batch batch = new Batch();
                    batch.Name = line[0];
                    batch.Description = line[1];

                    bool ea;
                    bool.TryParse(line[2], out ea);
                    batch.EnableAlerting = ea;

                    batch.EndPointList = new List<EndPoint>();
                    lst.Add(batch);

                    lst[lst.IndexOf(batch)].EndPointList.Add(ep);
                }
            }

            return lst;
        }

        /// <summary>
        /// Serialize a batch list and write to specific directory.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="batchList">The batch list to serialize.</param>
        /// <param name="header">True write out with column titles</param>
        public static void CsvWriter(string file, List<Batch> batchList, bool header)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    EndPoint point = new EndPoint();

                    // Get the type handle of a specified class.
                    Type type = typeof(EndPoint);

                    // Get the fields of the specified class.
                    FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

                    if (header)
                    {
                        sw.WriteLine("BatchName;BatchDescription;EnableAlerting" + string.Join(";", fields.Select(x => x.Name).ToArray()));
                    }

                    foreach (Batch batch in batchList)
                    {
                        foreach (EndPoint ep in batch.EndPointList)
                        {
                            string[] data = new string[fields.Length];

                            for (int i = 0; i < fields.Length; i++)
                            {
                                if (fields[i].GetValue(ep) != null)
                                {
                                    data[i] = fields[i].GetValue(ep).ToString();
                                }
                                else
                                {
                                    data[i] = "";
                                }
                            }

                            sw.WriteLine(batch.Name + ";" + batch.Description + ";" + batch.EnableAlerting + ";" + string.Join(";", data));
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
        /// Serialize and write a batch to an csv file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="batch">The batch to write.</param>
        /// <param name="header">True write out with column titles</param>
        public static void CsvBatchWriter(string file, Batch batch, bool header)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    EndPoint point = new EndPoint();

                    // Get the type handle of a specified class.
                    Type type = typeof(EndPoint);

                    // Get the fields of the specified class.
                    FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

                    if (header)
                    {
                        string.Join(";", fields.Select(x => x.Name).ToArray());

                        sw.WriteLine(string.Join(";", fields.Select(x => x.Name).ToArray())); 
                    }

                    foreach (EndPoint ep in batch.EndPointList)
                    {
                        string[] data = new string[fields.Length];

                        for (int i = 0; i < fields.Length; i++)
                        {
                            if (fields[i].GetValue(ep) != null)
                            {
                                data[i] = fields[i].GetValue(ep).ToString(); 
                            }
                            else
                            {
                                data[i] = "";
                            }
                        }

                        sw.WriteLine(string.Join(";", data));
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serialize and write a batch to an csv file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="batch">The batch to write.</param>
        /// <param name="header">True write out with column titles</param>
        public static async Task CsvBatchWriterAsync(string file, Batch batch, bool header)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    EndPoint point = new EndPoint();

                    // Get the type handle of a specified class.
                    Type type = typeof(EndPoint);

                    // Get the fields of the specified class.
                    FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

                    if (header)
                    {
                        string.Join(";", fields.Select(x => x.Name).ToArray());

                        await sw.WriteLineAsync(string.Join(";", fields.Select(x => x.Name).ToArray()));
                    }

                    foreach (EndPoint ep in batch.EndPointList)
                    {
                        string[] data = new string[fields.Length];

                        for (int i = 0; i < fields.Length; i++)
                        {
                            if (fields[i].GetValue(ep) != null)
                            {
                                data[i] = fields[i].GetValue(ep).ToString();
                            }
                            else
                            {
                                data[i] = "";
                            }
                        }

                        await sw.WriteLineAsync(string.Join(";", data));
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serialize a batch to an javascript array and write out to specific file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="batch">The batch to write.</param>
        public static void JsArrayBatchWriter(string file, Batch batch)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    string[] jsArrayElements = new string[batch.EndPointList.Count];
                    string[] element;

                    for (int i = 0; i < batch.EndPointList.Count; i++)
                    {
                        element = new string[] {
                        batch.EndPointList[i].PrimaryAddress,
                        batch.EndPointList[i].SecondaryAddress,
                        batch.EndPointList[i].PriorityLevel.ToString(),
                        batch.EndPointList[i].IsStaticIp.ToString(),
                        batch.EndPointList[i].Description,
                        batch.EndPointList[i].DeviceVendor,
                        batch.EndPointList[i].DeviceModel,
                        batch.EndPointList[i].DeviceSerial,
                        batch.EndPointList[i].Building,
                        batch.EndPointList[i].Cabinet,
                        batch.EndPointList[i].Rack,
                        batch.EndPointList[i].Panel,
                        batch.EndPointList[i].ConnectedTo,
                        batch.EndPointList[i].VlanId,
                        batch.EndPointList[i].PhysicalAddress,
                        batch.EndPointList[i].MaintenanceActivated.ToString(),
                        batch.EndPointList[i].AutoFetchPhysicalAddress.ToString(),
                        batch.EndPointList[i].Comment,
                        batch.EndPointList[i].LastAvailability.ToString(),
                        batch.EndPointList[i].PingAttempts.ToString(),
                        batch.EndPointList[i].Status.ToString(),
                        batch.EndPointList[i].RoundtripTime.ToString(),
                        batch.EndPointList[i].ReplyAddress.ToString()
                        };
                    
                        jsArrayElements[i] = string.Format("['{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}']", element);
                    }

                    sw.Write("var " + batch.Name.Replace(" ", "_") + " = [" + string.Join(",", jsArrayElements) + "];");
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serialize a batch to an javascript array and write out to specific file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="batch">The batch to write.</param>
        public static async Task JsArrayWriterBatchAsync(string file, Batch batch)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    string[] jsArrayElements = new string[batch.EndPointList.Count];
                    string[] element;

                    for (int i = 0; i < batch.EndPointList.Count; i++)
                    {
                        element = new string[] {
                        batch.EndPointList[i].PrimaryAddress,
                        batch.EndPointList[i].SecondaryAddress,
                        batch.EndPointList[i].PriorityLevel.ToString(),
                        batch.EndPointList[i].IsStaticIp.ToString(),
                        batch.EndPointList[i].Description,
                        batch.EndPointList[i].DeviceVendor,
                        batch.EndPointList[i].DeviceModel,
                        batch.EndPointList[i].DeviceSerial,
                        batch.EndPointList[i].Building,
                        batch.EndPointList[i].Cabinet,
                        batch.EndPointList[i].Rack,
                        batch.EndPointList[i].Panel,
                        batch.EndPointList[i].ConnectedTo,
                        batch.EndPointList[i].VlanId,
                        batch.EndPointList[i].PhysicalAddress,
                        batch.EndPointList[i].MaintenanceActivated.ToString(),
                        batch.EndPointList[i].AutoFetchPhysicalAddress.ToString(),
                        batch.EndPointList[i].Comment,
                        batch.EndPointList[i].LastAvailability.ToString(),
                        batch.EndPointList[i].PingAttempts.ToString(),
                        batch.EndPointList[i].Status.ToString(),
                        batch.EndPointList[i].RoundtripTime.ToString(),
                        batch.EndPointList[i].ReplyAddress.ToString()
                        };

                        jsArrayElements[i] = string.Format("['{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}']", element);
                    }

                    await sw.WriteAsync("var " + batch.Name.Replace(" ", "_") + " = [" + string.Join(",", jsArrayElements) + "];");
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serialize and write a batch to javascript object notation file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="batch">The batch to write.</param>
        public static void JsonBatchWriter(string file, Batch batch)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    var json = new JavaScriptSerializer().Serialize(batch);
                    sw.Write(json);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serialize and write a batch to javascript object notation file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="batch">The batch to write.</param>
        public static async Task JsonBatchWriterAsync(string file, Batch batch)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    var json = new JavaScriptSerializer().Serialize(batch);
                    await sw.WriteAsync(json);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Read and deserialize a json file to a batch instance.
        /// </summary>
        /// <param name="file">The file to open for reading.</param>
        /// <returns></returns>
        public static Batch JsonBatchReader(string file)
        {
            Batch b = null;

            if (File.Exists(file))
            {
                try
                {
                    var serializer = new JavaScriptSerializer();

                    using (StreamReader sr = new StreamReader(file))
                    {
                        b = serializer.Deserialize<Batch>(sr.ReadToEnd());
                    }
                }
                catch (System.Exception)
                {
                    throw;
                } 
            }

            return b;
        }

        /// <summary>
        /// Serialize a batch list and write to application root directory.
        /// </summary>
        /// <param name="batchList">The batch list to serialize.</param>
        public static void XmlWriter(List<Batch> batchList)
        {
            if (batchList != null && batchList.Count > 0)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Batch>));
                    using (TextWriter writer = new StreamWriter(@"batchlist.xml"))
                    {
                        serializer.Serialize(writer, batchList);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                File.Delete(@"batchlist.xml");
            }
        }

        /// <summary>
        /// Serialize a batch list and write to specific directory.
        /// </summary>
        /// <param name="batchList">The batch list to serialize.</param>
        /// <param name="file">The file to write to.</param>
        public static void XmlWriter(string path, List<Batch> batchList)
        {
            if (batchList != null && batchList.Count > 0)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Batch>));
                    using (TextWriter writer = new StreamWriter(@"batchlist.xml"))
                    {
                        serializer.Serialize(writer, batchList);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                File.Delete(@"batchlist.xml");
            }
        }

        /// <summary>
        /// Serializing a batch instance and write to the specific path.
        /// </summary>
        /// <param name="batch">The batch instanc to serialize and write.</param>
        /// <param name="path">The output directory to write the serialized batch instance.</param>
        public static void XmlBatchWriter(Batch batch, string path)
        {
            if (batch != null)
            {
                string file = Path.Combine(path, batch.Name + ".xml");

                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Batch));
                    using (TextWriter writer = new StreamWriter(file))
                    {
                        serializer.Serialize(writer, batch);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                File.Delete(@"batchlist.xml");
            }
        }

        /// <summary>
        /// Read and deserializ a batchlist file that stored to the application directory. 
        /// </summary>
        /// <returns>A <see cref="List{Batch}"/> instance with readed and serialized xml file.</returns>
        public static List<Batch> XmlReader()
        {
            if (File.Exists(@"batchlist.xml"))
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Batch>));
                    TextReader reader = new StreamReader(@"batchlist.xml");
                    object obj = deserializer.Deserialize(reader);
                    List<Batch> lst = (List<Batch>)obj;
                    reader.Close();

                    return lst;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return new List<Batch>();
            }
        }

        /// <summary>
        /// Read and deserializ a batchlist file that stored to a specific directory. 
        /// </summary>
        /// <returns>A <see cref="List{Batch}"/> instance with readed and serialized xml file.</returns>
        public static List<Batch> XmlReader(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Batch>));
                    TextReader reader = new StreamReader(file);
                    object obj = deserializer.Deserialize(reader);
                    List<Batch> lst = (List<Batch>)obj;
                    reader.Close();

                    return lst;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return new List<Batch>();
            }
        }

        /// <summary>
        /// Read and deserializ a batch file that stored to a specific directory.
        /// </summary>
        /// <param name="file">The file to open for reading.</param>
        /// <returns>A batch instance withe serialied data.</returns>
        public static Batch XmlBatchReader(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(Batch));
                    TextReader reader = new StreamReader(file);
                    object obj = deserializer.Deserialize(reader);
                    Batch lst = (Batch)obj;
                    reader.Close();

                    return lst;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return new Batch();
            }
        }
    }
}
