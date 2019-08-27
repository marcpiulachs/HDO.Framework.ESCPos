using System.IO.Ports;

namespace HDO.Framework.ESCPos.Connectors
{
    public class SerialPortConnector : IPrinterConnector
    {
        private readonly SerialPort serialPort;

        public SerialPortConnector(string portName, int baudRate)
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();
        }
        
        public void Write(byte[] data)
        {
            serialPort.Write(data, 0, data.Length);
        }

        public byte[] Read()
        {
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
            if ((serialPort != null) & (serialPort.IsOpen))
            {
                serialPort.Close();
            }
        }
    }
}