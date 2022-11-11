using System.Security.Cryptography;
using System.Text;

namespace API_Livros.Helpers
{
    public static class CryptographyHelper //Classes estáticas não são instanciadas
    {
        public static string DoHash(this string password)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(password);

            array = hash.ComputeHash(array);

            var stringHexa = new StringBuilder();

            foreach (var item in array)
            {
                stringHexa.Append(item.ToString("x2"));
            }

            return stringHexa.ToString();
        }
    }
}
