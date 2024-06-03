namespace Gimji.Repository
{
    public interface ImageRepository
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);
        bool DeleteImage(string imageFileName);
    }
}
