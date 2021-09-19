using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FichaRPG.RootClass
{
    [JsonObject(MemberSerialization.OptIn)]
    public class IdsRoot
    {
        public IEnumerable<int> Ids { get; set; }

        public IdsRoot(IEnumerable<int> ids)
        {
            Ids = ids;
        }
    }
}
