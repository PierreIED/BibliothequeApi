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
       
        public Emprunt()
        {
        }

        public Emprunt(DateOnly dateEmprunt, DateOnly? dateRetour, int livreId, int lecteurId)
        {
            DateEmprunt = dateEmprunt;
            DateRetour = dateRetour;
            LivreId = livreId;
            LecteurId = lecteurId;
        }

        public Emprunt(int id, DateOnly dateEmprunt, DateOnly? dateRetour, Livre livre, Lecteur lecteur, int livreId, int lecteurId)
        {
            Id = id;
            DateEmprunt = dateEmprunt;
            DateRetour = dateRetour;
            Livre = livre;
            Lecteur = lecteur;
            LivreId = livreId;
            LecteurId = lecteurId;
        }
    }
}