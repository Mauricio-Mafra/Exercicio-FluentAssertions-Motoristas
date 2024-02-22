using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoristas
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool PossuiHabilitaçãoB { get; set; }

        public Pessoa(string nome, int idade, bool possuiHabilitaçãoB)
        {
            Nome = nome;
            Idade = idade;
            PossuiHabilitaçãoB = possuiHabilitaçãoB;
        }
    }
}
