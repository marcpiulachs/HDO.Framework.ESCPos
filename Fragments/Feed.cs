using System;

namespace HDO.Framework.ESCPos.Printable
{
    public class Feed : ESCPosDocumentFragment
    {
        protected override void BuildFragment()
        {
            Add(new[] { (byte)ESCPosControl.LineFeed });
        }
    }
}
