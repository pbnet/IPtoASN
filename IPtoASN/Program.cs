using System;
using System.IO;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===================================");
        Console.WriteLine("PBNET's IP to ASN Tool");
        Console.WriteLine("By Andrei Rachita");
        Console.WriteLine("===================================");

        try
        {
            Console.Write("Please enter the IP address: ");
            string ipAddress = Console.ReadLine(); // get the IP address from user input  

            using (TcpClient client = new TcpClient("whois.cymru.com", 43))
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                StreamReader reader = new StreamReader(client.GetStream());

                writer.WriteLine("-v " + ipAddress);
                writer.Flush();

                string response = reader.ReadToEnd();

                Console.WriteLine(response);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
