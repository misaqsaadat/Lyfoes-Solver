using System;
using System.Linq;

namespace LyfoesSolver.Application
{
    class Program
	{
		static void Main(string[] args)
		{
            var game = GetUltraGame17();

            IGameQueue queue = new PriorityGameQueue();
            SolveGame(game, queue);
            queue = new MinMovesQueue();
            SolveGame(game, queue);
            queue = new DepthBaseQueue();
            SolveGame(game, queue);
        }

        static void SolveGame(Game game, IGameQueue gameQueue)
        {
            var start = DateTime.Now;
            var res = Solver.SolveBFS(game, gameQueue);
            var time = (DateTime.Now - start).TotalMilliseconds;
            Console.WriteLine($"with method {gameQueue.GetType().Name} solved in {time} milliseconds. {Environment.NewLine} visited states : {res.CheckedGames}.{Environment.NewLine} Moves {res.Moves.Sum(x => x.Count)} {Environment.NewLine} Depth : {res.Depth} ");
            Console.WriteLine($"{string.Join(Environment.NewLine, res.Moves)} ");
        }

		static Game GetUltraGame()
		{
            var game = new Game(4);
            game.AddPipe(1, "lightgreen", "purple", "lightgreen", "green");
            game.AddPipe(2, "pink", "darkgreen", "lightpink", "red");
            game.AddPipe(3, "purple", "black", "orange", "lightblue");
            game.AddPipe(4, "lightblue", "darkblue", "lightpink", "gray");
            game.AddPipe(5, "pink", "darkgreen", "lightgreen", "blue");
            game.AddPipe(6, "yellow", "darkblue", "purple", "blue");
            game.AddPipe(7, "gray", "green", "white", "lightblue");
            game.AddPipe(8, "white", "black", "darkblue", "lightgreen");
            game.AddPipe(9, "red", "yellow", "pink", "orange");
            game.AddPipe(10, "pink", "white", "blue", "white");
            game.AddPipe(11, "lightblue", "red", "purple", "blue");
            game.AddPipe(12, "yellow", "yellow", "orange", "gray");
            game.AddPipe(13, "green", "darkgreen", "darkgreen", "black");
            game.AddPipe(14, "red", "black", "orange", "lightpink");
            game.AddPipe(15, "darkblue", "lightpink", "gray", "green");
            game.AddPipe(16);
            game.AddPipe(17);
            return game;
        }
        
        static Game GetUltraGame17()
		{
            var game = new Game(4);
            game.AddPipe(1, "lightblue", "darkgreen", "lightpink", "darkblue");
            game.AddPipe(2, "orange", "yellow", "pink", "lightgreen");
            game.AddPipe(3, "lightblue", "darkgreen", "grey", "lightpink");
            game.AddPipe(4, "darkgreen", "green", "orange", "blue");
            game.AddPipe(5, "orange", "red", "lightgreen", "white");
            game.AddPipe(6, "lightpink", "yellow", "grey", "blue");
            game.AddPipe(7, "pink", "lightpink", "pink", "black");
            game.AddPipe(8, "purple", "blue", "grey", "darkblue");
            game.AddPipe(9, "red", "purple", "lightgreen", "red");
            game.AddPipe(10, "black", "purple", "black", "black");
            game.AddPipe(11, "green", "green", "white", "yellow");
            game.AddPipe(12, "red", "purple", "darkblue", "lightblue");
            game.AddPipe(13, "grey", "darkgreen", "pink", "orange");
            game.AddPipe(14, "white", "white", "lightblue", "yellow");
            game.AddPipe(15, "darkblue", "lightgreen", "green", "blue");
            game.AddPipe(16);
            game.AddPipe(17);
            return game;
        }
	}
}
