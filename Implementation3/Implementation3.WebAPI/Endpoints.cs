using Implementation3.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using System.Collections.Concurrent;

namespace Implementation3.WebAPI
{
    public static class Endpoints
    {
        private static ConcurrentDictionary<Guid, (IIteratorService service, CancellationTokenSource cts)> Dictionary { get; } = new();

        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("getstatus/{id}", async (Guid id, HttpContext context) =>
            {
                if (Dictionary.TryGetValue(id, out var value))
                {
                    var status = await value.service.GetStatus();

                    if (status is null)
                        return Results.NoContent();

                    if (status.Status == StatusType.Completed)
                        Dictionary.TryRemove(id, out var _);

                    return Results.Ok(status);
                }
                else return Results.NotFound();
            });

            app.MapPost("startcalculation", (CalculatorInput input, [FromServices] IIteratorService service) =>
            {
                var id = Guid.NewGuid();
                var cts = new CancellationTokenSource();
                Task.Run(async () => await service.StartSequence(input, cts.Token));

                Dictionary.AddOrUpdate(id, (service, cts), (key, value) => value);

                return new { id };
            });
        }
    }
}
