using System;
using System.Collections.Generic;


namespace Flyweight
{
    abstract class Broadcast
    {
        public string BroadcastTitle { get; protected set; }

        public abstract void StartBroadcast(int channel, int hour, int minutes);
    }

    class FootballWorldCup2002Broadcast : Broadcast
    {
        public FootballWorldCup2002Broadcast()
        {
            BroadcastTitle = "Трансляция чемпионата мира по футболу 2002";
        }

        public override void StartBroadcast(int channel, int hour, int minutes)
        {
            Console.WriteLine($"{BroadcastTitle} началась на {channel} канале в {hour}:{minutes}{minutes}");
        }
    }

    class HockeyWorldCup2002Broadcast : Broadcast
    {
        public HockeyWorldCup2002Broadcast()
        {
            BroadcastTitle = "Трансляция чемпионата мира по хоккею 2002";
        }

        public override void StartBroadcast(int channel, int hour, int minutes)
        {
            Console.WriteLine($"{BroadcastTitle} началась на {channel} канале в {hour}:{minutes}{minutes}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Broadcast> broadcasts =  new Dictionary<string, Broadcast>()
            {
                { "FootballCup2002",  new FootballWorldCup2002Broadcast() },
                { "HockeyCup2002",  new HockeyWorldCup2002Broadcast() },
            };

            Broadcast TV1FootballBroadcast = broadcasts["FootballCup2002"];
            Broadcast TV1HockeyBroadcast = broadcasts["HockeyCup2002"];

            Broadcast TV2FootballBroadcast = broadcasts["FootballCup2002"];
            Broadcast TV2HockeyBroadcast = broadcasts["HockeyCup2002"];

            TV1FootballBroadcast.StartBroadcast(1, 18, 00);
            TV1HockeyBroadcast.StartBroadcast(1, 20, 00);

            TV2FootballBroadcast.StartBroadcast(2, 20, 00);
            TV2HockeyBroadcast.StartBroadcast(2, 22, 00);

            Console.ReadKey();
        }
    }
}