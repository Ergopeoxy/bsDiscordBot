using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Logging;

namespace JustAFuckingTest.classes
{
    public class Bot
    {
        public DiscordClient client { get; private set; }
        public CommandsNextExtension commands { get; private set; }
        public async Task RunAsync()
        {
            var jsonstring = string.Empty;
            //reading json file
            using (var fs = File.OpenRead("./config.json"))
            using (var st = new StreamReader(fs, new UTF8Encoding(false)))
                jsonstring = await st.ReadToEndAsync().ConfigureAwait(false);
            var configJson = JsonConvert.DeserializeObject<ConfigJson>(jsonstring);


            var config = new DiscordConfiguration
            {
                Token = configJson.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
             

            };
            
            client = new DiscordClient(config);
            client.Ready += OnClientReady;

            var commandConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.prefix },
                DmHelp = true,
                EnableMentionPrefix= true,
                EnableDms = true,
                EnableDefaultHelp = true,
                   

            };
            commands = client.UseCommandsNext(commandConfig);
            await client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;

        }
    }
}
