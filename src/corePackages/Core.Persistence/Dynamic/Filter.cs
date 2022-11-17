namespace Core.Persistence.Dynamic
{
    /// <summary>
    /// Filters according to certain parameters.
    /// </summary>
    /// <remarks>
    /// Filters by specified field, operator, value, and logic. 
    /// More than one filter can be specified. 
    /// </remarks>
    public class Filter
    {
        /// <summary>
        /// The field required for the filter operation.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// The Operator to work between field and value.
        /// </summary>  
        public string Operator { get; set; }

        /// <summary>
        /// The value required for the filter operation.
        /// </summary>  
        public string? Value { get; set; }

        /// <summary>
        /// The logic to be added to the filter.
        /// </summary> 
        public string? Logic { get; set; }

        /// <summary>
        /// Multiple filter fields to apply multiple filters.
        /// </summary> 
        public IEnumerable<Filter>? Filters { get; set; }

        public Filter()
        {
        }

        public Filter(string field, string @operator, string? value, string? logic, IEnumerable<Filter>? filters) : this()
        {
            Field = field;
            Operator = @operator;
            Value = value;
            Logic = logic;
            Filters = filters;
        }
    }
}
