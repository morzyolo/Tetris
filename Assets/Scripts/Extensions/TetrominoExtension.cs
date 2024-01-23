using System.Linq;
using Tetrominoes;

namespace Extensions
{
	public static class TetrominoExtension
	{
		public static int MinCellsY(this Tetromino tetromino)
			=> tetromino.Data.Cells.Min(cell => cell.y);

		public static int MaxCellsY(this Tetromino tetromino)
			=> tetromino.Data.Cells.Max(cell => cell.y);

		public static int Height(this Tetromino tetromino)
			=> tetromino.MaxCellsY() - tetromino.MinCellsY();
	}
}