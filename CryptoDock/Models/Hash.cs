using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDock.Models
{
    public static class Hash
    {
        public static IDictionary<string, string> ToMd5(this IEnumerable<string> texts)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var stringAndHash = new ConcurrentDictionary<string, string>();
                // Convert the input string to a byte array and compute the hash.
                Parallel.ForEach(texts, (input) =>
                {
                    string hash = CreateMd5Hash(input, md5Hash);
                    stringAndHash.TryAdd(input, hash);
                });
                return stringAndHash.ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public static string ToMd5(this string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return CreateMd5Hash(input, md5Hash);
            }
        }

        private static string CreateMd5Hash(string input, MD5 md5Hash)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            var hash = sBuilder.ToString();
            return hash;
        }
    }
}
