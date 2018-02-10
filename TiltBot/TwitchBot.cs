using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;



namespace TiltBot
{
    class TwitchBot
    {
        private readonly ConnectionCredentials twitchCredentials;
        private TwitchClient twitchClient;

        public TwitchBot()
        {
            twitchCredentials = new ConnectionCredentials(TwitchInfo.BotUsername, TwitchInfo.BotToken);
            twitchClient = new TwitchClient(twitchCredentials, TwitchInfo.ChannelName);

            twitchClient.OnConnected += TwitchClient_OnConnected;
            twitchClient.OnConnectionError += TwitchClient_OnConnectionError;
            twitchClient.OnChatCommandReceived += TwitchClient_OnChatCommandReceived;
        }

        public void Connect()
        {
            twitchClient.Connect();
        }
#region events
        private void TwitchClient_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"Error. {e.Error}");
        }

        private void TwitchClient_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine("Connected successfully.");
            twitchClient.SendMessage("Hi, I am a bot connected via TwitchLib!");
        }

        private void TwitchClient_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            if (e.Command.CommandText == "hi")
                twitchClient.SendMessage($"Salutations, {e.Command.ChatMessage.DisplayName}");
        }
        #endregion
    }
}
