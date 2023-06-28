using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Customers")]
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Customer() { }

    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}