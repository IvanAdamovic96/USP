using Ardalis.SmartEnum;

namespace USP.Domain.Enums;

public abstract class Category(string name, int value) : SmartEnum<Category>(name, value)
{
    public abstract string NameOfCategory { get; }
    public abstract string DescriptionOfCategory { get; }
    //public abstract List<Category> SubCategories { get; }
    
    //primer
    public abstract string CheckSubcategory();
    
    
    public static Category Sport = new SportCategory();
    public static Category Music = new MusicCategory();

    private class SportCategory() : Category(nameof(Sport), 0)
    {
        public override string NameOfCategory => "Sport";
        public override string DescriptionOfCategory => "Neki opis za sport";
        
        //public override List<Category> SubCategories => new List<Category> { Sport, Music };
        
        //primer
        public override string CheckSubcategory()
        {
            return "Subcategory sport";
        }
    }
    
    private class MusicCategory() : Category(nameof(Music), 1)
    {
        public override string NameOfCategory => "Music";
        public override string DescriptionOfCategory => "Neki opis za music";
        
        
        //public override List<Category> SubCategories => new List<Category> { Sport, Music };
        
        //primer
        public override string CheckSubcategory()
        {
            return "Subcategory music";
        }
    }
    
    
}