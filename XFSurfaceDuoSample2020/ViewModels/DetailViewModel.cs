using System;

using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
