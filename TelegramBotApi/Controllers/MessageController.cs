using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApi.Models;
using TelegramBotApi.Models.Interfaces;

namespace TelegramBotApi.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IBot _bot;

        public MessageController(IBot bot)
        {
            _bot = bot;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            TelegramBotClient client = _bot.GetClient();
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                await client.SendTextMessageAsync(update.Message.From.Id, "Mesaj alındı");
            }

            return Ok();
        }
    }
}
