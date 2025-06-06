namespace MyCompany.Shared.Cache
{
    public static class CacheHelper
    {
        public static void ClearList<T>(List<T> list)
        {
            list?.Clear();
        }
    }
}