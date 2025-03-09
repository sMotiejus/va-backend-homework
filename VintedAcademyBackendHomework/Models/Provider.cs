namespace VintedAcademyBackendHomework.Models;

public class Provider(string name, Dictionary<string, int> packages)
{
    public string GetName()
    {
        return name;
    }

    public int GetPackagePrice(string packageName)
    {
        return packages.GetValueOrDefault(packageName, -1);
    }

    public bool PackageNameExists(string packageName)
    {
        return packages.ContainsKey(packageName);
    }
}