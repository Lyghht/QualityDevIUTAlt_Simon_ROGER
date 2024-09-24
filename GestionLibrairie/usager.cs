public class Usager
{
    private string prenom;
    private string nom;
    private string mail;
    private DateTime dateEmprunt;
    private DateTime dateRetour;
    private Media media;

    public Usager(string prenom, string nom, string mail, Media media, DateTime dateEmprunt, DateTime dateRetour)
    {
        this.prenom = prenom;
        this.nom = nom;
        this.mail = mail;
        this.media = media;
        this.dateEmprunt = dateEmprunt;
        this.dateRetour = dateRetour;
    }

    public string Prenom
    {
        get { return prenom; }
    }

    public string Nom
    {
        get { return nom; }
    }

    public string Mail
    {
        get { return mail; }
    }

    public Media Media
    {
        get { return media; }
    }
}