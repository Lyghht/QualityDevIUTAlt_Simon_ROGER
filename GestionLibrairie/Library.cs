public class Library
{
    private List<Media> medias = new List<Media>();

    public Media this[int numeroDeReference_IN]
    {
        get { return medias.FirstOrDefault(m => m.numeroDeReference.get == numeroDeReference_IN); }
    }
}