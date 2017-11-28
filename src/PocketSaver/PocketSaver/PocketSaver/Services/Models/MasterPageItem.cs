using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketSaver.Models
{
    /// <summary>
    /// Class for the MasterPageItem to be used for the MainMenu
    /// </summary>
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
        public Color TintColor { get; set; }
        public Color TextColor { get; set; }
    }
    /// <summary>
    /// Class for the GroupedMasterPageItem which holds a list of MasterPageItems
    /// </summary>
    public class GroupedMasterPageItem : ObservableCollection<MasterPageItem>
    {
        public string LongName { get; set; }
        public string Grouping { get; set; }
    }
}
