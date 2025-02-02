public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        if (image == null || image.Length == 0 || image[sr][sc] == color)
        {
            return image;
        }

        int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];
        Queue<int[]> queue = new Queue<int[]>();
        int oldColor = image[sr][sc];
        image[sr][sc] = color;
        queue.Enqueue(new int[2] { sr, sc });
        int m = image.Length;
        int n = image[0].Length;

        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();
            foreach (var dir in dirs)
            {
                var newRow = cell[0] + dir[0];
                var newCol = cell[1] + dir[1];
                if (newRow < 0 || newCol < 0 || newRow == m || newCol == n || image[newRow][newCol] == color || image[newRow][newCol] != oldColor)
                {
                    continue;
                }
                queue.Enqueue(new int[] { newRow, newCol });
                image[newRow][newCol] = color;
            }
        }
        return image;
    }
}