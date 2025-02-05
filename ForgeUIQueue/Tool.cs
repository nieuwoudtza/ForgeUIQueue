using System;
using System.IO;
using System.Linq;

namespace ForgeUIQueue
{
    public static class Tool
    {
        public static string SanitizeFilename(string input)
        {
            // Get the array of invalid file name characters.
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // Use LINQ to filter out any invalid character.
            string valid = new string(input.Where(ch => !invalidChars.Contains(ch)).ToArray());

            return valid;
        }
    }
}
