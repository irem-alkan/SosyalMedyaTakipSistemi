using System.Collections.Generic;

namespace SosyalMedyaTakipSistemi.Models
{
    public static class UserData
    {
        public static Dictionary<string, HashSet<string>> Users = new Dictionary<string, HashSet<string>>()
        {
            { "Ayse", new HashSet<string> { "Ali", "Mehmet", "Veli" } },
            { "Ali", new HashSet<string> { "Ayse", "Mehmet" } },
            { "Mehmet", new HashSet<string> { "Ali", "Veli" } },
        };
    }
}