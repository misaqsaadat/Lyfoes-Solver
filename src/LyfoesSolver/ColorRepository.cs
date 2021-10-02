using System.Collections.Generic;
using System.Linq;

namespace LyfoesSolver
{
    /// <summary>
    /// convention between colors and numbers. each number represents a color
    /// </summary>
	static class ColorRepository
    {
        public static Dictionary<string, byte> ColorDictionary = new Dictionary<string, byte>();

        public static byte GetNumber(string color)
        {
			if (ColorDictionary.ContainsKey(color))
                return ColorDictionary[color];
			if (!ColorDictionary.Any())
			{
                ColorDictionary[color] = 1;
                return 1;
            }
            var max = ColorDictionary.Select(x => x.Value).Max();
            max++;
            ColorDictionary[color] = max;
            return max;
        }

        public static string GetColor(byte number)
        {
            return ColorDictionary.First(x=>x.Value==number).Key;
        }
    }
}
