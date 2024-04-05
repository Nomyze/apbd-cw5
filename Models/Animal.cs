namespace apbd4.Models;

public class Animal {
    private static int counter = 0;
    public int id {get { return this.id; }
        set {
            this.id = ++counter;
        }
    }
    public string name {get; set;}
    public string category {get; set;}
    public double mass {get; set;}
    public string color {get; set;}
}
