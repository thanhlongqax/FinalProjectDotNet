using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimji.DAO;
using Gimji.DTO;

namespace Gimji.BLL
{
    internal class LoginBLL
    {
        LoginDAO loginDao = new LoginDAO();
        public bool isValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public string checkLoginData_Login_BLL(Customer tk)
        {
            return loginDao.LoginDAO_checkLoginData(tk);
        }
        /*
        public string signUp_Login_BLL(User newUser)
        {
            if (newUser.fullName == "" || newUser.fullName == "Full name")
            {
                return "Vui lòng nhập họ tên đầy đủ";
            }
            else if (newUser.emailAddress == "" || newUser.emailAddress == "Email")
            {
                return "Vui lòng nhập email";
            }
            else if (isValidEmail(newUser.emailAddress) == false)
            {
                return "Vui lòng nhập email hợp lệ";
            }
            else if (newUser.contactAddress == "" || newUser.contactAddress == "Contact address")
            {
                return "Vui lòng nhập địa chỉ liên lạc";
            }
            else if (newUser.phoneNumber == "" || newUser.phoneNumber == "Phone number")
            {
                return "Vui lòng nhập số điện thoại";
            }
            else if (newUser.userName == "" || newUser.userName == "Username")
            {
                return "Vui lòng nhập tên tài khoản";
            }
            else if (newUser.userPassword == "" || newUser.userPassword == "Password")
            {
                return "Vui lòng nhập mật khẩu";
            }
            return loginDAL.signUp_Login_DAL(newUser);
        }
        public DataTable populateInformationUser_Login_BLL(string userID)
        {
            if (loginDAL.populateInformationUser_Login_DAL(userID) == null)
            {
                return null;
            }
            else
            {
                return loginDAL.populateInformationUser_Login_DAL(userID);
            }
        }
        public DataTable populateProvince_Login_BLL()
        {
            if (loginDAL.populateProvince_DA_DAL() == null)
            {
                return null;
            }
            else
            {
                return loginDAL.populateProvince_DA_DAL();
            }
        }*/
    }
}
