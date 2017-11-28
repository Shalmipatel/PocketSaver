using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketSaver.Services
{
    public static class StorageSV
    {
        private static Plugin.Settings.Abstractions.ISettings AppSettings
        {
            get
            {
                return Plugin.Settings.CrossSettings.Current;
            }
        }

        private const string BudgetAmountKey = "budgetAmount_key";
        private static readonly string BudgetAmountDefault = null;

        public static string BudgetAmount
        {
            get { return AppSettings.GetValueOrDefault<string>(BudgetAmountKey, BudgetAmountDefault); }
            set { AppSettings.AddOrUpdateValue<string>(BudgetAmountKey, value); }
        }
    }
}
