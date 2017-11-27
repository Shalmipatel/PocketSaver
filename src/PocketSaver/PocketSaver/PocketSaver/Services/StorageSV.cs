using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketSaver.Services
{
    /// <summary>
    /// Class used to store string values.
    /// </summary>
    public static class StorageSV
    {
        private static Plugin.Settings.Abstractions.ISettings AppSettings
        {
            get
            {
                return Plugin.Settings.CrossSettings.Current;
            }
        }

        //Setting keys and values
        private const string BudgetKey = "budget_key"; //Key used to get your property
        private static readonly string BudgetDefault = null; //Default value for your property if the key-value pair has not been created yet


        //Setting the strings for each of the constants for the saved values.  
        public static string Budget
        {
            get { return AppSettings.GetValueOrDefault<string>(BudgetKey, BudgetDefault); }
            set { AppSettings.AddOrUpdateValue<string>(BudgetKey, value); }
        }
    }
}
