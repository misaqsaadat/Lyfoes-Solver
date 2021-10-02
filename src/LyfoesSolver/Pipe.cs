using System.Collections.Generic;
using System.Linq;

namespace LyfoesSolver
{
	public class Pipe
    {
		private readonly Stack<Ball> _balls = new Stack<Ball>();
        public int Number { get; set; }
        int? _hashCode = 0;
        private int _max;

        public bool IsEmpty => _balls.Count == 0;

        public bool IsFull => _balls.Count == _max;

        public byte Top()
        {
            return _balls.Peek().Number;
        }

        public Pipe(int number,int max,IEnumerable<Ball> balls)
        {
            _hashCode = null;
            Number = number;
            _max = max;
            foreach (var item in balls)
                _balls.Push(item);
        }

        public void Push(Ball ball)
        {
            _hashCode = null;
            _balls.Push(ball);
        }

        public Ball Pop()
        {
            _hashCode = null;
            return _balls.Pop();
        }

        public bool Completed => IsFull && AllBallsAreSame();

        public bool AllBallsAreSame()
        {
            if (!_balls.Any())
                return true;
            var topNumber = Top();
            foreach (var piece in _balls)
                if (piece.Number != topNumber)
                    return false;
            return true;
        }

        public Pipe Clone()
        {
            return new Pipe(Number, _max,_balls.Reverse());
        }

        public override string ToString()
        {
            return string.Join("-", _balls.Select(x=>ColorRepository.GetColor(x.Number)));
        }

        

        public override int GetHashCode()
        {
            if (_hashCode.HasValue)
                return _hashCode.Value;
            var value = 0;
            foreach (var item in _balls)
            {
                value <<= 5;
                value += item.Number;
            }
            _hashCode = value;
            return value;
        }
    }
}
