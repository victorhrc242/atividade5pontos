﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.service.interfaces
{
    public  interface Icaminhãoservice
    {
        public void Adicionar(Caminhao caminhao);
        public void Remover(int id);
        public Caminhao BuscarPorId(int id);
        public List<Caminhao> BuscarPorVeiculoId(int veiculoId);
       
    }
}
