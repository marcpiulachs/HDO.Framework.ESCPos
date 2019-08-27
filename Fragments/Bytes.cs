using System;

namespace HDO.Framework.ESCPos.Printable
{
    public class Bytes : ESCPosDocumentFragment
    {
        private readonly byte[] _bytes;

        public Bytes(byte[] bytes)
        {
            _bytes = bytes;
        }

        protected override void BuildFragment()
        {
            Add(_bytes);
        }
    }
}
