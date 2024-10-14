using MongoDB.Entities;

namespace USP.Domain.Entities;


//Za prikaz i render na strani
public class ProductEmbedded : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    //Embedded
    public User User { get; set; }
    //Referenced 1-1
    public User ReferencedOneToOneUser { get; set; }
    //Referenced 1-n (1 proizvod - n usera)
    public List<User> ReferencedOneToManyUser { get; set; }
    //Referenced n-n
    public List<User> ReferencedManyToManyUser { get; set; }
}