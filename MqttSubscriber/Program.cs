using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttSubscriber
{
    class Program
    {
        static MqttClient client;
        static string clientId;
        static void Main(string[] args)
        {
            Console.WriteLine("Mosquitto subscriber!");
            Subscribe();
        }

        static void Subscribe()
        {

            string BrokerAddress = "127.0.0.1";
            //BrokerAddress = "172.29.7.194";

            client = new MqttClient(BrokerAddress);

            // register a callback-function (we have to implement, see below) which is called by the library when a message was received
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            // use a unique id as client id, each time we start the application
            clientId = Guid.NewGuid().ToString();

            client.Connect(clientId);

            string topic = "test";
            // whole topic
            string Topic = "/ElektorMyJourneyIoT/" + topic + "/test";

            // subscribe to the topic with QoS 2
            client.Subscribe(new string[] { Topic }, new byte[] { 2 });   // we need arrays as parameters because we can subscribe to different topics with one call

        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);

            //Dispatcher.Invoke(delegate {              // we need this construction because the receiving code in the library and the UI with textbox run on different threads
            //    txtReceived.Text = ReceivedMessage;
            //});
            Console.WriteLine("Received: " + ReceivedMessage);
        }
    }
}
