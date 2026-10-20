using System.IO;
using System.Windows.Forms;

namespace Electronic_Archive.Helpers
{
    public static class FileHelper
    {
        private static readonly string FilesDirectory = Path.Combine(Application.StartupPath, "files");

        public static void DeleteFile(string fileName)
        {
            try
            {
                if (!Directory.Exists(FilesDirectory))
                    return;

                var filePath = Path.Combine(FilesDirectory, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch
            {
                // يمكن تسجيل الخطأ هنا إذا لزم الأمر
            }
        }
    }
}