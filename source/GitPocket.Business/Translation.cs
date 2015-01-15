using Windows.ApplicationModel.Resources;

namespace GitPocket.Business
{
    public class Translation
    {
        public static string GetTranslation(string key)
        {
            return ResourceLoader.GetForViewIndependentUse().GetString(key);
        }
    }
}
