namespace Restaurant.Domain.Models;

public class Dish: BaseEntity
{
 
    public string Name { get; private set; }
    public double Price { get; private set; }    

    public Dish(Guid id, string name, double price) 
    {
        Id = id;
        Name = name;
        Price = price;
    }  

    public Dish(string name, double price) : this (id: Guid.NewGuid(), name, price){}

}
