using Windows.ApplicationModel.Resources;

namespace GitPocket.Business
{
    public static class Translation
    {
        public static string GetTranslation(string key)
        {
            return ResourceLoader.GetForViewIndependentUse().GetString(key);
        }
    }
}
