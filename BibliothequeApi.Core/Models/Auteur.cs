
using System.Text.Json.Serialization;

namespace BibliothequeApi
{
    public class Auteur : Personne
    {
        public string? Grade { get; set; }
        [JsonIgnore]
        public List<Livre> Livres { get; set; } = new List<Livre> { };
    }
}