using System.Text;

namespace HDO.Framework.ESCPos.Printable
{
    public class PrinterCodepage
    {
        public static readonly PrinterCodepage Cp437 = new PrinterCodepage(0, Encoding.GetEncoding(437));
        public static readonly PrinterCodepage Cp850 = new PrinterCodepage(2, Encoding.GetEncoding(850));
        //public static readonly PrinterCodepage Cp852 = new PrinterCodepage(2, Encoding.GetEncoding(852));
        //public static readonly PrinterCodepage Cp857 = new PrinterCodepage(3, Encoding.GetEncoding(857));
        //public static readonly PrinterCodepage Cp860 = new PrinterCodepage(3, Encoding.GetEncoding(860));
        //public static readonly PrinterCodepage Cp861 = new PrinterCodepage(6, Encoding.GetEncoding(861));
        //public static readonly PrinterCodepage Cp863 = new PrinterCodepage(4, Encoding.GetEncoding(863));
        public static readonly PrinterCodepage Cp858 = new PrinterCodepage(19, Encoding.GetEncoding(858));
        //public static readonly PrinterCodepage Cp862 = new PrinterCodepage(8, Encoding.GetEncoding(862));
        //public static readonly PrinterCodepage Cp865 = new PrinterCodepage(5, Encoding.GetEncoding(865));
        ////public static readonly PrinterCodepage Cp866 = new PrinterCodepage(254, Encoding.GetEncoding(866));
        //public static readonly PrinterCodepage Cp1252 = new PrinterCodepage(6, Encoding.GetEncoding(1252));
        //public static readonly PrinterCodepage Cp1250 = new PrinterCodepage(6, Encoding.GetEncoding(1250));
        //public static readonly PrinterCodepage Cp1250 = new PrinterCodepage(6, Encoding.GetEncoding(858));

        private readonly byte _pageNumber;
        private readonly Encoding _encoding;

        private PrinterCodepage(byte pageNumber, Encoding encoding)
        {
            this._pageNumber = pageNumber;
            this._encoding = encoding;
        }

        public byte PageNumber
        {
            get
            {
                return _pageNumber;
            }
        }

        public Encoding Encoding
        {
            get
            {
                return _encoding;
            }
        }
    }

    public class TextLine : ESCPosDocumentFragment
    {
        private readonly string text;
        private readonly bool feed;

        private PrinterCodepage printerCodePage = PrinterCodepage.Cp858;

        public TextLine(string text, PrinterCodepage printerCodePage, bool feed = true)
        {
            this.text = text;
            this.feed = feed;
            this.printerCodePage = printerCodePage;
        }

        protected override void BuildFragment()
        {
            // Encode the string with the appropiate enconding
            var lineBytes = printerCodePage.Encoding.GetBytes(text);

            // Sets the code page.
            Add(new SetCodePage(printerCodePage.PageNumber));

            // Add the text
            Add(lineBytes);

            // Feed one line.
            if (feed)
            {
                Add(new Feed());
            }
        }
    }
}