namespace apbd4.Endpoints;

using apbd4.Models;

public static class AnimalMappings {
    public static void MapAnimalEndpoints(this WebApplication app) {
        app.MapGet("/animals", (Animal animal, int id) => {
            return Results.Ok();
        });
    }
}
