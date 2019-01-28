using System;
using System.IO;
using System.Security.Cryptography;

namespace SokoBomber2.Engine
{
    /// <summary>
    /// Documentation: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rijndaelmanaged?redirectedfrom=MSDN&view=netframework-4.7.2
    ///  - building the key generation from scratch like I want to
    /// </summary>
	public class SBGenerator
	{
		public string SeedGen(string _in)
		{
			string answer = "";
			var msEncrypt = new MemoryStream();
			using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, _encryptor, CryptoStreamMode.Write))
			{
				using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
				{
					swEncrypt.Write(_in);
				}
			}

			var array = msEncrypt.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                answer += ((char)array[i]).ToString();
            }

			return answer;
		}

		private RijndaelManaged _rijndaelManaged;
		private ICryptoTransform _encryptor;
		public SBGenerator()
		{
			// Create Rijandael instance
			_rijndaelManaged = new RijndaelManaged();
			_rijndaelManaged.Key = new Byte[32] {
				37, 161, 152, 35, 68, 12,
				126, 213, 16, 101, 97, 72,
				10, 87, 187, 162, 233, 81,
				38, 27, 48, 1, 231, 4,
				8, 28, 128, 56, 74, 127,
				1, 191
			};
			_rijndaelManaged.IV = new byte[16] {
				92, 21, 83, 173, 211,
				1, 99, 103, 127, 164,
				29, 9, 63, 74, 200,
				171
			};
			_encryptor = _rijndaelManaged.CreateEncryptor(_rijndaelManaged.Key, _rijndaelManaged.IV);
		}
	}
}
