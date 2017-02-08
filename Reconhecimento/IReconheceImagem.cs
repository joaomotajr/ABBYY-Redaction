namespace Veros.Image.Reconhecimento
{
    public interface IReconheceImagem
    {
        ResultadoReconhecimento Reconhecer(string imagem, TipoDocumento tipoDocumentoReconhecivel);
    }
}