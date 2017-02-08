namespace Sample.Tools
{
    using System.Drawing;
    using Sample.Reconhecimento;

    public class CampoEngine
    {
        public TipoDoCampoDoTemplate Type
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string TemplateName
        {
            get;
            set;
        }

        public bool EhReconhecivel
        {
            get
            {
                return
                    this.Type != TipoDoCampoDoTemplate.CheckMarkGroup;
            }
        }

        public Rectangle Area
        {
            get;
            set;
        }
    }
}