
using System.Text.Json.Serialization;

namespace BibliothequeApi
{
    public class Lecteur : Personne
    {
        public string MotDePasse { get; set; }
        [JsonIgnore]
        public List<Emprunt>? Emprunter { get; set; }
        public Adresse Adresse { get; set; }
        public int AdresseId { get; set; }
    }
}