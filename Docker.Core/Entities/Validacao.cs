﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker.Core.Entities
{
    public class Validacao
    {
        public bool EhValido { get; set; }
        public List<string> Mensagens { get; set; }
    }
}
