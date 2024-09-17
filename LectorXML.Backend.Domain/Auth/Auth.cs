using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Domain.Auth
{
    public class Auth
    {

        public string Login()
        {
            // CREADENCIALES
            return Obtener();
        }
        private string Obtener()
        {
            string RSA_PrivateKey = "RSA_PrivateKey";

            string RSA_PublicKey = "RSA_PublicKey";

            string generarToken = RSA_PrivateKey + RSA_PublicKey;

            return generarToken;
        }
    }
}
