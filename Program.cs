
namespace Quid
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string q1 = GenerateQuidString("75");
            Console.WriteLine(q1);
            DecodeQuid(q1);

            Console.WriteLine();

            q1 = GenerateQuidString("9");
            Console.WriteLine(q1);
            DecodeQuid(q1);

            Console.WriteLine();

            q1 = GenerateQuidString("999");
            Console.WriteLine(q1);
            DecodeQuid(q1);
        }

        private static string GenerateQuidString(string userId)
        {
            userId = userId.PadLeft(2, '0');
            string hexEpoch = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString("X2");
            string random = Guid.NewGuid().ToString().Split('-')[4];

            string quid = $"555{hexEpoch.Substring(0, 5)}-{hexEpoch.Substring(5, 3)}{userId.Substring(0,1)}-1{userId.Substring(1,1)}00-c000-{random}";
            return quid;
        }

        private static void DecodeQuid(string quid)
        {
            bool isGuid = Guid.TryParse(quid, out Guid g);
            string unformatted = quid.Replace("-", "").Trim();
            string prefix = unformatted.Substring(0, 3);
            string unixEpochHex = unformatted.Substring(3, 8);
            string userId = $"{unformatted.Substring(11, 1)}{unformatted.Substring(13, 1)}";

            long epoch = Convert.ToInt64(unixEpochHex, 16);
            DateTimeOffset epochDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epoch);

            Console.WriteLine($"Is GUID: {isGuid}");
            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"Unix Epoch hex: {unixEpochHex}");
            Console.WriteLine($"Converted to datetime: {epochDateTimeOffset}");
        }
    }
}