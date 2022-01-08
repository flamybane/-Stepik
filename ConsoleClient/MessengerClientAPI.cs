using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Stepik
{
    class MessengerClientAPI
    {
        public void TestNewtonsoftJson()
        {
            //Тест Json SerializeObject NewtonSoft
            Message msg = new Message("RusAl", "Privet", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);
            //srting path = @"d:\temp\ser.txt";
            //using 
        }

        public Message GetMessage(int MessageId)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messanger/1");
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;
            //Console.WriteLine(status);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            //Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            if((status.ToLower() == "ok") && (responseFromServer != "Not found"))
            {
                Message deserializedMsg = JsonConvert.DeserializeObject<Message>(response);
                //Console.WriteLine(deserializedMsg);
                return deserializedMsg;
            }
            return null;
        }
    }
}
