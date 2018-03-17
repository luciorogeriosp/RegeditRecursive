using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace RegeditRecursive
{
    public class RegeditUtilities
    {
        /// <summary>
        /// Find an text in regedit keys
        /// </summary>
        /// <param name="MasterKey">Parent Key</param>
        /// <param name="key">Key name to find</param>
        /// <returns></returns>
        public static List<string> FindKey(RegistryKey MasterKey, string key)
        {
            List<string> lstKeysFound = new List<string>();

            FindKeyinRegistryKey(MasterKey, key, ref lstKeysFound);

            return lstKeysFound;
        }

        /// <summary>
        /// Recursive function to find keys and increment list.
        /// </summary>
        /// <param name="MasterKey">Parent Key</param>
        /// <param name="key">Key name to find</param>
        /// <param name="lstKeysFound">List to increment</param>
        private static void FindKeyinRegistryKey(RegistryKey MasterKey, string key, ref List<string> lstKeysFound)
        {
            string[] keys = MasterKey.GetSubKeyNames();
            foreach (string itemKey in keys)
            {
                try
                {
                    if (itemKey.Contains(key))
                    {
                        lstKeysFound.Add(MasterKey.Name + " - " + itemKey);
                        break;
                    }

                    FindKeyinRegistryKey(MasterKey.OpenSubKey(itemKey), key, ref lstKeysFound);                                        
                }
                catch // Prevent access denied
                { }
                
            }
        }
    }
}
