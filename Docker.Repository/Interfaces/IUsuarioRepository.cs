using Docker.Core.Entities;

namespace Docker.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        bool VerificaSeTabelaExiste();
        bool AdicionarUsuario(Usuario usuario);
        bool RemoverUsuario(int id);
        bool AtualizarUsuario(Usuario usuario);
        Usuario SelecionarUsuarioPorId(int id);
        IEnumerable<Usuario> SelecionarUsuarios();
        bool CriarTabela();
    }
}
