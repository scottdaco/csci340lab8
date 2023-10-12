using Microsoft.EntityFrameworkCore;
using RazorPagesLizard.Data;

namespace RazorPagesLizard.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesLizardContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesLizardContext>>()))
        {
            if (context == null || context.Lizard == null)
            {
                throw new ArgumentNullException("Null RazorPagesLizardContext");
            }

            // Look for any Lizards.
            if (context.Lizard.Any())
            {
                return;   // DB has been seeded
            }

            context.Lizard.AddRange(
                new Lizard
                {
                    name = "Mexican Alligator Lizard",
                    region = "mexico",
                    length = "6in-12in"
                },

                new Lizard
                {
                    name = "Horned lizard",
                    region = "north america",
                    length = "4in"
                },

                new Lizard
                {
                    name = "western skink",
                    region = "western USA",
                    length = "4in-8in"
                },

                new Lizard
                {
                    name = "blue crested lizard",
                    region = "southern asia",
                    length = "12in-16in"
                }
            );
            context.SaveChanges();
        }
    }
}