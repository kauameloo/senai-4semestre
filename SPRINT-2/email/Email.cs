using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email
{
    public static class Email
    {
        public static string CriarEmail (string email)
        {
            return email;
        }

        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            bool temArroba = email.Contains("@");
            bool temPonto = email.Contains(".");
            return temArroba && temPonto;
        }
    }
}
