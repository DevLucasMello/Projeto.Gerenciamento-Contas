﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.Domain
{
    public class ContaListItem
    {
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public PagarReceber Tipo { get; set; }
        public string Descricao { get; set; }
        public string Contato { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }

        public string CategoriaId { get; set; }
        public string ContaCorrenteId { get; set; }
    }
}
