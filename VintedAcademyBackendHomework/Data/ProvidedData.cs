using VintedAcademyBackendHomework.Models;

namespace VintedAcademyBackendHomework.Data;

public abstract class ProvidedData
{
    public static readonly Provider[] Providers =
    [
        new("LP", new Dictionary<string, int> { { "S", 150 }, { "M", 490 }, { "L", 690 } }),
        new("MR", new Dictionary<string, int> { { "S", 200 }, { "M", 300 }, { "L", 400 } })
    ];
}