using System.Diagnostics;
using System.Text;

namespace TreasuryChallenge
{
    public class Service
    {
        static string GetCode()
        {
            var stringChars = new char[7];
            var random = new Random();
            int i = 0;

            while (i < stringChars.Length)
            {
                char c = enums.Constants.CHARS[random.Next(enums.Constants.CHARS.Length)];
                if (!stringChars.Contains(c))
                {
                    stringChars[i] = c;
                    i++;
                }
            }

            return new String(stringChars);
        }

        public static async Task WriteCodes()
        {
            Console.WriteLine(enums.Constants.MSG_ENTER);

            int totalLines = int.Parse(Console.ReadLine());

            var timeWatch = Stopwatch.StartNew();

            List<string> Lines = new();

            for (int line = 0; line < totalLines; line++)
            {
                Lines.Add(GetCode());
            }

            Console.WriteLine(string.Format(enums.Constants.MSG_EXITE, Lines.Count));

            byte[] array = Lines.SelectMany(s => Encoding.UTF8.GetBytes(s + Environment.NewLine)).ToArray();

            await using (var fileStream = new FileStream(enums.Constants.FILE_PATH,
                FileMode.Create, FileAccess.Write,
                FileShare.None, 0,
                FileOptions.Asynchronous |
                FileOptions.SequentialScan))
            {
                await fileStream.WriteAsync(array);
            }

            timeWatch.Stop();

            Console.WriteLine(timeWatch.ElapsedMilliseconds);
        }


    }
}
