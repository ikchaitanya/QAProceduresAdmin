using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Jord.ACHEQA.DAL
{
    public static class AppConfiguration
    {
        private static string sKey = "JordInternational38OxleyStreet";
        public static string SelectedServerName = string.Empty;
        public static string ActiveConnection
        {
            get
            {
                //string con = ConfigurationManager.AppSettings["ServerConnection"].ToString();
                string con = SelectedServerName + "Connection";
                if (!string.IsNullOrEmpty(SelectedServerName))
                    return FormatConnectionString(ConfigurationManager.ConnectionStrings[con].ToString());
                else
                    return "";
                //return ConfigurationManager.ConnectionStrings[con].ToString();
            }
        }

        private static string FormatConnectionString(string Constr)
        {
            string returnStr = string.Empty;
            try
            {
                string Param1 = ConfigurationManager.AppSettings["PARAM1"].ToString();
                string Param2 = ConfigurationManager.AppSettings["PARAM2"].ToString();
                string Constr1 = Constr;
                Constr1 = Constr1.Replace("User Id=", "User Id=" + Decrypt(Param1));
                Constr1 = Constr1.Replace("Password=", "Password=" + Decrypt(Param2));
                returnStr = Constr1;

                //string Constr1 = Constr;
                //int UserIDStartIndex;
                //int UserIDEndIndex;
                //int PasswordStartIndex;
                //int PasswordEndIndex;
                //string UserNamePart = string.Empty;
                //string Passwordpart = string.Empty;
                //UserIDStartIndex = Constr1.IndexOf("User Id");
                //UserIDStartIndex += 8;
                //UserIDEndIndex = Constr1.IndexOf(";Password");

                //PasswordStartIndex = Constr1.IndexOf("Password");
                //PasswordStartIndex += 9;
                //PasswordEndIndex = Constr1.IndexOfAny(new char[] { ';' }, PasswordStartIndex);
                ////PasswordEndIndex -= 1;


                //UserNamePart = Constr1.Substring(UserIDStartIndex, (UserIDEndIndex - UserIDStartIndex));
                //Passwordpart = Constr1.Substring(PasswordStartIndex, (PasswordEndIndex - PasswordStartIndex));

                ////UserNamePart = Decrypt(UserNamePart);

                //Constr1 = Constr1.Replace(UserNamePart, Decrypt(UserNamePart));
                //Constr1 = Constr1.Replace(Passwordpart, Decrypt(Passwordpart));
                //returnStr = Constr1;
            }
            catch (Exception ex)
            {

            }
            return returnStr;

        }
        public static string Encrypt(string sPainText)
        {
            if (sPainText.Length == 0)
                return (sPainText);
            return (EncryptString(sPainText, sKey));
        }
        private static string EncryptString(string InputText, string Password)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            return EncryptedData;
        }
        public static string Decrypt(string sEncryptText)
        {
            if (sEncryptText.Length == 0)
                return (sEncryptText);
            return (DecryptString(sEncryptText, sKey));
        }
        private static string DecryptString(string InputText, string Password)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] EncryptedData = Convert.FromBase64String(InputText.Replace(" ", "+"));
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(EncryptedData);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            byte[] PlainText = new byte[EncryptedData.Length];
            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            return DecryptedData;
        }
    }
}
