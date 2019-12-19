namespace Demo.App
{
    using System;
    using System.Text;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.WebServer;
    using SIS.WebServer.Routing;
    using SIS.WebServer.Routing.Contracts;

    class Launcher
    {
        static void Main()
        {
            //string request =
            //    "POST /url/abc/?name=dari&id=1#fragment HTTP/1.1\r\n"
            //    + "Authorization: Basic 1111\r\n"
            //    + "Date: " + DateTime.Now + "\r\n"
            //    + "Host: localhost:5000\r\n"
            //    + "\r\n"
            //    + "username=johndoe&password=parola";

            //HttpRequest httpRequest = new HttpRequest(request);

            //HTTP Response Test
            //HttpResponse response = new HttpResponse(HttpResponseStatusCode.InternalServerError);
            //response.Addheader(new HttpHeader ("Post", "localhost:5000"));
            //response.Addheader(new HttpHeader ("Date", DateTime.Now.ToString()));

            //response.Content = Encoding.UTF8.GetBytes("<h1>Hello M@#& F@?@$</h1>");
            //Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes()));


            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController().Index(request));

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
