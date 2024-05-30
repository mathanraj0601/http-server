using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    public class Program
    {

        // Default file location
        static string _webRootUrl = $"wwwroot\\";
        
        // Default port
        static int port = 12345;
        static void Main(string[] args)
        {
           
            if (_webRootUrl == null || _webRootUrl == String.Empty)
            {
                Console.WriteLine("No path is provided");
                return;
            }


            if(args.Length >= 1) 
                _webRootUrl = args[0];
            if (args.Length >=2)
                port = int.Parse(args[1]);

            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine($"Server started on {port}");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected!");
                ThreadPool.SetMaxThreads(10, 10);
                ThreadPool.QueueUserWorkItem(new WaitCallback(Respond), client);

                // UN managed thread result in exhaustion
                //Thread thread = new Thread(() => Respond(client));
                //thread.Start();

            }


        }

         static async void Respond(Object? clientObject)
        {
            if (clientObject is not TcpClient) {
                return;
            }

            TcpClient client = (TcpClient)clientObject;

            try
            {
                // 30 secs timout for send and receive
                client.SendTimeout = 3000;
                client.ReceiveTimeout = 3000;
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string requestData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                string[] requestParts = requestData.Split(' '); // Split the request line into its parts

                if (requestData.Length < 2)
                {
                    string badRequest = "HTTP/1.1 400 Bad request\r\n\r\n";
                    byte[] badRequestBytes = Encoding.ASCII.GetBytes(badRequest);
                    await stream.WriteAsync(badRequestBytes, 0, badRequestBytes.Length);
                    return;
                }

                string method = requestParts[0]; // HTTP method (e.g., GET, POST)
                string url = requestParts[1]; // Request URL


                if (method == "GET")
                {
                    // Extracting file path
                    string filePath = string.Empty;
                    if (url == "/")
                        url = "/index.html";
                    filePath = $"{_webRootUrl}{url.Substring(1, url.Length - 1)}";


                    if (File.Exists(filePath))
                    {
                        byte[] html = await File.ReadAllBytesAsync(filePath);
                        string type = getType(url);

                        string responseData = "HTTP/1.1 200 OK\r\n" +
                                            "Content-Type: " + type + "\r\n" +
                                            "Content-Length: " + html.Length + "\r\n\r\n";

                        // Header 
                        byte[] responseHeaderBytes = Encoding.ASCII.GetBytes(responseData);

                        // Reponse object 
                        byte[] responseBytes = new byte[responseHeaderBytes.Length + html.Length];

                        // Copying response header to reponse object 
                        Buffer.BlockCopy(responseHeaderBytes, 0, responseBytes, 0, responseHeaderBytes.Length);

                        // Copying actual content to response object 
                        Buffer.BlockCopy(html, 0, responseBytes, responseHeaderBytes.Length, html.Length);

                        stream.Write(responseBytes, 0, responseBytes.Length);

                        return;
                    }

                }
                string notFoundResponse = "HTTP/1.1 404 Not Found\r\n\r\n";
                byte[] notFoundResponseBytes = Encoding.ASCII.GetBytes(notFoundResponse);
                await stream.WriteAsync(notFoundResponseBytes, 0, notFoundResponseBytes.Length);
            }
            catch(Exception ex)
            {
                if (ex is SocketException && (ex as SocketException)?.SocketErrorCode == SocketError.TimedOut)
                {
                    
                   Console.WriteLine("Operation timed out. "+ ex.Message);
                   
                }
                else
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            finally
            {
                client.Close();
            }
        }


        static string getType(string url)
        {
            if (url.EndsWith("html"))
                return "text/html";
            if (url.EndsWith("css"))
                return "text/css";
            if (url.EndsWith("js"))
                return "text/javascript";
            if (url.EndsWith(".jpg") || url.EndsWith(".jpeg"))
                return "image/jpeg";
            if (url.EndsWith(".png"))
                return "image/png";
            if (url.EndsWith(".gif"))
                return "image/gif";
            if (url.EndsWith(".svg"))
                return "image/svg+xml";
            if (url.EndsWith(".ico"))
                return "image/x-icon";
            else
                return "text/plain";
        }

    }

    
}

