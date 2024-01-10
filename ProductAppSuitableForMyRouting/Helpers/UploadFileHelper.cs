namespace ProductAppSuitableForMyRouting.Helpers
{
    public class UploadFileHelper
    {
        public static async Task<string> UploadFile(IFormFile formFile)
        {
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
            string fullPath = Path.Combine("wwwroot", "Images", fileName);

            using var fileStream = new FileStream(fullPath, FileMode.Create);
            await formFile.CopyToAsync(fileStream);

            return fullPath;
        }
    }
}




//namespace ProductAppSuitableForMyRouting.Helpers
//{
//    public class UploadFileHelper
//    {
//        public async static Task<string> UploadFile(IFormFile formFile)
//        {
//            string directoryPath = Path.Combine("wwwroot", "Images");
//            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
//            string fullPath = Path.Combine(directoryPath, fileName);

//            if (!Directory.Exists(directoryPath))
//            {
//                Directory.CreateDirectory(directoryPath);
//            }

//            using var fileStream = new FileStream(fullPath, FileMode.Create);

//            await formFile.CopyToAsync(fileStream);

//            return fullPath;
//        }
//    }
//}
