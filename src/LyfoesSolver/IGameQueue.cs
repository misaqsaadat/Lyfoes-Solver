namespace LyfoesSolver
{
    /// <summary>
    /// BFS queue used for solving
    /// </summary>
    public interface IGameQueue
    {
		void Enqueue(Game game);
        Game Dequeue();
        bool Any();
    }
}
