using System;

namespace HDO.Framework.ESCPos.Printable
{
    public enum ItalicsMode
    {
        /// <summary>
        /// Turns off italics mode
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// Turns on italics mode
        /// </summary>
        Enabled = 1
    }

    public class Italics : ESCPosDocumentFragment
    {
        private ItalicsMode _mode;

        public Italics(ItalicsMode mode)
        {
            _mode = mode;
        }

        protected override void BuildFragment()
        {
            Add(new[] { (byte)ESCPosControl.Escape, (byte)'4', (byte)_mode });
        }
    }
}