namespace Veros.Image.Reconhecimento
{
    using System.Drawing;

    public class CampoReconhecido
    {
        public string Texto
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }

        public TipoDoCampoDoTemplate Tipo
        {
            get;
            set;
        }

        public Rectangle Area
        {
            get;
            set;
        }

        /// <summary>
        /// TODO: revisar: nome como string ou usar um enum?
        /// </summary>
        public string NomeDoTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Returna true se campo não for do tipo fulltext
        /// </summary>
        public bool EhReconhecivel
        {
            get
            {
                return this.Tipo != TipoDoCampoDoTemplate.CheckMarkGroup;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Campo: {0}, Texto: {1}",
                this.Nome,
                this.Texto);
        }
    }
}