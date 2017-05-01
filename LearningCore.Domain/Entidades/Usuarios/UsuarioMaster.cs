using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCore.Domain.Entidades
{
    public class UsuarioMaster
    {

        public int IdUsuarioMaster { get; set; }

        public String EmailUsuario { get; set; }

        public String SenhaUsuario { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
