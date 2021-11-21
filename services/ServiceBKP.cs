//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TreasuryChallenge
//{
//    internal class ServiceBKP
//    {
//        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

//        private static readonly ThreadLocal<Random> _random =
//           new ThreadLocal<Random>(() => new Random());

//        public static unsafe void Do(byte[] array, int index)
//        {
//            var r = _random.Value;
//            fixed (byte* pArray = array)
//            {
//                var pLen = pArray + ((index + 1) * 1000000);
//                int i = 1;
//                for (var p = pArray + (index * 1000000); p < pLen; p++, i++)2
//                    if ((i % 9) == 0) *p = (byte)'\r';
//                    else if ((i % 10) == 0) *p = (byte)'\n';
//                    else *p = (byte)Chars[r.Next(35)];
//            }
//        }

//        public static async Task Main2(string[] args)
//        {
//            var array = new byte[40000000 * (8 + 2)];

//            var sw = Stopwatch.StartNew();
//            Parallel.For(0, 26, (index) => Do(array, index));

//            Console.WriteLine(sw.Elapsed);

//            sw = Stopwatch.StartNew();
//            await using (var fs = new FileStream(@"D:\asdasd.txt", FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, FileOptions.Asynchronous | FileOptions.SequentialScan))await fs.WriteAsync(array, 0, array.Length);
//            Console.WriteLine(sw.Elapsed);
//        }
//    }
//}
