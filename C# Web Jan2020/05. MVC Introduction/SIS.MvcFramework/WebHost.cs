namespace SIS.MvcFramework
{
    using System;
    using System.Linq;
    using System.Reflection;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Routing;
    using SIS.MvcFramework.Sessions;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Attributes.Security;

    public static class WebHost
    {
        public static void Start(IMvcApplication application) 
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            IHttpSessionStorage sessiontorage = new HttpSessionStorage();

            AutoRegisterRoutes(application, serverRoutingTable);
            application.ConfigureServices();

            application.Configure(serverRoutingTable);

            Server server = new Server(8000, serverRoutingTable, sessiontorage);
            server.Run();
        }

        private static void AutoRegisterRoutes(IMvcApplication application, IServerRoutingTable serverRoutingTable)
        {
            var controllers =
            application.GetType().Assembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && typeof(Controller).IsAssignableFrom(type));

            foreach (var controllerType in controllers)
            {
                //TODO: Remove ToString from Info Controller
                var actions = controllerType
                    .GetMethods(BindingFlags.DeclaredOnly
                    | BindingFlags.Public
                    | BindingFlags.Instance)
                    .Where(x => !x.IsSpecialName && x.DeclaringType == controllerType)
                    .Where(x => x.GetCustomAttributes().All(a => a.GetType() != typeof(NonActionAttribute)));

                foreach (var action in actions)
                {
                    string path = $"/{controllerType.Name.Replace("Controller", string.Empty)}/{action.Name}";

                    var attribute = action.GetCustomAttributes()
                        .Where(x=> x.GetType().IsSubclassOf(typeof(BaseHttpAttribute))).LastOrDefault() as BaseHttpAttribute;

                    var httpMethod = HttpRequestMethod.Get;
                    if (attribute != null)
                    {
                        httpMethod = attribute.Method;
                    }

                    if (attribute?.Url != null)
                    {
                        path = attribute.Url;
                    }

                    if (attribute?.ActionName != null)
                    {
                        path = $"/{controllerType.Name.Replace("Controller", string.Empty)}/{attribute.ActionName}";
                    }

                    serverRoutingTable.Add(httpMethod, path, request => 
                    {
                        var controllerInstance = Activator.CreateInstance(controllerType);
                        ((Controller)controllerInstance).Request = request;
                        var controllerPrincipal = ((Controller)controllerInstance).User;

                        //Security Authorization TODO: refactor this
                        var authorizeAttribute = action.GetCustomAttributes().LastOrDefault(a => a.GetType() == typeof(AuthorizeAttribute)) as AuthorizeAttribute;

                        if (authorizeAttribute != null && !authorizeAttribute.IsInAuthority(controllerPrincipal))
                        {
                            //TODO: redirect to configured Url
                            return new HttpResponse(HttpResponseStatusCode.Forbidden);
                        }

                        var response = action.Invoke(controllerInstance, new object[0]) as ActionResult;

                        return response;
                    });
                }
            }
        }
    }
}
