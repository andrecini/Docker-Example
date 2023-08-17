using Docker.Core.Entities;
using Docker.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        /// Seleciona todos os Usuarios
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        [HttpGet("SelecionarUsuarios")]
        public IEnumerable<Usuario> SelecionarUsuarios()
        {
            var usuarios = _usuarioRepository.SelecionarUsuarios();

            return usuarios; 
        }

        /// <summary>
        /// Seleciona um usuario pelo seu ID
        /// </summary>
        /// <param name="id">ID do Usuario</param>
        /// <returns>Dados do Usuario com o ID informado</returns>
        [HttpPost("SelecionarUsuarioPorId")]
        public Usuario SelecionarUsuariosPorId(int id)
        {
            var usuario = _usuarioRepository.SelecionarUsuarioPorId(id);

            return usuario;
        }

        /// <summary>
        /// Atualiza o Usuario pelo ID com os dados informados
        /// </summary>
        /// <param name="usuario">Dados do Usuario a ser atualizado</param>
        /// <returns>Retorna 1 para sucesso e 0 caso nao seja possavel atualizar o Usuário</returns>
        [HttpPost("AtualizarUsuario")]
        public bool AtualizarUsuario(Usuario usuario)
        {
            var resultado = _usuarioRepository.AtualizarUsuario(usuario);

            return resultado;
        }

        /// <summary>
        /// Adiciona um novo Usuario
        /// </summary>
        /// <param name="usuario">Dados do Usuario a ser Adicionado</param>
        /// <returns>Retorna 1 para sucesso e 0 caso nao seja possavel atualizar o Usuário</returns>
        [HttpPost("AdicionarUsuario")]
        public bool AdicionarUsuario(Usuario usuario)
        {
            var resultado = _usuarioRepository.AdicionarUsuario(usuario);

            return resultado;
        }

        /// <summary>
        /// Remove um Usuario existente
        /// </summary>
        /// <param name="id">ID do Usuario</param>
        /// <returns>Retorna 1 para sucesso e 0 caso nao seja possavel atualizar o Usuario</returns>
        [HttpPost("RemoverUsuario")]
        public bool RemoverUsuario(int id)
        {
            var resultado = _usuarioRepository.RemoverUsuario(id);

            return resultado;
        }
    }
}