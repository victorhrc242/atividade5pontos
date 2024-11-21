using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    [Table("Caminhaos")]
    public class CreateCaminhao
    {
      
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public double CapacidadeCarga { get; set; }
    }
}
