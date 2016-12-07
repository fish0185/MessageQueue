using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueue.Handler
{
    using System.IO;
    using System.Messaging;

    using Newtonsoft.Json;

    using QueueDomain;

    class Program
    {
        static void Main(string[] args)
        {
            using (var queue = new MessageQueue(".\\private$\\gary.messagequeue.unsubscribe"))
            {
                while (true)
                {
                    Console.WriteLine("Listening");
                    // block the thread until message arrive
                    var message = queue.Receive();
                    var bodyReader = new StreamReader(message.BodyStream);
                    var jsonBody = bodyReader.ReadToEnd();
                    var unsubscribeMessage = JsonConvert.DeserializeObject<UnsubscribeCommand>(jsonBody);
                    // Unscribe service ran
                    Console.WriteLine("unsubscribe success: " + unsubscribeMessage.EmailAddress);
                }
            }
        }
    }
}
