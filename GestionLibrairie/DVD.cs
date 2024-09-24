public class DVD : Media
{
    private string realisateur { get; set; }
    private string duree { get; set; }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine("Realisateur: " + realisateur);
        Console.WriteLine("Duree: " + duree);
    }
}