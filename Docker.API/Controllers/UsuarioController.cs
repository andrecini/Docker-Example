using Docker.Core.Entities;
using Docker.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Docker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;

            _usuarioRepository.VerificaSeTabelaExiste();
        }

        /// <summary>
        /// Seleciona todos os Usuários
        /// </summary>
        /// <returns>Lista de Usuários</returns>
        [HttpGet("SelecionarUsuarios")]
        public IEnumerable<Usuario> SelecionarUsuarios()
        {
            var usuarios = _usuarioRepository.SelecionarUsuarios();

            return usuarios;
        }

        /// <summary>
        /// Seleciona um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do Usuário</param>
        /// <returns>Dados do Usuário com o ID informado</returns>
        [HttpPost("SelecionarUsuarioPorId")]
        public Usuario SelecionarUsuariosPorId(int id)
        {
            var usuario = _usuarioRepository.SelecionarUsuarioPorId(id);

            return usuario;
        }

        /// <summary>
        /// Atualiza o Usuário pelo ID com os dados informados
        /// </summary>
        /// <param name="usuario">Dados do Usuário a ser atualizado</param>
        /// <returns>Retorna 1 para sucesso e 0 caso não seja possível atualizar o Usuário</returns>
        [HttpPost("AtualizarUsuario")]
        public bool AtualizarUsuario(Usuario usuario)
        {
            var resultado = _usuarioRepository.AtualizarUsuario(usuario);

            return resultado;
        }

        /// <summary>
        /// Adiciona um novo Usuário
        /// </summary>
        /// <param name="usuario">Dados do Usuário a ser Adicionado</param>
        /// <returns>Retorna 1 para sucesso e 0 caso não seja possível atualizar o Usuário</returns>
        [HttpPost("AdicionarUsuario")]
        public bool AdicionarUsuario(Usuario usuario)
        {
            var resultado = _usuarioRepository.AdicionarUsuario(usuario);

            return resultado;
        }

        /// <summary>
        /// Remove um Usuário existente
        /// </summary>
        /// <param name="id">ID do Usuário</param>
        /// <returns>Retorna 1 para sucesso e 0 caso não seja possível atualizar o Usuário</returns>
        [HttpPost("RemoverUsuario")]
        public bool RemoverUsuario(int id)
        {
            var resultado = _usuarioRepository.RemoverUsuario(id);

            return resultado;
        }
    }
}