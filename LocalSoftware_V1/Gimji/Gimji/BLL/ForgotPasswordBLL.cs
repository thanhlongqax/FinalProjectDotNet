using Gimji.DAO;
using Gimji.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.BLL
{
    internal class ForgotPasswordBLL
    {
        ForgotPasswordDAO forgotPasswordDAO = new ForgotPasswordDAO();
        public String checkGmailBLL(String gmail)
        {
            return forgotPasswordDAO.checkGmail_Database(gmail) ;
        }
    }
}
