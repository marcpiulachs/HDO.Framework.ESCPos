using System;

namespace HDO.Framework.ESCPos.Printable
{
    public enum FontSizeMode : byte
    {
        Normal = 0x03,
        Bold = 0x08,
        BoldMedium = 0x20,
        BoldLarge = 0x10,
    }

    public class FontSize : ESCPosDocumentFragment
    {
        private FontSizeMode _mode;

        public FontSize(FontSizeMode mode)
        {
            _mode = mode;
        }

        protected override void BuildFragment()
        {
            Add(new[] { (byte)ESCPosControl.Escape, (byte)0x21, (byte)_mode });
        }
    }
}