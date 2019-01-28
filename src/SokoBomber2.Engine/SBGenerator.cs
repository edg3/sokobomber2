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
				var j = (int)array[i];
				string c = "";
				switch (j)
				{
					case 0:
					case 1:
						c = "a";
						break;
					case 2:
					case 3:
						c = "b";
						break;
					case 4:
					case 5:
						c = "c";
						break;
					case 6:
					case 7:
						c = "d";
						break;
					case 8:
					case 9:
						c = "e";
						break;
					case 10:
					case 11:
						c = "f";
						break;
					case 12:
					case 13:
						c = "g";
						break;
					case 14:
					case 15:
						c = "h";
						break;
					case 16:
					case 17:
						c = "i";
						break;
					case 18:
					case 19:
						c = "j";
						break;
					case 20:
					case 21:
						c = "k";
						break;
					case 22:
					case 23:
						c = "l";
						break;
					case 24:
					case 25:
						c = "m";
						break;
					case 26:
					case 27:
						c = "n";
						break;
					case 28:
					case 29:
						c = "o";
						break;
					case 30:
					case 31:
						c = "p";
						break;
					case 32:
					case 33:
						c = "q";
						break;
					case 34:
					case 35:
						c = "r";
						break;
					case 36:
					case 37:
						c = "s";
						break;
					case 38:
					case 39:
						c = "t";
						break;
					case 40:
					case 41:
						c = "u";
						break;
					case 42:
					case 43:
						c = "v";
						break;
					case 44:
					case 45:
						c = "q";
						break;
					case 46:
					case 47:
						c = "r";
						break;
					case 48:
					case 49:
						c = "s";
						break;
					case 50:
					case 51:
						c = "t";
						break;
					case 52:
					case 53:
						c = "u";
						break;
					case 54:
					case 55:
						c = "v";
						break;
					case 56:
					case 57:
						c = "w";
						break;
					case 58:
					case 59:
						c = "x";
						break;
					case 60:
					case 61:
						c = "y";
						break;
					case 62:
					case 63:
						c = "z";
						break;
					case 64:
					case 65:
						c = "A";
						break;
					case 66:
					case 67:
						c = "B";
						break;
					case 68:
					case 69:
						c = "C";
						break;
					case 70:
					case 71:
						c = "D";
						break;
					case 72:
					case 73:
						c = "E";
						break;
					case 74:
					case 75:
						c = "F";
						break;
					case 76:
					case 77:
						c = "G";
						break;
					case 78:
					case 79:
						c = "H";
						break;
					case 80:
					case 81:
						c = "I";
						break;
					case 82:
					case 83:
						c = "J";
						break;
					case 84:
					case 85:
						c = "K";
						break;
					case 86:
					case 87:
						c = "L";
						break;
					case 88:
					case 89:
						c = "M";
						break;
					case 90:
					case 91:
						c = "N";
						break;
					case 92:
					case 93:
						c = "O";
						break;
					case 94:
					case 95:
						c = "P";
						break;
					case 96:
					case 97:
						c = "Q";
						break;
					case 98:
					case 99:
						c = "R";
						break;
					case 100:
					case 101:
						c = "S";
						break;
					case 102:
					case 103:
						c = "T";
						break;
					case 104:
					case 105:
						c = "U";
						break;
					case 106:
					case 107:
						c = "V";
						break;
					case 108:
					case 109:
						c = "W";
						break;
					case 110:
					case 111:
						c = "X";
						break;
					case 112:
					case 113:
						c = "Y";
						break;
					case 114:
					case 115:
						c = "Z";
						break;
					// Numbers? Chars?
					default:
						c = "";
						break;
				}

				answer += c;
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
