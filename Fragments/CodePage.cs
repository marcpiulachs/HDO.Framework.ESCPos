using System;

namespace HDO.Framework.ESCPos.Printable
{
    //public enum CodePage
    //{
    //    Default = 0,
    //    Pc437 = 0,
    //    Katakana = 1,
    //    Pc850 = 2,
    //    Pc860 = 3
    //}
    
    public class SetCodePage : ESCPosDocumentFragment
    {
        private readonly byte _codePage;
        
        //public SetCodePage(CodePage codePage)
        //{
        //    _codePage = (byte) codePage;
        //}

        public SetCodePage(byte codePage)
        {
            _codePage = codePage;
        }

        protected override void BuildFragment()
        {
            //Add(new byte[] { 27, 37, 1 });
            //Add(new byte[] { 0x1B, 0x74, (byte)_codePage });
            Add( new byte[] {(byte)ESCPosControl.Escape, (byte)'t', (byte)_codePage, (byte)ESCPosControl.Null});
            //Add(new byte[] { 0x1b, 0x74, 0x13 });
        }
    }
}