using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FichaRPG.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Atributos
    {
        [JsonProperty("ClasseId")]
        public int ClasseId { get; set; }
        [JsonProperty("Forca")]
        public int Forca { get; set; }
        [JsonProperty("Destreza")]
        public int Destreza { get; set; }
        [JsonProperty("Inteligencia")]
        public int Inteligencia { get; set; }

        public Atributos(int classeId, int forca, int destreza, int inteligencia)
        {
            ClasseId = classeId;
            Forca = forca;
            Destreza = destreza;
            Inteligencia = inteligencia;
        }
    }
}
