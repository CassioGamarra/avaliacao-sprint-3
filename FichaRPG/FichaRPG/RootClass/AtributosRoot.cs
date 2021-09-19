using FichaRPG.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FichaRPG.RootClass
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AtributosRoot
    {
        public IEnumerable<Atributos> Atributos { get; set; }
        public AtributosRoot(IEnumerable<Atributos> atributos)
        {
            Atributos = atributos;
        }
    }
}
