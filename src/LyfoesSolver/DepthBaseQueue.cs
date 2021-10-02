using System.Linq;
using System.Collections.Generic;

namespace LyfoesSolver
{
	/// <summary>
	/// Default queue. add all games with no special behaviour.
	/// Depth has a little difference with move. For example if algorithm move
	/// blue ball from pipe one to pipe 2 three times, depth increase by 1 but 
	/// move increase by 2.
	/// </summary>
	public class DepthBaseQueue : Queue<Game>, IGameQueue
    {
        public bool Any()
        {
            return this.Any(x=>true);
        }
    }
}
