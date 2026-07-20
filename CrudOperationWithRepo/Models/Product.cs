namespace CrudOperationWithRepo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
//Single Responsibility Principle (SRP)
//a class should have only one reason to change.
//In other words, a class should have only one responsibility or job. This principle helps to keep code organized, maintainable, and easier to understand. By adhering to SRP, developers can create classes that are focused on a single task, making it easier to modify or extend the code without affecting other parts of the system.