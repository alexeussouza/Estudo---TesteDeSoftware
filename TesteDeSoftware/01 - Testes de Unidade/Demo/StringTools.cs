﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class StringTools
    {
        public string Unir(string nome, string sobrenome)
        {
            return $"{nome} {sobrenome}";
            // Retorna nome e sobrenome concatenado com um espaço no meio
        }
    }
}
