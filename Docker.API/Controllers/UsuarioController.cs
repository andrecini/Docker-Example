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

        [HttpGet("SelecionarUsuarios")]
        public IEnumerable<Usuario> SelecionarUsuarios()
        {
            var usuarios = _usuarioRepository.SelecionarUsuarios();

            return usuarios;
        }

        [HttpPost("SelecionarUsuarioPorId")]
        public Usuario SelecionarUsuariosPorId(int id)
        {
            var usuario = _usuarioRepository.SelecionarUsuarioPorId(id);

            return usuario;
        }

        [HttpPost("AtualizarUsuario")]
        public bool AtualizarUsuario(Usuario usuario)
        {
            var resultado = _usuarioRepository.AtualizarUsuario(usuario);

            return resultado;
        }

        [HttpPost("AdicionarUsuario")]
        public bool AdicionarUsuario(Usuario usuario)
        {
            var resultado = _usuarioRepository.AdicionarUsuario(usuario);

            return resultado;
        }

        [HttpPost("RemoverUsuario")]
        public bool RemoverUsuario(int id)
        {
            var resultado = _usuarioRepository.RemoverUsuario(id);

            return resultado;
        }
    }
}