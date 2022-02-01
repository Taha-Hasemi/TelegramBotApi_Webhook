using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBotApi.Models
{
    public class Bot
    {
        readonly IConfiguration _configuration;

        public Bot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static TelegramBotClient _client;
        private static BotSettings _botsettings;

        public static TelegramBotClient GetClient()
        {
            if (_client != null)
            {
                return _client;
            }
            _client = new TelegramBotClient(_botsettings.BotToken);
            return _client;
        }

        public async Task SetWebhook()
        {
            _botsettings = _configuration.GetSection("BotSettings").Get(typeof(BotSettings)) as BotSettings;
            string webHookUrl = string.Format(_botsettings.BotUrl + "/{0}", "api/message");
            _client = new TelegramBotClient(_botsettings.BotToken);
            await _client.SetWebhookAsync(webHookUrl);
        }
    }
}
