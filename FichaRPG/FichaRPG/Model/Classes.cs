using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FichaRPG.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Classes
    {

        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("NomeClasse")]
        public string NomeClasse { get; set; }
        public Atributos Atributos { get; set; }

        public Classes(int id, string nomeClasse, Atributos atributos)
        {
            Id = id;
            NomeClasse = nomeClasse;
            Atributos = atributos;
        }
    }
}
