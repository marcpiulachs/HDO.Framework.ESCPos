using System.Linq;
using System.Collections.Generic;

using HDO.Framework.ESCPos.Printable;

namespace HDO.Framework.ESCPos
{
    public abstract class ESCPosDocumentFragment : IPrintable
    {
        private readonly IList<byte> document = new List<byte>();

        public ESCPosDocumentFragment()
        {

        }

        protected virtual void BuildFragment()
        {

        }

        public ESCPosDocumentFragment Add(ESCPosDocumentFragment printable)
        {
            foreach (var data in printable.GetBytes())
                document.Add(data);

            return this;
        }

        public ESCPosDocumentFragment Add(byte data)
        {
            document.Add(data);

            return this;
        }

        public ESCPosDocumentFragment Add(IEnumerable<byte> data)
        {
            foreach (var dataByte in data)
                Add(dataByte);

            return this;
        }

        public ESCPosDocumentFragment Feed()
        {
            return Add(new Feed());
        }

        public ESCPosDocumentFragment PrintLine(string content, bool feed = true)
        {
            return Add(new TextLine(content, PrinterCodepage.Cp850, feed));
        }

        public ESCPosDocumentFragment PrintLine(string content, params object[] args)
        {
            return Add(new TextLine(string.Format(content, args), PrinterCodepage.Cp850, true));
        }

        public ESCPosDocumentFragment PrintLine(PrinterCodepage printerEnc, string content, bool feed = true)
        {
            return Add(new TextLine(content, printerEnc, feed));
        }

        public ESCPosDocumentFragment SetFont(FontMode fontMode)
        {
            return Add(new SetFont(fontMode));
        }

        public ESCPosDocumentFragment Image(string path)
        {
            return Add(new Image(path));
        }

        public ESCPosDocumentFragment SetFontA()
        {
            return SetFont(FontMode.FontA);
        }

        public ESCPosDocumentFragment SetFontB()
        {
            return SetFont(FontMode.FontB);
        }

        public ESCPosDocumentFragment SetEmphasizedFont()
        {
            return SetFont(FontMode.Emphasized);
        }

        public ESCPosDocumentFragment SetDoubleHeightFont()
        {
            return SetFont(FontMode.DoubleHeight);
        }

        public ESCPosDocumentFragment SetDoubleWidthFont()
        {
            return SetFont(FontMode.DoubleWidth);
        }

        public ESCPosDocumentFragment SetDoubleFont()
        {
            return SetFont(FontMode.DoubleWidth | FontMode.DoubleHeight);
        }

        public ESCPosDocumentFragment Cut(CutType type = CutType.Partial)
        {
            return Add(new CutPaper(type));
        }

        public ESCPosDocumentFragment FontSizeMode(FontSizeMode mode)
        {
            return Add(new FontSize(mode));
        }

        public ESCPosDocumentFragment Reset()
        {
            return Add(new Reset());
        }

        public ESCPosDocumentFragment SetJustification(JustificationType justificationType)
        {
            return Add(new SetJustification(justificationType));
        }

        public ESCPosDocumentFragment SetLeftJustification()
        {
            return SetJustification(JustificationType.Left);
        }

        public ESCPosDocumentFragment SetCenterJustification()
        {
            return SetJustification(JustificationType.Center);
        }

        public ESCPosDocumentFragment SetRightJustification()
        {
            return SetJustification(JustificationType.Right);
        }

        public ESCPosDocumentFragment OpenCashDrawer()
        {
            return Add(new OpenDrawer());
        }

        public ESCPosDocumentFragment AddBarcode(string content)
        {
            return Add(new Barcode(content, 32, BarcodeType.Code128));
        }

        public ESCPosDocumentFragment AddBarcode(string content, int height, BarcodeType barcodeType)
        {
            return Add(new Barcode(content, height, barcodeType));
        }

        //public ESCPosDocumentFragment SetCodePage(CodePage codePage)
        //{
        //    return Add(new SetCodePage(codePage));
        //}

        public ESCPosDocumentFragment SetCodePage(byte codePage)
        {
            return Add(new SetCodePage(codePage));
        }

        public ESCPosDocumentFragment SendBytes(byte[] bytes)
        {
            return Add(new Bytes(bytes));
        }

        public virtual byte[] GetBytes()
        {
            // Builds the fragment
            BuildFragment();

            // Return the byte array.
            return document.ToArray();
        }
    }
}