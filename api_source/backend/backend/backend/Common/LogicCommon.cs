using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Common
{
    public class LogicCommon
    {
        public string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = characters[random.Next(characters.Length)];
            }

            return new string(result);
        }

    }
}