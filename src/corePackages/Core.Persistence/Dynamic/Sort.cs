namespace Core.Persistence.Dynamic;

/// <summary>
/// It allows the direction of the field to be determined.
/// </summary>
/// <remarks>
/// Sorts according to the specified field and direction. 
/// It is used to sort ascending and descending. 
/// </remarks>
public class Sort
{
    /// <summary>
    /// The field whose direction is to be determined.
    /// </summary>
    public string Field { get; set; }

    /// <summary>
    /// Determines in which direction the field will be.
    /// </summary>
    public string Dir { get; set; }


    /// <summary>
    /// Specifies the direction of the field.
    /// </summary>
    public Sort()
    {
    }

    /// <summary>
    /// Specifies the direction of the field.
    /// </summary>

    public Sort(string field, string dir)
    {
        Field = field;
        Dir = dir;
    }
}