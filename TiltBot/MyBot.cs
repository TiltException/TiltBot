using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using RiotApi.Net.RestClient;
using RiotApi.Net.RestClient.Configuration;

namespace TiltBot
{
    class MyBot
    {
        private IRiotClient _riotClient;
        private DiscordClient _client;
        private CommandService _commands;

        public MyBot()
        {
            _client = new DiscordClient(x =>
            {
                x.AppName = "MBot";
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            initializeRiotClient();

            _client.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
                x.HelpMode = HelpMode.Public;
            });

            _client.UserJoined += async (s, e) =>
            {
                var channel = e.Server.FindChannels("general", ChannelType.Text).FirstOrDefault();

                var user = e.User;

                if (channel != null)
                {
                    await channel.SendMessage($"{user} has joined the channel!");
                }
            };

            CreateCommands();

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect("MTk2MTEwNDMxMzUyMjU4NTYx.DCoPOg.YC0YH4qtzlynqoatEb9ppJeedRg", TokenType.Bot);
            });

        }

        public void CreateCommands()
        {
            _commands = _client.GetService<CommandService>();

            _commands.CreateCommand("Alex")
               .Do(async (e) =>
               {
                   await e.Channel.SendTTSMessage("WATCH BOKU NO HERO ACADEMIA ALEX");
                   await e.Channel.SendTTSMessage("WATCH BOKU NO HERO ACADEMIA ALEX");
                   await e.Channel.SendTTSMessage("WATCH BOKU NO HERO ACADEMIA ALEX");
               });
        }

        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] {e.Message}");
        }

        private void initializeRiotClient()
        {
            IRiotClient _riotClient = new RiotClient("RGAPI-d5819e3c-316a-4163-900b-2dab590a0297");
        }
    }
}
