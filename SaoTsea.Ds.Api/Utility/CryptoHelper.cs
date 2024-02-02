using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SaoTsea.Ds.Api.Utility
{
	public static class CryptoHelper
	{
		public static string CreateRandomString(int number)
		{
			var chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
			var stringChars1 = new char[number];
			var random1 = new Random();

			for (int i = 0; i < stringChars1.Length; i++)
			{
				stringChars1[i] = chars1[random1.Next(chars1.Length)];
			}

			return new string(stringChars1);
		}

		public static string CreateSha256(string data)
		{
			StringBuilder Sb = new StringBuilder();

			using (var hash = SHA256.Create())            
			{
				Encoding enc = Encoding.UTF8;
				byte[] result = hash.ComputeHash(enc.GetBytes(data));

				foreach (byte b in result)
					Sb.Append(b.ToString("x2"));
			}

			return Sb.ToString();
		}

		public static string EncryptString(string text, string key)
		{
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
			{
				return text;
			}

			var k = Encoding.UTF8.GetBytes(key);
			using (var aesAlg = Aes.Create())
			{
				using (var encryptor = aesAlg.CreateEncryptor(k, aesAlg.IV))
				{
					using (var msEncrypt = new MemoryStream())
					{
						using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
						{
							using (var swEncrypt = new StreamWriter(csEncrypt))
							{
								swEncrypt.Write(text);
							}
						}

						var iv = aesAlg.IV;

						var decryptedContent = msEncrypt.ToArray();

						var result = new byte[iv.Length + decryptedContent.Length];

						Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
						Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

						return Convert.ToBase64String(result);
					}
				}
			}
		}

		public static string DecryptString(string cipherText, string key)
		{
			if (string.IsNullOrEmpty(cipherText) || string.IsNullOrEmpty(key))
			{
				return cipherText;
			}


			var fullCipher = Convert.FromBase64String(cipherText);

			var iv = new byte[16];
			var cipher = new byte[fullCipher.Length - iv.Length];

			Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
			Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length);
			var k = Encoding.UTF8.GetBytes(key);

			using (var aesAlg = Aes.Create())
			{
				using (var decryptor = aesAlg.CreateDecryptor(k, iv))
				{
					string result;
					using (var msDecrypt = new MemoryStream(cipher))
					{
						using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
						{
							using (var srDecrypt = new StreamReader(csDecrypt))
							{
								result = srDecrypt.ReadToEnd();
							}
						}
					}

					return result;
				}
			}
		}
	}
}
