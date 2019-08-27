using System;

namespace HDO.Framework.ESCPos.Printable
{
    public class OpenDrawer : ESCPosDocumentFragment
    {
        protected override void BuildFragment()
        {
            Add(new[] {
                (byte)ESCPosControl.Escape,
                (byte)'p', //Convert.ToByte("p"),
                (byte)'0',
                Convert.ToByte(25),
                Convert.ToByte(250) });
        }   
    }
}