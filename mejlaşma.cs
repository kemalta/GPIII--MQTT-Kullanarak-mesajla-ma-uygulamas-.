using System;
using System.Text;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

class Program
{
    static async Task Main(string[] args)
    {
        var factory = new MqttFactory();
        var mqttClient = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("78.191.87.126")
            .Build();

        await mqttClient.ConnectAsync(options);

        Console.Write("Enter the message: ");
        string message = Console.ReadLine();

        var mqttApplicationMessage = new MqttApplicationMessageBuilder()
            .WithTopic("mytopic")
            .WithPayload(message)
            .WithAtLeastOnceQoS()
            .WithRetainFlag(false)
            .Build();

        await mqttClient.PublishAsync(mqttApplicationMessage);

        Console.WriteLine("Message sent successfully!");

        await mqttClient.DisconnectAsync();
    }
}
