namespace LyfoesSolver
{
	public class Ball
    {
        /// <summary>
        /// use int instead of string for better performance
        /// </summary>
        public byte Number { get; set; }

        public Ball(string color)
        {
            Number = ColorRepository.GetNumber(color);
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
