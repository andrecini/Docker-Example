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
        /// Seleciona todos os Usu�rios
        /// </summary>
        /// <returns>Lista de Usu�rios</returns>
        [HttpGet("SelecionarUsuarios")]
        public IEnumerable<Usuario> SelecionarUsuarios()
        {
            var usuarios = _usuarioRepository.SelecionarUsuarios();

            return usuarios;
        }

        /// <summary>
        /// Seleciona um usu�rio pelo seu ID
        /// </summary>
        /// <param name="id">ID do Usu�rio</param>
        /// <returns>Dados do Usu�rio com o ID informado</returns>
        [HttpPost("SelecionarUsuarioPorId")]
        public Usuario SelecionarUsuariosPorId(int id)
        {
            var usuario = _usuarioRepository.SelecionarUsuarioPorId(id);

            return usuario;
        }

        /// <summary>
        /// Atualiza o Usu�rio pelo ID com os dados informados
        /// </summary>
        /// <param name="usuario">Dados do Usu�rio a ser atualizado</param>
        /// <returns>Retorna 1 para sucesso e 0 caso n�o seja poss�vel atualizar o Usu�rio</returns>
        [HttpPost("AtualizarUsuario")]
        public bool AtualizarUsuario(Usuario usuario)
        {
            var resultado = _usuarioRepository.AtualizarUsuario(usuario);

            return resultado;
        }

        /// <summary>
        /// Adiciona um novo Usu�rio
        /// </summary>
        /// <param name="usuario">Dados do Usu�rio a ser Adicionado</param>
        /// <returns>Retorna 1 para sucesso e 0 caso n�o seja poss�vel atualizar o Usu�rio</returns>
        [HttpPost("AdicionarUsuario")]
        public bool AdicionarUsuario(Usuario usuario)
        {
            var resultado = _usuarioRepository.AdicionarUsuario(usuario);

            return resultado;
        }

        /// <summary>
        /// Remove um Usu�rio existente
        /// </summary>
        /// <param name="id">ID do Usu�rio</param>
        /// <returns>Retorna 1 para sucesso e 0 caso n�o seja poss�vel atualizar o Usu�rio</returns>
        [HttpPost("RemoverUsuario")]
        public bool RemoverUsuario(int id)
        {
            var resultado = _usuarioRepository.RemoverUsuario(id);

            return resultado;
        }
    }
}