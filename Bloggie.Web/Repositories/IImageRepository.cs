namespace Bloggie.Web.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file); //once the upload has been successful the service will provide the URL back, URL will be saved in database
    }
}
