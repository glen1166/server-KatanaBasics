using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinMiddleWare
{
    public class LoggerMiddleware : OwinMiddleware
    {
        public LoggerMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            PathString tickPath = new PathString("/tick");
            if (context.Request.Path.StartsWithSegments(tickPath))
            {
                string content = DateTime.Now.ToString();
                context.Response.ContentType = "text/plain";
                context.Response.ContentLength = content.Length;
                context.Response.StatusCode = 200;
                context.Response.Expires = DateTimeOffset.Now;
                context.Response.Write(content);
                return Task.FromResult(0);
            }

            return Next.Invoke(context);

        }
    }
}
