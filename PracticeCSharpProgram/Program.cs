using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.ObjectModel;

class Email
{
    static int CalculateSomeValue()
    {
        return 1;
        { /* Implementation */ }
    }
    static int CalculateAnotherValue()
    {
        return 1;
        { /* Implementation */ }
    }
    public class Name
    {
        public string a { get; set; }
    }

    public class Root
    {
        public Name Name { get; set; }
    }
    static async Task Main(string[] args)
    {
        string json = @"{  
    'name': 'John',  
    'age': 30,  
    'city': 'New York'  
}";

        dynamic data = JsonConvert.DeserializeObject(json);

        string name = data.name;
        int age = data.age;


        Task<int> task1 = Task.Run(() => CalculateSomeValue());
        Task<int> task2 = Task.Run(() => CalculateAnotherValue());
        _ = await Task.WhenAll(task1, task2);
        int result1 = task1.Result;
        int result2 = task2.Result;
        Console.WriteLine($"Result 1: {result1}, Result 2: {result2}");



        User<string> users = new User<string>("Message");
        User<int> id = new User<int>(1);
        List<string> list = new List<string>();
        Dictionary<string,int> map = new Dictionary<string,int>();
        map.Add("Message", 1);
        Queue queue = new Queue();
        queue.Enqueue("");

        Collection<string> collection = new Collection<string>();
        collection.Add("");
    }
}

public class User<T>
{
    public User(T msg)
    {
        Console.WriteLine(msg);

    }
}

