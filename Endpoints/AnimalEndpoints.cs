namespace apbd4.Endpoints;

using apbd4.Models;
using apbd4.Controllers;

public static class AnimalMappings {
    public static void MapAnimalEndpoints(this WebApplication app) {
        app.MapDefaultControllerRoute();
        /*app.MapGet("/animals", () => {
            return TypedResults.Ok(new AnimalController().GetAnimals());
        })
        .WithName("GetAnimals")
        .WithOpenApi();*/
    }
}
