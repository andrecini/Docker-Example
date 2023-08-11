using Docker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
