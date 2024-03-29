﻿using EasyNetQ;
using Messages;

string connectionStr =
    "host=hare.rmq.cloudamqp.com;virtualHost=npaprqop;username=npaprqop;password=<type your password here>";

Console.WriteLine("Enter subscriber id:");
string id = Console.ReadLine();

using (var bus = RabbitHutch.CreateBus(connectionStr))
{
    bus.PubSub.Subscribe<TextMessage>("subscriber" + id, HandleTextMessage);

    Console.WriteLine("Listening for messages. Hit <return> to quit.");
    Console.ReadLine();
}

static void HandleTextMessage(TextMessage textMessage)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Got message: {0}", textMessage.Text);
    Console.ResetColor();
}
