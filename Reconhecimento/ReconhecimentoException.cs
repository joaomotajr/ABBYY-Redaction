namespace Veros.Image.Reconhecimento
{
    using System;

    public class ReconhecimentoException : Exception
    {
        public ReconhecimentoException(string message) : base(message)
        {
        }

        public ReconhecimentoException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}