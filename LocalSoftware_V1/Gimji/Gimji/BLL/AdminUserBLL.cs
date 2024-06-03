using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.BLL
{
    internal class AdminUserBLL
    {
        /*public DataTable getAllUser()
        {
            UserCRUD_DAL ehe = new UserCRUD_DAL();
            return ehe.getAllUser_DAL();
        }
        public DataTable searchUser(String key, String cn)
        {
            UserCRUD_DAL data = new UserCRUD_DAL();
            return data.searchUser_DAL(key, cn);
        }
        public DataTable getAllUserOfStore(String key)
        {
            UserCRUD_DAL data = new UserCRUD_DAL();
            return data.getUserOfStore_DAL(key);
        }
        public void deleteUser(String id)
        {
            UserCRUD_DAL data = new UserCRUD_DAL();
            data.deleteUser_DAL(id);
        }
        public void updateUser(User user)
        {
            UserCRUD_DAL data = new UserCRUD_DAL();
            data.updateUser_DAL(user);
        }
        public void addUser(User user, String cn)
        {
            UserCRUD_DAL data = new UserCRUD_DAL();
            data.addUser_DAL(user, cn);
        }
        public String getIdByUsername(String name)
        {
            UserCRUD_DAL data = new UserCRUD_DAL();
            return data.getIdByUsername_DAL(name);
        }

        public User getUserByID(String id)
        {
            UserCRUD_DAL data = new UserCRUD_DAL();
            User newUser = new User();
            foreach (DataRow row in data.getUserByID(id).Rows)
            {
                newUser.fullName = row["fullName"].ToString();
                newUser.emailAddress = row["emailAddress"].ToString();
                newUser.contactAddress = row["contactAddress"].ToString();
                newUser.phoneNumber = row["phoneNumber"].ToString();
                newUser.userName = row["userID"].ToString();
                newUser.userPassword = row["userPassword"].ToString();
                newUser.userRole = row["userRole"].ToString();
                newUser.userDateOfBirth = row["userDateOfBirth"].ToString();
            }
            return newUser;
        }*/
    }
}
