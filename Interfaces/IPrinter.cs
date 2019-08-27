using System;

namespace HDO.Framework.ESCPos
{
    public interface IPrinter : IDisposable
    {
        /// <summary>
        ///     Print an object.
        /// </summary>
        /// <param name="printable"></param>
        void Print(ESCPosDocument data);
    }
}
