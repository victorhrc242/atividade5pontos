using atividade5pontos.entidades;
using Core.service.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class carrocontroller:ControllerBase
    {
        private readonly Icarroservice _icarroservice;
        public carrocontroller(Icarroservice icarroservice,IConfiguration config)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _icarroservice= icarroservice;
        }
        [HttpPost("adicionarcarro")]
        public void adicionar(Carro carro)
        {
            _icarroservice.Adicionar(carro);
        }
        [HttpGet("listar-carro")]
        public List<Carro> listarcarrinhos()
        {
            return _icarroservice.Listar();
        }
        [HttpGet("listar-carroporid")]
        public List<Carro> listarcarroporid(int id)
        {
            return _icarroservice.BuscarPorVeiculoId(id);
        }
        [HttpDelete("deletarusuario")]
        public void excluir(int id)
        {
            _icarroservice.Remover(id);
        }

        
    }
}
