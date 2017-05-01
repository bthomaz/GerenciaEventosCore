using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCore.Domain.Entidades
{
    public class Cliente
    {

        public int IdCliente { get; set; }

        public String DescricaoCliente { get; set; }

        public virtual UsuarioMaster UsuarioMaster { get; set; }

        public virtual List<Projeto> Projetos { get; set; }

        public DateTime DataCriacao { get; set; }

    }
}
