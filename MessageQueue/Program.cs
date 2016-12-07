using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue
{
    using System.IO;
    using System.Messaging;

    using Newtonsoft.Json;

    using QueueDomain;

    class Program
    {
        static void Main(string[] args)
        {
            var unsub = new UnsubscribeCommand
                            {
                                EmailAddress = "aaa@qq.com"
                            };
            using (var queue = new MessageQueue(".\\private$\\gary.messagequeue.unsubscribe"))
            {
                //var message = new Message(unsub);
                var message = new Message();
                var jsonBody = JsonConvert.SerializeObject(unsub);
                message.BodyStream = new MemoryStream(Encoding.Default.GetBytes(jsonBody));
                queue.Send(message);
            }
        }
    }
}
