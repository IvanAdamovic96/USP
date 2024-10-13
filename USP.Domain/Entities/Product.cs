using MongoDB.Entities;
using USP.Domain.Enums;

namespace USP.Domain.Entities;


//Za administratorsku stranu
public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    //Embedded
    public User User { get; set; }
    
    //Referenced 1-1
    public One<User> ReferencedOneToOneUser { get; set; }
    
    //Referenced 1-n (1 proizvod - n usera)
    public Many<User, Product> ReferencedOneToManyUser { get; set; }
    
    //Referenced n-n
    [OwnerSide]
    public Many<User, Product> ReferencedManyToManyUser { get; set; }
    
    //public Category Category { get; set; }


    public Product()
    {
        this.InitOneToMany(() => ReferencedOneToManyUser);
        this.InitManyToMany(() => ReferencedOneToManyUser, user => user.ReferencedManyToManyProducts);
    }
    
}
