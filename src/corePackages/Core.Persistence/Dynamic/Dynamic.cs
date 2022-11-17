namespace Core.Persistence.Dynamic
{
    /// <summary>
    /// Provides dynamically filtering and sorting.
    /// </summary>
    public class Dynamic
    {
        public IEnumerable<Sort>? Sort { get; set; }
        public Filter? Filter { get; set; }

        public Dynamic()
        {
        }

        public Dynamic(IEnumerable<Sort>? sort, Filter? filter)
        {
            Sort = sort;
            Filter = filter;
        }
    }
}
