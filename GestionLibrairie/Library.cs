using System.Text.Json;

public class Library
{
    private List<Media> medias = new List<Media>();
    private List<Usager> usagerEmprunt = new List<Usager>();

    public Media? this[int numeroDeReference]
    {
        get
        {
            return medias.FirstOrDefault(objetMedias => objetMedias.NumeroDeReference == numeroDeReference);
        }
    }

    public void AjouterMedia(Media media)
    {
        Media? media_bibliotheque = this[media.NumeroDeReference];
        if (media_bibliotheque != null) //La un livre
        {
            media_bibliotheque.NombreExemplairesDisponibles++;
        }
        else
        {
            medias.Add(media);
        }
    }

    public void RetirerMedia(Media media)
    {
        Media? media_bibliotheque = this[media.NumeroDeReference];
        if (media_bibliotheque != null && media_bibliotheque.NombreExemplairesDisponibles > 1) //La un livre
        {
            media_bibliotheque.NombreExemplairesDisponibles--;
        }
        else if(media_bibliotheque != null)
        {
            medias.Remove(media);
        }
    }

    public void EmprunterMedia(Media media, string prenom, string nom, string mail, DateTime dateEmprunt, DateTime dateRetour)
    {
        RetirerMedia(media);
        Usager usager = new Usager(prenom, nom, mail, media, dateEmprunt, dateRetour);
        usagerEmprunt.Add(usager);
    }

    public void RetournerMedia(Media media, string prenom, string nom, string mail)
    {
        AjouterMedia(media);
        Usager? usager = usagerEmprunt.FirstOrDefault(objetUsager => objetUsager.Prenom == prenom && objetUsager.Nom == nom && objetUsager.Mail == mail);
        if (usager != null)
        {
            usagerEmprunt.Remove(usager);
        }
    }

    public List<Media> RechercheMedia(string Titre)
    {
        return medias.Where(objetMedias => objetMedias.Titre == Titre).ToList();
    }

    public List<Media> RechercheLivreEmpruntUsager(string prenom, string nom, string mail)
    {
        //Liste tout les emprunt d'un usager
        return usagerEmprunt
            .Where(objetUsager => objetUsager.Prenom == prenom && objetUsager.Nom == nom && objetUsager.Mail == mail)
            .Select(objetUsager => objetUsager.Media)
            .ToList();
    }

    public void AfficherStatistiques()
    {
        int totalMedias = medias.Count, 
            totalExemplaires = medias.Sum(media => media.NombreExemplairesDisponibles),
            totalEmprunts = usagerEmprunt.Count,
            totalExemplairesDisponibles = totalExemplaires - totalEmprunts;

        Console.WriteLine("Statistiques de la Bibliothèque :");
        Console.WriteLine($"    - Nombre total de médias : {totalMedias}");
        Console.WriteLine($"    - Nombre total d'exemplaires: {totalExemplaires}");
        Console.WriteLine($"    - Nombre total d'exemplaires empruntés: {totalEmprunts}");
        Console.WriteLine($"    - Nombre total d'exemplaires disponibles: {totalExemplairesDisponibles}");
    }

    public static Library operator +(Library library, Media media)
    {
        library.AjouterMedia(media);
        return library;
    }

    public static Library operator -(Library library, Media media)
    {
        Media? media_bibliotheque = library[media.NumeroDeReference];
        if (media_bibliotheque == null)
        {
            throw new InvalidOperationException("Le média n'existe pas dans la bibliothèque.");
        }
        library.RetirerMedia(media);
        return library;
    }

    public void Sauvegarder(string cheminFichier)
    {
        var options = new JsonSerializerOptions { WriteIndented = true }; //Permet l'indentation
        string jsonString = JsonSerializer.Serialize(this, options); //Conversion en JSON
        File.WriteAllText(cheminFichier, jsonString); //Enregistrement dans un fichier
    }

    public static Library Charger(string cheminFichier)
    {
        if (!File.Exists(cheminFichier))
        {
            throw new FileNotFoundException("Le fichier spécifié est introuvable.");
        }
        string jsonString = File.ReadAllText(cheminFichier); //Lecture du fichier
        return JsonSerializer.Deserialize<Library>(jsonString) ?? new Library(); //Conversion en objet
    }
}
