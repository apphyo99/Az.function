namespace Az.Models
{
    public record Product(
        string id,
        string category,
        string name,
        int quantity,
        decimal price,
        bool clearance
    );
}