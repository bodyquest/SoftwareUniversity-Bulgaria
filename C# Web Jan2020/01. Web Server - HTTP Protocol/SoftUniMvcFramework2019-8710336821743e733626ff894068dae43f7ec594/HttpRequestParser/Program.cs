using System;
using System.Text;
using System.Linq;
using System.Buffers;
using System.Collections.Generic;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

public class Program : IHttpRequestLineHandler, IHttpHeadersHandler
{
    public static void Main()
    {
        const string newLine = "\r\n";

        string requestString =
        "POST /resource/?query_id=0 HTTP/1.1" + newLine +
        "Host: localhost" + newLine +
        "User-Agent: custom" + newLine +
        "Accept: */*" + newLine +
        "Connection: close" + newLine +
        "Content-Length: 20" + newLine +
        "Content-Type: application/json" + newLine +

        "key1=value&key2=value2&key3=value3";

        byte[] requestRaw = Encoding.UTF8.GetBytes(requestString);
        ReadOnlySequence<byte> buffer = new ReadOnlySequence<byte>(requestRaw);

        HttpParser<Program> parser = new HttpParser<Program>();
        Program app = new Program();

        Console.WriteLine("Start line:");

        parser.ParseRequestLine(app, buffer, out var consumed, out var examined);
        buffer = buffer.Slice(consumed);

        Console.WriteLine("\r\nHeaders:");

        parser.ParseHeaders(app, buffer, out consumed, out examined, out var b);
        buffer = buffer.Slice(consumed);

        Console.WriteLine("\r\nBody:");

        string body = Encoding.UTF8.GetString(buffer.ToArray());
        string[] kvpArray = body.Split('&').ToArray();

        Dictionary<string, string> bodyKvps = new Dictionary<string, string>();
        #region Deserialize JSON body
        //Dictionary<string, int> bodyObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, int>>(body);
        #endregion

        foreach (var item in kvpArray)
        { 
            string[] kvp = item.Split('=').ToArray();
            string key = kvp[0];
            string value = kvp[1];
            bodyKvps[key] = value;
            Console.WriteLine($"key: {key}, value: {value}");
        }

        Console.ReadKey();
    }

    public void OnHeader(Span<byte> name, Span<byte> value)
    {
        Console.WriteLine($"{Encoding.UTF8.GetString(name)}: {Encoding.UTF8.GetString(value)}");
    }

    public void OnStartLine(HttpMethod method, HttpVersion version, Span<byte> target, Span<byte> path, Span<byte> query, Span<byte> customMethod, bool pathEncoded)
    {
        Console.WriteLine($"method: {method}");
        Console.WriteLine($"version: {version}");
        Console.WriteLine($"target: {Encoding.UTF8.GetString(target)}");
        Console.WriteLine($"path: {Encoding.UTF8.GetString(path)}");
        Console.WriteLine($"query: {Encoding.UTF8.GetString(query)}");
        Console.WriteLine($"customMethod: {Encoding.UTF8.GetString(customMethod)}");
        Console.WriteLine($"pathEncoded: {pathEncoded}");
    }
}