using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;

namespace Test_Quest
{
    public class TestFactory
    {              
       
       public static HttpRequest CreateHttpRequest(string multiplicand, string multiplier)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            var dir = new Dictionary<string, StringValues>();
            dir.TryAdd("multiplicand", multiplicand);
            dir.TryAdd("multiplier", multiplier);
            request.Query = new QueryCollection(dir);
            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}
