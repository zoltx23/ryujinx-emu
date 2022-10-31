using Discord;
using Discord.WebSocket;
using RyuBot.Modules;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RyuBot
{
    public class Program
    {
        private static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();
        private string key_stat = "ubuntu-x64";

        public async Task StartAsync()
        {
            var key = "<key>";
            _client = new DiscordSocketClient();
            Console.WriteLine("=====================================" +
                "\r\nDr.Hackniks RyujiNX Bot for Discord" +
                "\r\nVersion: 0.1.4" +
                "\r\nBot name: OpenBot" +
                "\r\nBot revision: 18_2_19_729pm" +
                "\r\nBot Type: " + key_stat + " | Web-socket-based" +
                "\r\n=====================================");

            try
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(time + ":: Reading Key file...");
                Console.WriteLine(time + ":: Connecting...");
                await _client.LoginAsync(TokenType.Bot, key);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(time + ":: Key file is valid");
                await _client.StartAsync();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(time + ":: Bot has connected");
                _handler = new CommandHandler(_client);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(time + ":ERROR: Key file is invalid! Or an Internet connection is unavailable." +
                "\r\n" + time + ":ERROR: There was an internal bot error.");
                Console.WriteLine(ex);
                await Task.Delay(-1);
                return;
            }

            await Task.Delay(-1);
        }
    }
}