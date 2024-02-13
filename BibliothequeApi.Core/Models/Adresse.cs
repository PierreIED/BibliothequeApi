using System.Text.Json.Serialization;

namespace BibliothequeApi
{
    public class Adresse
    {
        public int Id { get; set; }
        public string? Appartement { get; set; }
        public string? Rue { get; set; }
        public string Ville { get; set; }
        public string ZipCode { get; set; }
        public string Pays { get; set; }
        [JsonIgnore]
        public List<Lecteur>? Lecteurs { get; set; }
    }
}