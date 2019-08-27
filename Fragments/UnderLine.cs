using System;

namespace HDO.Framework.ESCPos.Printable
{
    /// <summary>
    /// The line.
    /// </summary>
    public enum UnderLineMode
    {
        /// <summary>
        /// TimesRoman
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// Turns on underline mode (1-dot thick)
        /// </summary>
        OneDotThick = 1,
        /// <summary>
        /// Turns on underline mode (2-dot thick)
        /// </summary>
        TwoDotThick = 2
    }

    public class UnderLine : ESCPosDocumentFragment
    {
        private UnderLineMode _mode;

        public UnderLine(UnderLineMode mode)
        {
            _mode = mode;
        }

        protected override void BuildFragment()
        {
            Add(new[] { (byte)ESCPosControl.Escape, (byte)'-', (byte)_mode });
        }
    }
}