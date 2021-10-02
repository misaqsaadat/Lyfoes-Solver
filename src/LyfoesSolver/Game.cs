using System;
using System.Collections.Generic;
using System.Linq;

namespace LyfoesSolver
{
	public class Game
    {
        private CustomSortedList sortedPipes = new CustomSortedList();
        private int _pipeSize;
        private readonly List<Pipe> pipes = new List<Pipe>();

        public int Depth { get; set; }
        public int Point { get; set; }
        public List<Move> Moves { get; set; } = new List<Move>();
        
        /// <summary>
        /// Checks if a game is solved or not.
        /// </summary>
        public bool IsFinished => pipes.All(x => x.IsEmpty);
        
        public Game(int pipeSize)
        {
            _pipeSize = pipeSize;
        }

        public void AddPipe(int number,params string[] colors)
        {
            var balls = colors.Select(x => new Ball(x.ToLower()));
            var pipe = new Pipe(number, _pipeSize, balls);
            pipes.Add(pipe);
            sortedPipes.Add(pipe.GetHashCode());
        }

        /// <summary>
        /// move a ball from a pipe to another.
        /// it will repeat move if possible.
        /// </summary>
        /// <param name="move"></param>
        internal void MoveBall(Move move)
        {
            var fromPipe = pipes.FirstOrDefault(x => x.Number == move.FromPipe);
            var toPipe = pipes.FirstOrDefault(x => x.Number == move.ToPipe);
            int count = 0;
            var ballToMove = fromPipe.Top();
            do
            {
                count++;
                sortedPipes.Remove(fromPipe.GetHashCode());
                var piece = fromPipe.Pop();
                sortedPipes.Add(fromPipe.GetHashCode());
                sortedPipes.Remove(toPipe.GetHashCode());
                toPipe.Push(piece);
                if (toPipe.Completed)
                {
                    pipes.Remove(toPipe);
                    Point++;
                }
                else
                    sortedPipes.Add(toPipe.GetHashCode());
            } while (!fromPipe.IsEmpty && !toPipe.IsFull && fromPipe.Top() == ballToMove);
            move.Count = count;
            Moves.Add(move);
        }

        public Game Clone()
        {
            var game = new Game(_pipeSize);
            game.Point = Point;
            foreach (var pipe in pipes)
                game.pipes.Add(pipe.Clone());
            foreach (var move in Moves)
                game.Moves.Add(move);
            game.sortedPipes = sortedPipes.Clone();
            game.Depth = Depth + 1;
            return game;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Game game))
                return false;
            return sortedPipes.Equals(game.sortedPipes);
        }
        
        /// <summary>
        /// stores list of pipes with at least one ball
        /// </summary>
        public int CorrectCount => sortedPipes.Count;

        /// <summary>
        /// generating possible moves from current game. 
        /// for better performance, not all of possible moves are included
        /// </summary>
        /// <returns></returns>
        public List<Move> GeneratePosibleMoveList()
        {
            var moves = new List<Move>();
            var emptyPipe = pipes.FirstOrDefault(x => x.IsEmpty);
            var hasEmpty = emptyPipe != null;
            //Empty to pipe handled seperately. To pipe can't be full.
            var allToPipeCondidates = pipes.Where(x => !x.IsEmpty && !x.IsFull);

            //empty pipes can not select as fromPipe
            foreach (var fromPipe in pipes.Where(x=>!x.IsEmpty))
            {
                var top = fromPipe.Top();
                //To pipe and from pipe can't be same.
                var toPipeCondidates = allToPipeCondidates.Where(x => x != fromPipe);
                bool added = false;
                foreach (var toPipe in toPipeCondidates.Where(x=> x.Top()==top))
                {
                    added = true;
                    moves.Add(new Move(fromPipe.Number, toPipe.Number, top));
                }
                if (!added && hasEmpty && !fromPipe.AllBallsAreSame())
                    moves.Add(new Move(fromPipe.Number, emptyPipe.Number, top));
            }
            return moves;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, pipes.Select(x=>x.ToString()));
        }

    }
}
