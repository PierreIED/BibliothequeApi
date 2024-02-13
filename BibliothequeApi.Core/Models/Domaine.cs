using System.Text.Json.Serialization;

namespace BibliothequeApi
{
    public class Domaine
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public List<Livre>? Livres { get; set; }
    }
}