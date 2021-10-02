using System;
using System.Collections.Generic;
using System.Linq;

namespace LyfoesSolver
{
    public static class Solver
    {
        public static Game SolveDFS(Game game)
        {
            var visitedGames = new List<Game>();
            var possibleMoves = game.GeneratePosibleMoveList();
            foreach (var possibleMove in possibleMoves)
            {
                var nextGame = game.Clone();
                nextGame.MoveBall(possibleMove);
                if (visitedGames.Contains(nextGame))
                    continue;
                visitedGames.Add(nextGame);
                if (nextGame.IsFinished)
                    return nextGame;
                var result = SolveDFS(nextGame);
                if (result.IsFinished)
                    return result;
            }
            return game;
        }

        public static GameSolveResult SolveBFS(Game game, IGameQueue queue)
        {
            var visitedGames = new CustomVisitedGames();
            queue.Enqueue(game);
            while (queue.Any())
            {
                var currentGame = queue.Dequeue();
                if (visitedGames.Contains(currentGame))
                    continue;
                visitedGames.Add(currentGame);
                if (currentGame.IsFinished)
                {
                    return new GameSolveResult
                    {
                        CheckedGames = visitedGames.Count(),
                        Depth = currentGame.Depth,
                        Moves = currentGame.Moves,
                    };
                }
                    
                var possibleMoves = currentGame.GeneratePosibleMoveList();
                foreach (var possibleMove in possibleMoves)
                {
                    var nextGame = currentGame.Clone();
                    nextGame.MoveBall(possibleMove);
                    queue.Enqueue(nextGame);
                }
            }
            throw new Exception($"Can not solve game after checking {visitedGames.Count()} states");
        }
    }
}
