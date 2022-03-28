using Discord;

namespace Masami.Commands_New
{
    public static class MasamiExtensions
    {
        public static Task ReplyAsync(this IUserMessage message, string text)
            => Discord.MessageExtensions.ReplyAsync(message, text);
    }
}