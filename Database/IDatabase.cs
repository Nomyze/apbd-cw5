namespace apbd4.Database;

using apbd4.Models;

public interface IDatabase {
    public List<Animal> GetList();
    public Animal? GetById(int id);
    public void Delete(Animal a);
    public void Add(Animal a);
    public bool EditById(Animal animal);
    public List<Visit> GetVisits(int id);
    public void AddVisit(Visit visit);
}
