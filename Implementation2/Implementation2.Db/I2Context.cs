using Microsoft.EntityFrameworkCore;

namespace Implementation2.Db
{
    public class I2Context : DbContext
    {
        public I2Context(DbContextOptions options) : base(options)
        {
        }

        // Map our db functions to entity functions, so we can call them directly, without raw SQL
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IteratorResult>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            builder.Entity<GeneratorResult>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            builder.HasDbFunction(typeof(I2Context).GetMethod(nameof(Divide), new[] { typeof(int), typeof(string), typeof(string) })!);
            builder.HasDbFunction(typeof(I2Context).GetMethod(nameof(Iterate), new[] { typeof(int), typeof(int), typeof(string), typeof(string) })!);
            builder.HasDbFunction(typeof(I2Context).GetMethod(nameof(GenerateIntegers), new[] { typeof(int), typeof(int) })!);
            base.OnModelCreating(builder);
        }

        public DbSet<ProcResult> Results => Set<ProcResult>();

        public string Divide(int value, string first, string last) => throw new NotSupportedException("Only usable in Linq to SQL expressions");
        public IQueryable<IteratorResult> Iterate(int start, int end, string first, string last) => FromExpression(() => Iterate(start, end, first, last));
        public IQueryable<GeneratorResult> GenerateIntegers(int start, int end) => FromExpression(() => GenerateIntegers(start, end));
        public IQueryable<ProcResult> InsertAndReturnResults(int start, int end, string first, string last) => FromExpression(() => Results.FromSqlInterpolated($"EXEC [dbo].[InsertResults] {start},{end},{first},{last}"));
    }
}
