using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeCadastroDeLivros.Helper
{
    public static class Criptografia
    {
        public static string GerarRash(this string valor)
        {
            var hash = SHA1.Create();
            var enconding = new ASCIIEncoding();
            var array = enconding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach(var item in array)
            {
                strHexa.Append(item.ToString("x2"));

            }

            return strHexa.ToString();
        }
    }
}
