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
            _botsettings = _configuration.GetSection("BotSettings").Get(typeof(BotSettings)) as BotSettings;
        }

        private TelegramBotClient _client;
        private BotSettings _botsettings;

        public TelegramBotClient GetClient()
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
            string webHookUrl = string.Format(_botsettings.BotUrl + "/{0}", "api/message");
            _client = new TelegramBotClient(_botsettings.BotToken);
            await _client.SetWebhookAsync(webHookUrl);
        }
    }
}
