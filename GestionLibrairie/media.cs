public class Media
{
    protected string? titre;
    protected int numeroDeReference;
    protected int nombreExemplairesDisponibles;

    public virtual void AfficherInfos()
    {
        Console.WriteLine("Titre: " + titre);
        Console.WriteLine("Numero de reference: " + numeroDeReference);
        Console.WriteLine("Nombre d'exemplaires disponibles: " + nombreExemplairesDisponibles);
    }

    public int NumeroDeReference
    {
        get { return numeroDeReference; }
    }

    public int NombreExemplairesDisponibles
    {
        get { return nombreExemplairesDisponibles; }
        set { nombreExemplairesDisponibles = value; }
    }

    public string Titre
    {
        get { return titre; }
    }
}