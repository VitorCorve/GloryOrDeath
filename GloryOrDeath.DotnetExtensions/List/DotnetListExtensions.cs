namespace GloryOrDeath.DotnetExtensions.List
{
    public static class DotnetListExtensions
    {
        public static void RemoveByCondition<T>(this List<T> list, T entity, bool condition)
        {
            if (condition)
            {
                list.Remove(entity);
            }
        }
    }
}
