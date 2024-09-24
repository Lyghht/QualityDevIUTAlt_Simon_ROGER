public class Media
{
    protected string titre { get; set; }
    protected int numeroDeReference { get; set; }
    protected int nombreExemplairesDisponibles { get; set; }

    public virtual void AfficherInfos()
    {
        Console.WriteLine("Titre: " + titre);
        Console.WriteLine("Numero de reference: " + numeroDeReference);
        Console.WriteLine("Nombre d'exemplaires disponibles: " + nombreExemplairesDisponibles);
    }
}
