namespace BibliothequeApi
{
    public class Emprunt
    {
        public int Id { get; set; }
        public DateOnly DateEmprunt { get; set; }
        public DateOnly? DateRetour { get; set; }
        public Livre Livre { get; set; }
        public Lecteur Lecteur { get; set; }
        public int LivreId { get; set; }
        public int LecteurId { get; set; }
    }
}