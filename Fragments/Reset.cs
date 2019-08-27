using System;

namespace HDO.Framework.ESCPos.Printable
{
    public class Reset : ESCPosDocumentFragment
    {
        protected override void BuildFragment()
        {
            Add(new[] { (byte)ESCPosControl.Escape, (byte)'@' });
        }
    }
}
