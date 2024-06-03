using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DAO;
using Gimji.DTO;
namespace Gimji.BLL
{
    internal class SignUp_BLL
    {
        SignUpDAO SignUpDAO = new SignUpDAO();  
        public string signUp_BLL(Customer newUser)
        {
            return SignUpDAO.signUp_DAO(newUser);
        }
    }
}
