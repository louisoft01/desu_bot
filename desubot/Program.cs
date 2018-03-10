using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;



namespace desubot
{
    public class Program
    {

        private static DiscordSocketClient _client;
        private static string print;

        public static async Task Main(string[] args)
        {
            _client = new DiscordSocketClient();

            _client.Log += _client_Log;
            // creates logs
            _client.MessageReceived += MessageReceivedAsync;
            // does some command shit

            string token = ""; //token goes here
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private static Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        private static async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Content == "£ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }

            if (message.Content == "£alex")
                await message.Channel.SendMessageAsync("alex is a stupid nigger");


            if (message.Content == "£desu")
                await message.Channel.SendMessageAsync("desu desu desu! https://youtu.be/60mLvBWOMb4");


            if (message.Content == "£bored")
                await message.Channel.SendMessageAsync("https://louisoft01.com/images/waifu.jpg");


            if (message.Content == "£meme")
                await message.Channel.SendMessageAsync("https://louisoft01.com/images/egg.jpg");


            if (message.Content == "£help")
                await message.Channel.SendMessageAsync("Commands: `£ping £alex £desu £bored £meme £monika £kotori £waifu £^ ~~£server~~ £about`");


            if (message.Content.ToLowerInvariant().Contains("£trap"))
                await message.Channel.SendMessageAsync("https://i.imgur.com/yGL8vL5.png");

            if (message.Content.ToLowerInvariant().Contains("£gay"))
                await message.Channel.SendMessageAsync("https://louisoft01.com/logs/stopbeingabich/yag.jpg");


            if (message.Content == "£^")
                await message.Channel.SendMessageAsync("good point desu");


            if (message.Content == "£waifu")
                await message.Channel.SendMessageAsync("karen is waifu");


            if (message.Content == "£kotori")
                await message.Channel.SendMessageAsync("kotori is second girl");


            if (message.Content == "£monika")
                await message.Channel.SendMessageAsync("Just monika");


            if (message.Content == "£trash")
                await message.Channel.SendMessageAsync("Nico http://decaf.kouhi.me/lovelive/images/archive/4/42/20160706031910%21Nico_smile_r438.jpg");

            if (message.Content == "£about")
                await message.Channel.SendMessageAsync("Desu Bot Alpha Created By Louisoft01 https://louisoft01.com");

        }
    }
}
