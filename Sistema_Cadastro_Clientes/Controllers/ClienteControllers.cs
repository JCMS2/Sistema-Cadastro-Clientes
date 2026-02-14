using Microsoft.AspNetCore.Mvc;
using Sistema_Cadastro_Clientes.Classes;
using Sistema_Cadastro_Clientes.Context;

namespace Sistema_Cadastro_Clientes.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteControllers : ControllerBase
    {
        public readonly ClienteContext _cliente;
        public ClienteControllers(ClienteContext Cliente)
        {
            _cliente = Cliente;
        }
        [HttpPost("Adicionar")]
        public IActionResult Adicionar(Cliente cli)
        {
            _cliente.Add(cli);
            _cliente.SaveChanges();
            return Ok(cli);
        }
        [HttpGet("Buscar")] 
        public IActionResult Buscar()
        {
            var Bus = _cliente.Clientes.ToList();
            return Ok(Bus);
        }
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int id)
        {
            var BuscarPorId = _cliente.Clientes.FirstOrDefault(e=>e.Id==id);
            if (BuscarPorId == null) return NotFound("Id nao existe");
           
            return Ok(BuscarPorId);
        }

        [HttpGet("BuscarPorNome")]
        public IActionResult BuscarPorNome(string nome)
        {
            var BuscarNome = _cliente.Clientes.Where(e=>e.Nome.Contains(nome));
            return Ok(BuscarNome);
        }
        [HttpDelete("DeletePorId")]
        public IActionResult DeletePorId(int id)
        {
            var DeleteId = _cliente.Clientes.Find(id);
            if (DeleteId == null) return NotFound("Id nao existe");
            _cliente.Remove(DeleteId);
            _cliente.SaveChanges();
            return Ok(DeleteId);
        }
        [HttpPut("AlterarPorId")]
        public IActionResult AlterarPorId(int id, Cliente cliente)
        {
            var AlterarPorId = _cliente.Clientes.Find(id);
            if (AlterarPorId == null) return NotFound("Id nao existe");
            AlterarPorId.Id = id;
            AlterarPorId.Nome = cliente.Nome;
            AlterarPorId.Idade= cliente.Idade;
            AlterarPorId.Endereco= cliente.Endereco;
            AlterarPorId.Telefone= cliente.Telefone;
            AlterarPorId.CPF= cliente.CPF;
            _cliente.SaveChanges();
            return Ok(AlterarPorId);

        }


    }
}
