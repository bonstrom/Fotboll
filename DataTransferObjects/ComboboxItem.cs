using System;

namespace DataTransferObjects
{
  public class ComboBoxItem
    {
        public ComboBoxItem(Guid guid, string text)
        {
            Guid = guid;
            Text = text;
        }
        public Guid Guid { get; }
        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }
    }
}
