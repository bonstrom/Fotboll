using System;
using System.Collections.Generic;

namespace DataTransferObjects
{
  public class ComboBoxItem
    {
        public ComboBoxItem(KeyValuePair<Guid, string> keyVal, string text)
        {
            KeyVal = keyVal;
            Text = text;
        }
        public KeyValuePair<Guid, string> KeyVal { get; }
        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }
    }
}
