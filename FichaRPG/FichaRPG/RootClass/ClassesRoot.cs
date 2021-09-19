using FichaRPG.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FichaRPG.RootClass
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ClassesRoot
    {
        public IEnumerable<Classes> Classes { get; set; }

        public ClassesRoot(IEnumerable<Classes> classes)
        {
            Classes = classes;
        }
    }
}
