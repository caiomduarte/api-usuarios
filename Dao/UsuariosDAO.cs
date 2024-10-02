using API_USUARIOS.Model;
using Microsoft.AspNetCore.Connections;
using MySql.Data.MySqlClient;

namespace API_USUARIOS.Dao
{
    public class UsuariosDAO
    {
        //Método CadastrarUsuario
        public void CadastrarUsuario(UsuariosDTO usuario)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Usuarios (Nome, CPF, Email, Celular) VALUES
						(@nome,@cpf,@email,@celular)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", usuario.Nome);
            comando.Parameters.AddWithValue("@cpf", usuario.CPF);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@celular", usuario.Celular);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        //Método Alterar Usuarios
        public void AlterarUsuario(UsuariosDTO usuario)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"UPDATE Usuarios SET 
								Nome = @nome, 
								CPF = @cpf, 
								Email = @email, 
								Celular = @celular, 
								Imagem = @imagem 
						  WHERE ID = @id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", usuario.ID);
            comando.Parameters.AddWithValue("@nome", usuario.Nome);
            comando.Parameters.AddWithValue("@cpf", usuario.CPF);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@celular", usuario.Celular);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        //Método Excluir Usuario
        public void ExcluirUsuario(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"DELETE FROM Usuarios WHERE ID = @id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        //Metodo listar todos os usuarios
        public List<UsuariosDTO> ListarUsuario()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM Usuarios";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var usuarios = new List<UsuariosDTO>();

            while (dataReader.Read())
            {
                var usuario = new UsuariosDTO();
                usuario.ID = int.Parse(dataReader["ID"].ToString());
                usuario.Nome = dataReader["Nome"].ToString();
                usuario.Email = dataReader["Email"].ToString();
                usuario.CPF = dataReader["CPF"].ToString();
                usuario.Celular = dataReader["Celular"].ToString();

                usuarios.Add(usuario);
            }
            conexao.Close();

            return usuarios;
        }

        //Metodo que lista usuarios por id
        public UsuariosDTO ListarUsuarioPorId(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM Usuarios WHERE Id = @id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", id);

            var dataReader = comando.ExecuteReader();

            var usuario = new UsuariosDTO();
            while (dataReader.Read())
            {
                usuario.ID = int.Parse(dataReader["ID"].ToString());
                usuario.Nome = dataReader["Nome"].ToString();
                usuario.Email = dataReader["Email"].ToString();
                usuario.CPF = dataReader["CPF"].ToString();
                usuario.Celular = dataReader["Celular"].ToString();

            }
            conexao.Close();

            return usuario;
        }

    }
}
