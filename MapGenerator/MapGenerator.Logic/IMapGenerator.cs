namespace MapGeneration.Logic
{
    public interface IMapGenerator
    {
        Map Create(int length, int width, int height);
    }
}