using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nvcore;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;


namespace _Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Batch> batchList = new List<Batch>();

            Batch bOne = new Batch();
            bOne.Name = "Test1";
            bOne.Buffer = Encoding.ASCII.GetBytes("HelloWorld");

            bOne.EndPointList.Add(new nvcore.EndPoint() { PrimaryAddress = "192.168.0.1" });
            bOne.EndPointList.Add(new nvcore.EndPoint() { PrimaryAddress = "10.0.0.1" });
            bOne.EndPointList.Add(new nvcore.EndPoint() { PrimaryAddress = "www.google.de" });

            batchList.Add(bOne);

            Batch bTwo = new Batch();
            bTwo.Name = "Test2";
            bTwo.Buffer = Encoding.ASCII.GetBytes("HelloWorld");

            bTwo.EndPointList.Add(new nvcore.EndPoint() { PrimaryAddress = "192.168.0.1" });
            bTwo.EndPointList.Add(new nvcore.EndPoint() { PrimaryAddress = "10.0.0.1" });
            bTwo.EndPointList.Add(new nvcore.EndPoint() { PrimaryAddress = "www.google.de" });

            batchList.Add(bTwo);

            Task[] workingBees = new Task[batchList.Count];

            for (int i = 0; i < batchList.Count; i++)
            {
                int index = i;
                workingBees[index] = Task.Factory.StartNew(() => batchList[index].SendAll());
            }

            Task.WaitAll(workingBees);

            Console.WriteLine("Done");

            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);

            Console.Read();
        }

        static void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                Console.WriteLine("Connected");
            }
            else
            {
                Console.WriteLine("Disconnected");
            }
        }
    }
}
