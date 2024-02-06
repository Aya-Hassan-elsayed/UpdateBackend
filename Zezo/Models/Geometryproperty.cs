using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class Geometryproperty
    {
        public bool? Primarygeometryflag { get; set; }
        public int? Geometrytype { get; set; }
        public string? Gcoordsystemguid { get; set; }
        public string? Fielddescription { get; set; }
        public int Indexid { get; set; }
    }
}
