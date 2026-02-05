using FL.Domain.Interfaces;

namespace FL.Domain.Entities;

public class Computer : IEquipment
{
    public string Name { get; } = "Computer/Laptop";
}