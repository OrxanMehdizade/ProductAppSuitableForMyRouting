namespace ProductAppSuitableForMyRouting.Helpers
{
    public class UploadFileHelper
    {
        public async static Task<string> UploadFile(IFormFile formFile)
        {
            var fail = new FileStream(@$"wwwroot/{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}", FileMode.Create);
            await formFile.CopyToAsync(fail);
            return fail.Name;
        }
    }
}
