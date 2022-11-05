namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static void GameOfLife(int[][] board)
    {
        var result = new int[board.Length][];

        foreach (var (row, rIndex) in board.Select((row, index) => (row, index)))
        {
            result[rIndex] = new int[board[0].Length];

            foreach (var (_, xIndex) in row.Select((cell, index) => (cell, index)))
            {
                var count = GetAroundCells(board, rIndex, xIndex).Count(x => x == 1);

                var isLived = board[rIndex][xIndex] == 1
                    ? count is 2 or 3
                    : count is 3;

                result[rIndex][xIndex] = isLived
                    ? 1
                    : 0;
            }
        }

        foreach (var (row, i) in result.Select((row, i) => (row, i)))
        {
            foreach (var (cell, j) in row.Select((cell, j) => (cell, j)))
            {
                board[i][j] = cell;
            }
        }
    }

    private static IEnumerable<int> GetAroundCells(int[][] board, int rIndex, int xIndex)
    {
        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }

                var temp = 0;

                try
                {
                    temp = board[rIndex + i][xIndex + j];
                }
                catch (Exception)
                {
                    // ignored
                }

                yield return temp;
            }
        }
    }
}

[TestFixture]
public class GameOfLifeTests
{
    [Test]
    public void Example1()
    {
        var board = new[]
        {
            new[] { 0, 1, 0 },
            new[] { 0, 0, 1 },
            new[] { 1, 1, 1 },
            new[] { 0, 0, 0 }
        };

        Kata.GameOfLife(board);

        CollectionAssert.AreEqual(new[]
        {
            new[] { 0, 0, 0 },
            new[] { 1, 0, 1 },
            new[] { 0, 1, 1 },
            new[] { 0, 1, 0 }
        }, board);
    }

    [Test]
    public void Example2()
    {
        var board = new[]
        {
            new[] { 1, 1 },
            new[] { 1, 0 }
        };

        Kata.GameOfLife(board);

        CollectionAssert.AreEqual(new[]
        {
            new[] { 1, 1 },
            new[] { 1, 1 }
        }, board);
    }
}