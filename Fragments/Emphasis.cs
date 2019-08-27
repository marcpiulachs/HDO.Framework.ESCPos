using System;

namespace HDO.Framework.ESCPos.Printable
{
    public enum EmphasisMode
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

    public class Emphasis : ESCPosDocumentFragment
    {
        private EmphasisMode _mode;

        public Emphasis(EmphasisMode mode)
        {
            _mode = mode;
        }

        protected override void BuildFragment()
        {
            Add(new[] { (byte)ESCPosControl.Escape, (byte)'E', (byte)_mode });
        }
    }
}