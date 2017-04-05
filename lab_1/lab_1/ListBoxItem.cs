namespace lab_1
{
    internal class ListBoxItem
    {
        public string id { get; }
        public string text { get; }

        public ListBoxItem(string id, string text)
        {
            this.id = id;
            this.text = text;
        }
        public override string ToString()
        {
            return this.text;
        }
        public override bool Equals(object obj)
        {
            ListBoxItem item = (ListBoxItem)obj;
            if (item != null)
            {
                if (item.id == this.id && item.text == this.text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}