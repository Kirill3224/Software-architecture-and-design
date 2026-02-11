using SL.Domain.Interfaces;

namespace SL.Domain.Entities;

public class Computer : IEquipment
{
    public string Name { get; } = "Computer/Laptop";
}