public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        if (mat == null || mat.Length == 0)
        {
            return mat;
        }

        int m = mat.Length;
        int n = mat[0].Length;
        int level = 0;
        int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];
        Queue<int[]> queue = new Queue<int[]>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0)
                {
                    queue.Enqueue(new int[] { i, j });
                }
                if (mat[i][j] == 1)
                {
                    mat[i][j] = -1;
                }
            }
        }

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var cell = queue.Dequeue();
                foreach (var dir in dirs)
                {
                    var newRow = cell[0] + dir[0];
                    var newCol = cell[1] + dir[1];
                    if (newRow < 0 || newRow == m || newCol < 0 || newCol == n || mat[newRow][newCol] != -1)
                    {
                        continue;
                    }
                    queue.Enqueue(new int[] { newRow, newCol });
                    mat[newRow][newCol] = level + 1;
                }
            }
            level++;
        }
        return mat;
    }
}