public class CD : Media
{
    private string artiste { get; set; }
    private int nombreDePistes { get; set; }

    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine("Artiste: " + artiste);
    }
}