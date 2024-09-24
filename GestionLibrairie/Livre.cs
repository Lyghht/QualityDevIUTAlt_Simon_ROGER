public class Livre : Media
{
    private string auteur { get; set; }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine("Auteur: " + auteur);
    }
}