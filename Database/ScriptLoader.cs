namespace TreesOfData.Database;

public static class ScriptLoader
{
    public static string Load(string fileName)
    {
        using var reader = File.OpenText(Path.Combine(AppContext.BaseDirectory, "Database/SqlScripts", fileName));
        return reader.ReadToEnd();
    }
}