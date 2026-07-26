namespace Tests.Utils;
 
public static class UserGenerator
{
    public static string GenerateEmail()
    {
        return $"test{Guid.NewGuid():N}@mailinator.com";
    }
 
    public static string GenerateFirstName()
{
    string[] firstNames =
    {
        "John",
        "Max",
        "Alex",
        "James",
        "Michael",
        "Daniel",
        "Robert",
        "David",
        "Chris",
        "Andrew"
    };
 
    return firstNames[Random.Shared.Next(firstNames.Length)];
}
 
    public static string GenerateLastName()
    {
        return $"Smith{Random.Shared.Next(1000, 9999)}";
    }
 
    public static string GeneratePassword(int length = 8)
{
    const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string lower = "abcdefghijklmnopqrstuvwxyz";
    const string numbers = "0123456789";
    const string special = "!@#$%^&*";
 
    var random = Random.Shared;
 
    var password = new List<char>
    {
        upper[random.Next(upper.Length)],
        lower[random.Next(lower.Length)],
        numbers[random.Next(numbers.Length)],
        special[random.Next(special.Length)]
    };
 
    string allChars = upper + lower + numbers + special;
 
    while (password.Count < length)
    {
        password.Add(allChars[random.Next(allChars.Length)]);
    }
 
  
    return new string(password
        .OrderBy(_ => random.Next())
        .ToArray());
}
}