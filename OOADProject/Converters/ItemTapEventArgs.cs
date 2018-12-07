using System;

namespace OOADProject.Converters
{
    internal class ItemTapEventArgs : EventArgs
    {
        public object Item { get; }

        public ItemTapEventArgs(object item)
        {
            Item = item;
        }
    }
}