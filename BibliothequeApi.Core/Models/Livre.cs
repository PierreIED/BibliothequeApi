using Azure;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BibliothequeApi
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int? NbPages { get; set; }
        public Domaine? Domaine { get; set; }
        public Auteur? Auteur { get; set; }
        [JsonIgnore]
        public List<Emprunt>? Emprunts { get; set; }
        [EnumDataType(typeof(Etat))]
        public Etat EtatLivre { get; set; } = Etat.DISPONIBLE;
        public int AuteurId { get; set; }
        public int DomaineId { get; set; }
    }
}