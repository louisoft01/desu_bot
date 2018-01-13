using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.Reflection;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;



namespace desubot
{
    public class Program        
    { 
     

        private static DiscordSocketClient _client;

        public static object Context { get; private set; }

        public static async Task Main(string[] args)
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;
            // creates logs
            _client.MessageReceived += MessageReceivedAsync;
            // does some command shit



            string token = ""; //token goes here
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);

        }

        private static async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
            {
                if (message.Content == "!alex")
                    await message.Channel.SendMessageAsync("alex is a stupid nigger");
            }
            {
                if (message.Content == "!desu")
                    await message.Channel.SendMessageAsync("desu desu desu! https://youtu.be/60mLvBWOMb4");
            }
            {
                if (message.Content == "!bored")
                    await message.Channel.SendMessageAsync("https://louisoft01.com/images/waifu.jpg");
            }
            {
                if (message.Content == "!meme")
                    await message.Channel.SendMessageAsync("https://louisoft01.com/images/egg.jpg");
            }
            {
                if (message.Content == "!help")
                    await message.Channel.SendMessageAsync("Commands: `!ping !alex !desu !bored !meme !monika !kotori !waifu`");
            }
            {
                if (message.Content == "trap")
                    await message.Channel.SendMessageAsync("https://i.imgur.com/yGL8vL5.png");
            }
            {
                if (message.Content == "gentoo")
                    await message.Channel.SendMessageAsync("<gentoo");
            }
            {
                if (message.Content == "waifu")
                    await message.Channel.SendMessageAsync("karen is waifu");
            }
            {
                if (message.Content == "!kotori")
                    await message.Channel.SendMessageAsync("kotori is second girl");
            }
            {
                if (message.Content == "!monika")
                    await message.Channel.SendMessageAsync("Just monika");
                await message.Channel.SendMessageAsync("https://i.imgur.com/1dz3yOR.png");
            }
            {
                if (message.Content == "!server")
                {
                    using (var process = Process.GetCurrentProcess())
                    {
                        /*this is required for up time*/
                        var embed = new EmbedBuilder();
                        var application = await Context.Client.GetApplicationInfoAsync(); /*for lib version*/
                        embed.ImageUrl = application.IconUrl; /*pulls bot Avatar. Not needed can be removed*/
                        embed.WithColor(new Color(0x4900ff)) /*Hexacode colours*/

                        .AddField(y =>
                        {
            /*new embed field*/
                            y.Name = "Author.";  /*Field name here*/
                            y.Value = application.Owner.Username; application.Owner.Id.ToString(); /*Code here. If INT convert to string*/
                            y.IsInline = false;
                        })
                        .AddField(y =>  /* add new field, rinse and repeat*/
                        {
                            y.Name = "Uptime.";
                            var time = DateTime.Now - process.StartTime; /* Subtracts current time and start time to get Uptime*/
                            var sb = new StringBuilder();
                            if (time.Days > 0)
                            {
                                sb.Append($"{time.Days}d ");
                            }
                            if (time.Hours > 0)
                            {
                                sb.Append($"{time.Hours}h ");
                            }
                            if (time.Minutes > 0)
                            {
                                sb.Append($"{time.Minutes}m ");
                            }
                            sb.Append($"{time.Seconds}s ");
                            y.Value = sb.ToString();
                            y.IsInline = true;
                        })
                        .AddField(y =>
                        {
                            y.Name = "Discord.net version."; /*pulls discord lib version*/
                            y.Value = DiscordConfig.Version;
                            y.IsInline = true;
                        }).AddField(y =>
                        {
                            y.Name = "Server Amount.";
                            y.Value = (Context.Client as DiscordSocketClient).Guilds.Count.ToString(); /*Numbers of servers the bot is in*/
                            y.IsInline = false;
                        })
                        .AddField(y =>
                        {
                            y.Name = "Heap Size"; /*pulls ram usage of modules/heaps*/
                            y.Value = GetHeapSize();
                            y.IsInline = false;
                        })
                        .AddField(y =>
                        {
                            y.Name = "Number Of Users";
                            y.Value = (Context.Client as DiscordSocketClient).Guilds.Sum(g => g.Users.Count).ToString(); /*Counts users*/
                            y.IsInline = false;
                        })
                        .AddField(y =>
                        {
                            y.Name = "Channels";
                            y.Value = (Context.Client as DiscordSocketClient).Guilds.Sum(g => g.Channels.Count).ToString();
                            y.IsInline = false;
                        });
                        await this.ReplyAsync("", embed: embed);
                    }
                }
            }

        }
 

private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
