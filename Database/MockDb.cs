namespace apbd4.Database;

using apbd4.Models;

public class MockDb : IDatabase {
    public static List<Animal> Animals = new() {
        new Animal{name = "Animal1", category = "Category1", mass = 20.5, color = "Yellow", id = ++Animal.counter},
        new Animal{name = "Animal2", category = "Category2", mass = 30.5, color = "White", id = ++Animal.counter},
        new Animal{name = "Animal3", category = "Category3", mass = 40.7, color = "Brown", id = ++Animal.counter}
    };

    public static List<Visit> Visits = new() {
        new Visit{animal_id = 1, description = "Sample description", date = DateOnly.Parse("2024-04-11"), price = 10.10}
    };

    public MockDb() {
    }

    public List<Visit> GetVisits(int id) {
        List<Visit> visits = new();
        visits.AddRange(Visits.FindAll((Visit v) => v.animal_id == id));

        return visits;
    }

    public void AddVisit(Visit visit) {
        Visits.Add(visit);
    }

    public List<Animal> GetList() {
        return Animals;
    }
    public Animal? GetById(int id) {
        return Animals.Find((Animal a) => a.id == id);
    }
    public void Delete(Animal a) {
        Animals.Remove(a);
    }
    public void Add(Animal a) {
        Animals.Add(a);
    }
    public bool EditById(Animal animal) {
        Animal? a = GetById(animal.id);
        if(a == null) {
            return false;
        }

        a.name = animal.name;
        a.category = animal.category;
        a.color = animal.color;
        a.mass = animal.mass;
        return true;
    }
}
