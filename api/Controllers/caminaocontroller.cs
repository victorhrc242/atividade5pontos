using Core.service.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class caminaocontroller:ControllerBase
    {
        private readonly Icaminhãoservice _icarroservice;
        public caminaocontroller(Icaminhãoservice icarroservice, IConfiguration config)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _icarroservice = icarroservice;
        }
        [HttpPost("adicionarcaminhão")]
        public void adicionar(Caminhao caminhao)
        {
            _icarroservice.Adicionar(caminhao);
        }
        
        [HttpGet("listar-CaminãoPorId")]
        public List<Caminhao> listarcarroporid(int id)
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
