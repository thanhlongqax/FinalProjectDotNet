using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Configuration;
using Newtonsoft.Json;

namespace Gimji.DTO
{
    internal class CartItemManager
    {
        public static List<CartItem> GetCartItems()
        {
            string cartItemsJson = ConfigurationManager.AppSettings["cartItems"];
            if (string.IsNullOrEmpty(cartItemsJson) || cartItemsJson.Equals("null", StringComparison.OrdinalIgnoreCase))
            {
                return new List<CartItem>();
            }

            return JsonConvert.DeserializeObject<List<CartItem>>(cartItemsJson);
        }

        public static void SaveCartItems(List<CartItem> cartItems)
        {
            try
            {
                // Serialize the cartItems to JSON
                string cartItemsJson = JsonConvert.SerializeObject(cartItems);

                // Open the configuration file
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Access the AppSettings section
                AppSettingsSection appSettings = config.AppSettings;

                // Check if the key exists
                KeyValueConfigurationElement cartItemsKey = appSettings.Settings["cartItems"];

                if (cartItemsKey != null)
                {
                    // If the key exists, update its value
                    cartItemsKey.Value = cartItemsJson;
                }
                else
                {
                    // If the key does not exist, add it
                    appSettings.Settings.Add("cartItems", cartItemsJson);
                }

                // Save the changes
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error saving cart items: {ex.Message}");
            }
        }

        public static void ClearCartItems()
        {
            // Sử dụng một cấu hình mới để tránh sự nhầm lẫn với cấu hình chung của ứng dụng
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Ensure that AppSettings is not null
            if (config.AppSettings != null)
            {
                // Check if the key exists before accessing Settings
                if (config.AppSettings.Settings["cartItems"] != null)
                {
                    // Remove the key to clear the data
                    config.AppSettings.Settings.Remove("cartItems");

                    // Save the changes
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else
                {
                    // Handle the case where "cartItems" key doesn't exist
                    Console.WriteLine("The 'cartItems' key does not exist in appSettings.");
                }
            }
            else
            {
                // Handle the case where AppSettings is null
                Console.WriteLine("AppSettings is null.");
            }
        }


    }
}
