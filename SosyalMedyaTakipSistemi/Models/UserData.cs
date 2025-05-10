public static class UserData
{
    public static Dictionary<string, HashSet<string>> Users = new()
    {
        { "Ayse", new HashSet<string> { "Ali", "Veli" } },
        { "Ali", new HashSet<string> { "Ayse", "Mehmet" } },
        { "Mehmet", new HashSet<string> { "Ali", "Veli" } }
    };

    public static Dictionary<string, Queue<string>> SonZiyaretler = new();
    public static Dictionary<string, LinkedList<string>> OnerilenTakip = new();
}