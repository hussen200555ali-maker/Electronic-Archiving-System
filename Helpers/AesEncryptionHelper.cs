
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;


public static class AesEncryptionHelper
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");
    private static readonly CipherMode Mode = CipherMode.CBC;
    private static readonly PaddingMode Padding = PaddingMode.PKCS7;

    public static string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            aesAlg.Mode = Mode;
            aesAlg.Padding = Padding;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }

    public static string Decrypt(string cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            aesAlg.Mode = Mode;
            aesAlg.Padding = Padding;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}

//public static class AesEncryptionHelper
//{
//    private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // 32 bytes
//    private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes

//    public static string Encrypt(string plainText)
//    {
//        using (Aes aesAlg = Aes.Create())
//        {
//            aesAlg.Key = Key;
//            aesAlg.IV = IV;
//            aesAlg.Mode = CipherMode.CBC;
//            aesAlg.Padding = PaddingMode.PKCS7;

//            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

//            using (MemoryStream msEncrypt = new MemoryStream())
//            {
//                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
//                {
//                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
//                    {
//                        swEncrypt.Write(plainText);
//                    }
//                    return Convert.ToBase64String(msEncrypt.ToArray());
//                }
//            }
//        }
//    }

//    public static string Decrypt(string cipherText)
//    {
//        using (Aes aesAlg = Aes.Create())
//        {
//            aesAlg.Key = Key;
//            aesAlg.IV = IV;
//            aesAlg.Mode = CipherMode.CBC;
//            aesAlg.Padding = PaddingMode.PKCS7;

//            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

//            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
//            {
//                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
//                {
//                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
//                    {
//                        return srDecrypt.ReadToEnd();
//                    }
//                }
//            }
//        }
//    }
//}

////// AesEncryptionHelper.cs المعدل
////using System;
////using System.IO;
////using System.Security.Cryptography;
////using System.Text;

////namespace Electronic_Archive.PL
////{
////    public static class AesEncryptionHelper
////    {
////        private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
////        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");

////        public static string Encrypt(string plainText)
////        {
////            using (var aes = Aes.Create())
////            {
////                aes.Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
////                aes.IV = Encoding.UTF8.GetBytes("1234567890123456");
////                aes.Mode = CipherMode.CBC; // التعديل 6: تحديد وضع التشفير
////                aes.Padding = PaddingMode.PKCS7;

////                using (var encryptor = aes.CreateEncryptor())
////                using (var ms = new MemoryStream())
////                {
////                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
////                    using (var sw = new StreamWriter(cs))
////                    {
////                        sw.Write(plainText);
////                    }
////                    return Convert.ToBase64String(ms.ToArray());
////                }
////            }
////        }

////        public static string Decrypt(string cipherText)
////        {
////            using (var aes = Aes.Create())
////            {
////                aes.Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
////                aes.IV = Encoding.UTF8.GetBytes("1234567890123456");
////                aes.Mode = CipherMode.CBC;
////                aes.Padding = PaddingMode.PKCS7;

////                using (var decryptor = aes.CreateDecryptor())
////                using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
////                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
////                using (var sr = new StreamReader(cs))
////                {
////                    return sr.ReadToEnd();
////                }
////            }
////        }
////    }
////}


//////////using System.IO;
//////////using System;
//////////using System.Security.Cryptography;
//////////using System.Text;

//////////namespace Electronic_Archive.PL
//////////{
//////////    public static class AesEncryptionHelper
//////////    {
//////////        // يجب تغيير هذه المفاتيح وحفظها في مكان آمن (يفضل استخدام إدارة الأسرار)
//////////        private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // 32 بايت
//////////        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456"); // 16 بايت

//////////        public static string Encrypt(string plainText)
//////////        {
//////////            using (Aes aesAlg = Aes.Create())
//////////            {
//////////                aesAlg.Key = Key;
//////////                aesAlg.IV = IV;

//////////                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

//////////                using (MemoryStream msEncrypt = new MemoryStream())
//////////                {
//////////                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
//////////                    {
//////////                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
//////////                        {
//////////                            swEncrypt.Write(plainText);
//////////                        }
//////////                        return Convert.ToBase64String(msEncrypt.ToArray());
//////////                    }
//////////                }
//////////            }
//////////        }

//////////        public static string Decrypt(string cipherText)
//////////        {
//////////            using (Aes aesAlg = Aes.Create())
//////////            {
//////////                aesAlg.Key = Key;
//////////                aesAlg.IV = IV;

//////////                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

//////////                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
//////////                {
//////////                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
//////////                    {
//////////                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
//////////                        {
//////////                            return srDecrypt.ReadToEnd();
//////////                        }
//////////                    }
//////////                }
//////////            }
//////////        }
//////////    }
//////////}
