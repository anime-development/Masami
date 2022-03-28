using MongoDB.Bson.Serialization.Attributes;

namespace Masami.Database
{
    public class SettingsModel
    {
        [BsonId]
        public ulong Id { get; private set; } = 0; // guild id

        public ulong ChannelId { get; set; } = 0; //logs id

        public SettingsModel(ulong guildId)
        {
            Id = guildId;
        }
    }
}