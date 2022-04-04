using Implementation2.Db;
using Microsoft.EntityFrameworkCore;

namespace Implementation2.Web.Data
{
    public class GeneratorService
    {
        IDbContextFactory<I2Context> Factory { get; }

        public GeneratorService(IDbContextFactory<I2Context> factory)
        {
            Factory = factory;
        }

        public IEnumerable<GeneratorData> GetData(int start, int end, string first, string last) 
        {
            // Using a factory here because the caller (blazor component) lifetime is different than the default scope of a request (it's a persistent SignalR connection), so it's a scope mismatch.
            using var context = Factory.CreateDbContext();

            return context.InsertAndReturnResults(start, end, first, last).AsEnumerable().Select((f, index) => new GeneratorData(start + index, f.Value)).ToList();

            // Note: I'd choose an ad-hoc approach instead, as below... but the requirement is to insert into and read from a db table

            //return context.Iterate(start, end, first, last).Select((f, index) => new GeneratorData(start + index, f.Result));
        }
    }
}
