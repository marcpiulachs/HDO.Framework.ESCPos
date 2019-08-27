using System;

namespace HDO.Framework.ESCPos.Printable
{
    [Flags]
    public enum FontMode
    {
        /// <summary>
        /// TimesRoman
        /// </summary>
        FontA = 0,
        /// <summary>
        /// SansSerif
        /// </summary>
        FontB = 1,
        /// <summary>
        /// Enabled emphasis (bold) mode
        /// </summary>
        Emphasized = 8,
        /// <summary>
        /// Enable double-height mode
        /// </summary>
        DoubleHeight = 16,
        /// <summary>
        /// Enable double-width mode
        /// </summary>
        DoubleWidth = 32,
        /// <summary>
        /// Thin underline.
        /// </summary>
        Underline = 128
    }

    public class SetFont : ESCPosDocumentFragment
    {
        private FontMode _mode;

        public SetFont(FontMode mode)
        {
            _mode = mode;
        }

        protected override void BuildFragment()
        {
            Add(new[] { (byte)ESCPosControl.Escape, (byte)'!', (byte)_mode });
        }
    }
}