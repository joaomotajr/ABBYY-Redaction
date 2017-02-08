namespace Veros.Image.Reconhecimento
{
    using System.Collections.Generic;

    public class ResultadoReconhecimento
    {
        private readonly Dictionary<string, CampoReconhecido> campos;

        public ResultadoReconhecimento()
        {
            this.campos = new Dictionary<string, CampoReconhecido>();
            this.Palavras = new List<RegiaoTexto>();
        }

        public Dictionary<string, CampoReconhecido> Campos
        {
            get
            {
                return this.campos;
            }
        }

        public IList<RegiaoTexto> Palavras
        {
            get;
            set;
        }

        public bool NaoReconhecido
        {
            get
            {
                return this.Reconhecido == false;
            }
        }

        public bool Reconhecido
        {
            get
            {
                return this.campos.Count > 0;
            }
        }

        public int QuantidadeLicencasUtilizadas
        {
            get;
            set;
        }

        public string CaminhoImagemProcessada
        {
            get;
            set;
        }

        public string NomeTemplate
        {
            get;
            set;
        }

        public static ResultadoReconhecimento CriarNaoReconhecido()
        {
            return new ResultadoReconhecimento();
        }

        public void AdicionarCampo(CampoReconhecido campoReconhecido)
        {
            if (string.IsNullOrEmpty(campoReconhecido.Nome))
            {
                var campo = "nome_" + this.campos.Count;
                this.campos.Add(campo, campoReconhecido);

                return;
            }

            this.campos.Add(campoReconhecido.Nome.ToLower(), campoReconhecido);
        }
    }
}