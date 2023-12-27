using Ebd.Mobile.Droid.Infrastructure;
using Ebd.Mobile.Infrastructure;

[assembly: Dependency(typeof(FilePathManager))]
namespace Ebd.Mobile.Droid.Infrastructure
{
    public class FilePathManager : IFilePath
    {
        public string GetFullPath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}