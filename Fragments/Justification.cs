using System;

namespace HDO.Framework.ESCPos.Printable
{
    public enum JustificationType : byte
    {
        /// <summary>
        ///  Left justification is enabled
        /// </summary>
        Left = 0,
        /// <summary>
        /// Center justification is enabled
        /// </summary>
        Center = 1,
        /// <summary>
        /// Right justification is enabled
        /// </summary>
        Right = 2
    }

    public class SetJustification : ESCPosDocumentFragment
    {
        private JustificationType _type;

        public SetJustification(JustificationType type)
        {
            _type = type;
        }

        protected override void BuildFragment()
        {
            Add(new[] { (byte)ESCPosControl.Escape, (byte)'a', (byte)_type });
        }
    }
}
