using Microsoft.AspNetCore.DataProtection;

namespace SAASystem.Helper
{
    public class CipherHelper : ICipherHelper
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string Key = "Gayan100638182K%Y";
        public CipherHelper(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }
        public string Decrypt(string cipherText)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(cipherText);
        }
        public string Encrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }
    }
}