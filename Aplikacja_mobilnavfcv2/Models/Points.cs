using System.Linq;

namespace Aplikacja_gierki.Models
{
    // Klasa statyczna zawieraj�ca list� punkt�w
    public static class Points
    {
        public static readonly int[] Values = Enumerable.Range(0, 11).ToArray();
    }
}
