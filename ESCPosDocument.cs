using HDO.Framework.ESCPos.Printable;

namespace HDO.Framework.ESCPos
{
    public class ESCPosDocument : ESCPosDocumentFragment
    {
        public ESCPosDocument()
        {

        }

        protected override void BuildFragment()
        {
            Add(new Reset());
        }
    }
}