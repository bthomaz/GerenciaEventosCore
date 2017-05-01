using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCore.Domain.Entidades
{
    public class Projeto
    {

        public int IdProjeto { get; set; }

        public virtual Cliente Cliente { get; set; }

        public String DescricaoProjeto { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
