using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBotApi.Models.Interfaces
{
    public interface IBot
    {
        TelegramBotClient GetClient();
        Task SetWebhook();
    }
}
