using System.Linq;
using System.Text;

namespace HDO.Framework.ESCPos.Printable
{
    public enum BarcodeType
    {
        UpcA,
        UpcE,
        Ean13,
        Ean8,
        Code39,
        I25,
        Codebar,
        Code93,
        Code128,
        Code11,
        Msi
    }

    /// <summary>
    ///     A barcode printable implementation.
    /// </summary>
    /// <remarks>
    ///     This printable type reset the printer.
    /// </remarks>
    public class Barcode : ESCPosDocumentFragment
    {
        private readonly string _content;
        private readonly int _height;
        private readonly BarcodeType _type;

        public Barcode(string content, int height = 32, BarcodeType type = BarcodeType.Code128)
        {
            _content = content;
            _height = height;
            _type = type;
        }

        protected override void BuildFragment()
        {
            byte[] array = Encoding.ASCII.GetBytes(_content);

            Add(new Reset());
            Add(new[] { (byte)ESCPosControl.GroupSeparator, (byte)'h', (byte)_height });
            Add(new[] { (byte)ESCPosControl.GroupSeparator, (byte)'k', (byte)_type, (byte)_content.Length });
            Add(_content.ToCharArray().Select(e => (byte)e));
            Add(new[] { (byte)0, (byte)_content.Length, (byte)0 });
            Add(new Reset());
        }
    }
}