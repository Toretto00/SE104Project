using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emailUser
{
    public class EmailUser
    {
        private string email;
        private string password;

        public EmailUser()
        {
            email = "";
            password = "";
        }
        public EmailUser(EmailUser A)
        {
            email = A.email;
            password = A.password;
        }
        public EmailUser(string x, string y)
        {
            email = x;
            password = y;
        }
        public bool isEmailUser()
        {
            if(email.Contains("@gmail.com"))
            {
                if(email.Substring(email.IndexOf("@gmail.com"))=="@gmail.com")
                    return true;
                else
                    return false;
            }
            return false;
        }
        public bool isPasswordUser()
        {
            if(password.Length<8||password.Length>15)
                return false;
            bool[] flag = {false,false};
            for(int i = 0; i < password.Length; i++)
            {
                if(password[i] >= '0' && password[i]<='9')
                    flag[0] = true;
                else if(password[i] >= 'A' && password[i]<='Z')
                    flag[1] = true;
                //else if ((password[i] >= '!' && password[i]<='/')||(password[i]>=':'&&password[i]<='@')||(password[i]>='['&&password[i]<='`')||(password[i]>='{'&&password[i]<='~'))
                //    flag[2] = true;
            }
            if(flag[0]&&flag[1])
                return true;
            return false;
        }
    }
}
