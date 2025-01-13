using System.Text.Json;

namespace PersonalExpenseTracking.Abstraction;

public class BaseService<T> where T : class
{
    protected static List<T> GetAll(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return [];
        }

        var json = File.ReadAllText(filePath);

        var result = JsonSerializer.Deserialize<List<T>>(json);
        
        return result ?? [];
    }

    protected static void SaveAll(List<T> entity,string filePath)
    {
       
        var json = JsonSerializer.Serialize(entity);

        File.WriteAllText(filePath, json);
    }
    
 
}
