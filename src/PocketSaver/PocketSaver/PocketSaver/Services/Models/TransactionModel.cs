using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketSaver.Models
{
    /// <summary>
    /// Class for the TransactionModel Object to be used throughout the application.
    /// </summary>
    public class TransactionModel
    {
        public string _id { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Comment { get; set; }
    }
}
