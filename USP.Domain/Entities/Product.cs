using MongoDB.Entities;
using USP.Domain.Enums;

namespace USP.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    //Embedded
    public User User { get; set; }
    
    //Referenced 1-1
    public One<User> ReferencedUser { get; set; }
    
    //Referenced 1-n (1 proizvod - n usera)
    public Many<User, Product> ReferencedOneToManyUser { get; set; }
    
    //public Category Category { get; set; }


    public Product()
    {
        this.InitOneToMany(() => ReferencedOneToManyUser);
    }
}
