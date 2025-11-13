using System;

namespace Storage.Model
{
    [Serializable]
    public class ItemData
    {
        public string Id;
        public int Count;

        public ItemData(int count)
        {
            Count = count;
        }
    }
}