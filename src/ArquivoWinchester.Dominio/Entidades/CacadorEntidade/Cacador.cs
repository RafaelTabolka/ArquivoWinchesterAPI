using ArquivoWinchester.Dominio.Entidades.Base;
using ArquivoWinchester.Dominio.Entidades.CacadaEntidade;
using ArquivoWinchester.Dominio.Entidades.SerSobrenaturalEntidade;
using ArquivoWinchester.Dominio.Enumeradores.CacadorEnum;

namespace ArquivoWinchester.Dominio.Entidades.CacadorEntidade
{
    public class Cacador : EntidadeBase
    {
        public string NomeCacador { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;
        public EnumRegiaoBaseCacador RegiaoBaseCacador { get; private set; }
        public EnumEspecialidadeCacador EspecialidadeCacador { get; private set; }
        public string Telefone { get; private set; } = string.Empty;
        public string? Anotacoes { get; private set; }
        public EnumStatusCacador StatusCacador { get; private set; }
        public List<Cacada> Cacadas { get; private set; } = new();
        public List<SerSobrenatural> SeresSobrenaturais { get; private set; } = new();

        public Cacador(
            string nomeCacador,
            EnumRegiaoBaseCacador regiaoBaseCacador,
            EnumEspecialidadeCacador especialidadeCacador,
            string telefone,
            string? anotacoes
        )
        {
            Id = Guid.NewGuid();
            NomeCacador = nomeCacador;
            RegiaoBaseCacador = regiaoBaseCacador;
            EspecialidadeCacador = especialidadeCacador;
            Telefone = telefone;
            Anotacoes = anotacoes;
            StatusCacador = EnumStatusCacador.Ativo;
        }

        public void Atualizar(
            string nomeCacador,
            EnumRegiaoBaseCacador regiaoBaseCacador,
            EnumEspecialidadeCacador especialidadeCacador,
            string telefone,
            string? anotacoes
        )
        {
            NomeCacador = nomeCacador;
            RegiaoBaseCacador = regiaoBaseCacador;
            EspecialidadeCacador = especialidadeCacador;
            Telefone = telefone;
            Anotacoes = anotacoes;
        }

        public void DefineSenhaHash(string senhaHash)
        {
            Senha = senhaHash;
        }

        public void Ativar()
        {
            StatusCacador = EnumStatusCacador.Ativo;
        }

        public void Desativar()
        {
            StatusCacador = EnumStatusCacador.Inativo;
        }
    }
}
