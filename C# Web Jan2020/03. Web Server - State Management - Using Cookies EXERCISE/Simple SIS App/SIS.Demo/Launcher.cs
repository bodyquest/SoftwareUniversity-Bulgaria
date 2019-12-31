namespace SIS.Demo
{
    using SIS.Data;
    using SIS.WebServer;
    using SIS.HTTP.Enums;
    using SIS.Demo.Controllers;
    using SIS.WebServer.Routing;
    using SIS.WebServer.Routing.Contracts;

    public class Launcher
    {
        public static void Main()
        {
            /*string request =
                "POST /url/abc/?name=dari&id=1#fragment HTTP/1.1\r\n"
                + "Authorization: Basic 1111\r\n"
                + "Date: " + DateTime.Now + "\r\n"
                + "Host: localhost:5000\r\n"
                + "\r\n"
                + "username=johndoe&password=parola";

            HttpRequest httpRequest = new HttpRequest(request);

            HTTP Response Test
            HttpResponse response = new HttpResponse(HttpResponseStatusCode.InternalServerError);
            response.Addheader(new HttpHeader("Post", "localhost:5000"));
            response.Addheader(new HttpHeader("Date", DateTime.Now.ToString()));

            response.Content = Encoding.UTF8.GetBytes("<h1>Hello M@#& F@?@$</h1>");
            Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes())); */

            using (var context = new DemoDbContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

                IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            /*[GET] Mappings*/

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController(request).Index(request));
            serverRoutingTable.Add(HttpRequestMethod.Get, "/home", request => new HomeController(request).Home(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, "/login", request => new UsersController().Login(request));
            serverRoutingTable.Add(HttpRequestMethod.Get, "/logout", request => new UsersController().Logout(request));
            serverRoutingTable.Add(HttpRequestMethod.Get, "/register", request => new UsersController().Register(request));


            /*[POST] Mappings*/
            serverRoutingTable.Add(HttpRequestMethod.Post, "/login", request => new UsersController().LoginConfirm(request));

            serverRoutingTable.Add(HttpRequestMethod.Post, "/register", request => new UsersController().RegisterConfirm(request));

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
