using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimji.DTO
{
    internal class Stored_Login_Infor
    {
        public static void StorageUser(String id)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["id"].Value = id;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static String GetCurrentUser()
        {
            string id = ConfigurationManager.AppSettings["id"];
            return id;
        }
        public static void Logout() {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["id"].Value = null;
            // Xóa giá trị của "cartItems"
            config.AppSettings.Settings.Remove("cartItems");
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


    }
}
