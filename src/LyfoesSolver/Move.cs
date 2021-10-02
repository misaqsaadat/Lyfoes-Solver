using System;

namespace LyfoesSolver
{
    /// <summary>
    /// information of a move. from which pipe, to which pipe, which color how many times
    /// </summary>
	public class Move
    {
        public int Count { get; set; }
        public int FromPipe { get; }
        public int ToPipe { get; }
        
        private readonly byte color;

        public Move(int from, int to,byte color)
        {
            FromPipe = from;
            ToPipe = to;
            this.color = color;
        }

        public override string ToString()
        {
            var result = $"move from {FromPipe:00} to {ToPipe:00} color {ColorRepository.GetColor(color)}";
            var all = new string[Count];
            for (int i = 0; i < Count; i++)
                all[i] = result;
            return string.Join(Environment.NewLine, all);
        }
    }
}
