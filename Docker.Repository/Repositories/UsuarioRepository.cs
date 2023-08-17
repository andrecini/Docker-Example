using Dapper;
using Docker.Core.Entities;
using Docker.Repository.Interfaces;
using MySqlConnector;

namespace Docker.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MySqlConnection _connection;

        public UsuarioRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public bool VerificaSeTabelaExiste()
        {
            string query = "SELECT 1 FROM information_schema.tables WHERE table_name = @TableName LIMIT 1;";
            int result = _connection.ExecuteScalar<int>(query, new { TableName = "Usuario" });

            if (result == 0)
            {
                return CriarTabela();
            }

            return true;
        }

        public bool AdicionarUsuario(Usuario usuario)
        {
            var query =
            @"INSERT INTO Usuario (Nome, Sobrenome, Idade, Genero)
            VALUES (@Nome, @Sobrenome, @Idade, @Genero);";

            return _connection.Execute(query, usuario) > 0;
        }

        public bool AtualizarUsuario(Usuario usuario)
        {
            var query =
            @"UPDATE Usuario
            SET Nome = @Nome,
                Sobrenome = @Sobrenome,
                Idade = @Idade,
                Genero = @Genero
            WHERE Id = @Id;";

            return _connection.Execute(query, usuario) > 0;
        }

        public bool RemoverUsuario(int id)
        {
            var query =
            @"DELETE FROM Usuario
            WHERE Id = @Id;";

            return _connection.Execute(query, new { Id = id }) > 0;
        }

        public Usuario SelecionarUsuarioPorId(int id)
        {
            var query =
            @"SELECT Id, Nome, Sobrenome, Idade, Genero
            FROM Usuario
            WHERE Id = @Id;";

            return _connection.QueryFirst<Usuario>(query, new { Id = id });
        }

        public IEnumerable<Usuario> SelecionarUsuarios()
        {
            var query =
            @"SELECT Id, Nome, Sobrenome, Idade, Genero
            FROM Usuario";

            return _connection.Query<Usuario>(query);
        }

        public bool CriarTabela()
        {
            var query =
            @"CREATE TABLE Usuario (
                Id INT PRIMARY KEY AUTO_INCREMENT,
                Nome VARCHAR(100) NOT NULL,
                Sobrenome VARCHAR(100) NOT NULL,
                Idade INT NOT NULL,
                Genero ENUM('Masculino', 'Feminino', 'Outro') NOT NULL
            );";

            return _connection.Execute(query) == 1;
        }
    }
}
