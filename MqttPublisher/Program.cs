﻿using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace MqttPublisher
{
    class Program
    {
        static MqttClient client;
        static string clientId;
        static void Main(string[] args)
        {
            Console.WriteLine("Mosquitto publisher!");
            Publish();
            //Console.ReadKey();
            //while (true)
            //{
            //    string formattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    Console.WriteLine(formattedDate);
            //    System.Threading.Thread.Sleep(1000);
            //}
        }

        static void Publish()
        {

            string BrokerAddress = "127.0.0.1";
            BrokerAddress = "172.29.7.194";
            //BrokerAddress = "172.30.83.109";
            //client = new MqttClient(BrokerAddress, 1883, secure: false, null, null, MqttSslProtocols.None);
            client = new MqttClient("mosquitto-myproject.142.35.12.133.nip.io");


            // use a unique id as client id, each time we start the application
            clientId = Guid.NewGuid().ToString();
            Console.WriteLine("Start to connect...");
            client.Connect(clientId);
            Console.WriteLine("End to connect...");
            while (true)
            {
                string topic = "test";
                string formattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string txtPublishText = formattedDate;
                // whole topic
                string Topic = "/ElektorMyJourneyIoT/" + topic + "/test";

                // publish a message with QoS 2
                client.Publish(Topic, Encoding.UTF8.GetBytes(txtPublishText), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                Console.WriteLine("Publishied: " + txtPublishText);
                System.Threading.Thread.Sleep(1000);

            }
            
        }


    }
}
