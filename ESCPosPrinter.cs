using System;

using HDO.Framework.ESCPos.Connectors;

namespace HDO.Framework.ESCPos
{
    public class ESCPosPrinter : IPrinter
    {
        private readonly IPrinterConnector _connector;

        public ESCPosPrinter(IPrinterConnector connector)
        {
            _connector = connector;
        }

        public void Print(ESCPosDocument document)
        {
            // Get the document to be printed.
            byte[] bytes = document.GetBytes();

            // Send bytes to the printer
            _connector.Write(bytes);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_connector != null)
                _connector.Dispose();
        }

        ~ESCPosPrinter()
        {
            Dispose(false);
        }
    }
}