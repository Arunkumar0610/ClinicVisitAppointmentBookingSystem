using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
 using System;
namespace DataAccessLayer
{


    public class CustomDateSerializer : SerializerBase<DateTime>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        {
            context.Writer.WriteString(value.ToString("MM/dd/yyyy"));
        }



        public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            if (context.Reader.CurrentBsonType == BsonType.String)
            {
                string dateStr = context.Reader.ReadString();
                if (DateTime.TryParseExact(dateStr, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
                {
                    return dateTime;
                }
            }
            throw new FormatException("Invalid date format");
        }
    }
}
