namespace ArquivoWinchester.Infra.CrossCutting.Extensoes
{
    public static class EnumerableExtensoes
    {
        public static void ForEach<T>(this IEnumerable<T> fonte, Action<T> acao)
        {
            foreach(var elemento in fonte)
            {
                acao(elemento);
            }
        }
    }
}
