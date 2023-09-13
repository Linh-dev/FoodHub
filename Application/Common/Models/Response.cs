using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;
public class Response
{
    public Response() { }
    internal Response(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }
    internal Response(bool succeeded, string message)
    {
        Succeeded = succeeded;
        Message = message;
    }
    public bool Succeeded { get; set; } = true;
    public string? Message { get; set; } = default!;
    public string[] Errors { get; set; } = Array.Empty<string>();

    public static Response Success()
    {
        return new Response(true, Array.Empty<string>());
    }
    public static Response Failure(IEnumerable<string> errors)
    {
        return new Response(false, errors);
    }
}
public class Response<T> : Response
{
    internal Response(bool succeeded, IEnumerable<string> errors) : base(succeeded, errors)
    {
    }
    internal Response(bool succeeded, string message) : base(succeeded, message)
    {
    }
    public static Response<T> Success(T data)
    {
        var r = new Response<T>(true, Array.Empty<string>());
        r.Data = data;
        return r;
    }

    public static Response<T> Failure(IEnumerable<string> errors)
    {
        return new Response<T>(false, errors);
    }

    public T Data { get; set; }
}