using API_USUARIOS.Dao;
using API_USUARIOS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_USUARIOS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //1 Passo - Definir qual é o método http utilizado na requisicao
        //2 Passo - Criar um método que retorna um IActionResult que
        //O IActionResult é uma interface no ASP.NET Core que representa o resultado de uma ação
        //em um controlador. Ele permite que você retorne diferentes tipos de respostas HTTP a
        //partir de um método de ação, proporcionando flexibilidade na forma como você responde a requisições.
        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            var dao = new UsuariosDAO();
            var usuarios = dao.ListarUsuario();

            return Ok(usuarios);
        }


        //Metodo que faz um cadastro de usuario
        [HttpPost]
        public IActionResult Cadastrar([FromBody] UsuariosDTO usuario)
        {
            var dao = new UsuariosDAO();

            dao.CadastrarUsuario(usuario);

            return Ok();
        }

        //Metodo que Edita os dados de um usuario
        [HttpPut]
        public IActionResult Editar([FromBody] UsuariosDTO usuario)
        {
            var dao = new UsuariosDAO();
            dao.AlterarUsuario(usuario);

            return Ok();
        }


        //Metodo que Exclui um usuario
        //Passando o parametro id atraves da url
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            var dao = new UsuariosDAO();
            dao.ExcluirUsuario(id);

            return Ok();
        }

        //Metodo que Pesquisa um usuario por Id
        [HttpGet]
        [Route("{id}")]
        public IActionResult ListarPorID([FromRoute] int id)
        {
            var dao = new UsuariosDAO();
            var usuario = dao.ListarUsuarioPorId(id);

            return Ok(usuario);
        }
    }
}
