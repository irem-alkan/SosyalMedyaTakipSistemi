public static class UserData
{
    public static Dictionary<string, HashSet<string>> Users = new()
    {
        { "Ayse", new HashSet<string> { "Ali", "Veli", "Mehmet", "Fatma", "Ece", "Deniz", "Zeynep", "Burak" } },
        { "Ali", new HashSet<string> { "Ayse", "Mehmet", "Zeynep", "Cem", "Fatma", "Burak" } },
        { "Mehmet", new HashSet<string> { "Ali", "Veli", "Deniz", "Burak", "Cem" } },
        { "Veli", new HashSet<string> { "Fatma", "Deniz", "Zeynep", "Ayse", "Ece" } },
        { "Fatma", new HashSet<string> { "Ayse", "Ece", "Zeynep", "Mehmet", "Cem" } },
        { "Ece", new HashSet<string> { "Ayse", "Deniz", "Fatma", "Cem", "Burak" } },
        { "Deniz", new HashSet<string> { "Mehmet", "Zeynep", "Ece", "Cem", "Ali" } },
        { "Zeynep", new HashSet<string> { "Ali", "Veli", "Fatma", "Deniz", "Ayse" } },
        { "Burak", new HashSet<string> { "Mehmet", "Zeynep", "Fatma", "Cem", "Ece" } },
        { "Cem", new HashSet<string> { "Ayse", "Ali", "Burak", "Mehmet", "Deniz" } },
        // Yeni kullanýcýlar — daha da geniþletme
        { "Seda", new HashSet<string> { "Ali", "Ayse", "Zeynep", "Burak" } },
        { "Murat", new HashSet<string> { "Fatma", "Ece", "Deniz", "Veli" } },
        { "Aslý", new HashSet<string> { "Ayse", "Seda", "Zeynep", "Ali" } },
        { "Emre", new HashSet<string> { "Murat", "Cem", "Burak", "Ece" } },
        { "Selin", new HashSet<string> { "Ayse", "Mehmet", "Fatma", "Ali" } }
    };

    public static Dictionary<string, Queue<string>> SonZiyaretler = new();
    public static Dictionary<string, LinkedList<string>> OnerilenTakip = new();
}
