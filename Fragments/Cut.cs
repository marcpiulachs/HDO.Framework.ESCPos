using System;

namespace HDO.Framework.ESCPos.Printable
{
    public enum CutType
    {
        /// <summary>
        /// Partial cut
        /// </summary>
        Partial = 0,
        /// <summary>
        /// Full cut
        /// </summary>
        Full = 1,
    }

    public class CutPaper : ESCPosDocumentFragment
    {
        private readonly CutType _type;

        public CutPaper(CutType type = CutType.Partial)
        {
            _type = type;
        }

        protected override void BuildFragment()
        {
            Add(new byte[] {
                (byte)ESCPosControl.GroupSeparator,
                (byte)Convert.ToByte(56),
                (byte)0
            });

            Add(new Feed());
        }
    }
}
