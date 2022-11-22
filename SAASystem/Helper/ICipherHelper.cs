using System;
using System.Collections.Generic;

namespace SAASystem.Helper
{
    public interface ICipherHelper
    {
        string Encrypt(string input);
        string Decrypt(string cipherText);
    }
}