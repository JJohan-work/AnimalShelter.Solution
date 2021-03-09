
namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public AnimalType Type { get; set; }
    public string EnglishType { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Admittance { get; set; }
    public string Breed { get; set; }
  }

  public enum Gender
  {
    Male,
    Female
  }

  public enum AnimalType
  {
    Birdy,
    Cat,
    Crocodile,
    Doge,
    Giraffe,
    Tarantula,
    Unicorn
  }
}

//type of animal
//name
//gender
//date of admittance
//breed