using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new double[n];
            for (int i = 0; i < n; i++)
            {
                long sum = 0;
                int cnt = 0;
                for (int j = 0; j < m; j++)
                {
                    int v = matrix[i, j];
                    if (v > 0)
                    {
                        sum += v;
                        cnt++;
                    }
                }
                answer[i] = cnt == 0 ? 0.0 : (double)sum / cnt;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxVal = matrix[0, 0];
            int maxI = 0, maxJ = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxI = i;
                        maxJ = j;
                    }

            int newN = n - 1, newM = m - 1;
            answer = new int[newN, newM];
            int ai = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == maxI) continue;
                int aj = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == maxJ) continue;
                    answer[ai, aj++] = matrix[i, j];
                }
                ai++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int maxVal = matrix[i, 0];
                int maxIdx = 0;
                for (int j = 1; j < m; j++)
                {
                    int v = matrix[i, j];
                    if (v > maxVal)
                    {
                        maxVal = v;
                        maxIdx = j;
                    }
                }
                if (m > 1 && maxIdx != m - 1)
                {
                    int tmp = matrix[i, maxIdx];
                    for (int j = maxIdx; j < m - 1; j++)
                        matrix[i, j] = matrix[i, j + 1];
                    matrix[i, m - 1] = tmp;
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int insertCol = m - 1;
            int[,] res = new int[n, m + 1];
            int[] rowMax = new int[n];
            for (int i = 0; i < n; i++)
            {
                int mx = matrix[i, 0];
                for (int j = 1; j < m; j++)
                    if (matrix[i, j] > mx) mx = matrix[i, j];
                rowMax[i] = mx;
            }
            for (int i = 0; i < n; i++)
            {
                int dj = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == insertCol) res[i, dj++] = rowMax[i];
                    res[i, dj++] = matrix[i, j];
                }
            }
            answer = res;
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (((i + j) & 1) == 1) count++;
            int[] result = new int[count];
            int idx = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (((i + j) & 1) == 1)
                        result[idx++] = matrix[i, j];
            answer = result;
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m || k < 0 || k >= m) return;
            int maxDiag = matrix[0, 0];
            int rowMaxDiag = 0;
            for (int i = 1; i < n; i++)
            {
                int v = matrix[i, i];
                if (v > maxDiag)
                {
                    maxDiag = v;
                    rowMaxDiag = i;
                }
            }
            int rowNeg = -1;
            for (int i = 0; i < n; i++)
                if (matrix[i, k] < 0) { rowNeg = i; break; }
            if (rowNeg == -1 || rowNeg == rowMaxDiag) return;
            for (int j = 0; j < m; j++)
            {
                int t = matrix[rowMaxDiag, j];
                matrix[rowMaxDiag, j] = matrix[rowNeg, j];
                matrix[rowNeg, j] = t;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (m < 2) return;
            if (array == null || array.Length != m) return;
            int col = m - 2;
            int bestRow = 0;
            int bestVal = matrix[0, col];
            for (int i = 1; i < n; i++)
            {
                int v = matrix[i, col];
                if (v > bestVal)
                {
                    bestVal = v;
                    bestRow = i;
                }
            }
            for (int j = 0; j < m; j++)
                matrix[bestRow, j] = array[j];
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int maxVal = matrix[0, j];
                int maxRow = 0;
                for (int i = 1; i < n; i++)
                    if (matrix[i, j] > maxVal) { maxVal = matrix[i, j]; maxRow = i; }
                if (maxRow < (n / 2))
                {
                    long sum = 0;
                    for (int i = maxRow + 1; i < n; i++) sum += matrix[i, j];
                    matrix[0, j] = (int)sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i + 1 < n; i += 2)
            {
                int maxValA = matrix[i, 0];
                int idxA = 0;
                for (int j = 1; j < m; j++)
                    if (matrix[i, j] > maxValA) { maxValA = matrix[i, j]; idxA = j; }
                int maxValB = matrix[i + 1, 0];
                int idxB = 0;
                for (int j = 1; j < m; j++)
                    if (matrix[i + 1, j] > maxValB) { maxValB = matrix[i + 1, j]; idxB = j; }
                int t = matrix[i, idxA];
                matrix[i, idxA] = matrix[i + 1, idxB];
                matrix[i + 1, idxB] = t;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;
            int maxVal = matrix[0, 0];
            int maxIdx = 0;
            for (int i = 1; i < n; i++)
                if (matrix[i, i] > maxVal) { maxVal = matrix[i, i]; maxIdx = i; }
            for (int i = 0; i < maxIdx; i++)
                for (int j = i + 1; j < n; j++)
                    matrix[i, j] = 0;
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] idx = new int[n];
            int[] cnt = new int[n];
            for (int i = 0; i < n; i++)
            {
                idx[i] = i;
                int c = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > 0) c++;
                cnt[i] = c;
            }
            for (int i = 1; i < n; i++)
            {
                int keyIdx = idx[i];
                int keyCnt = cnt[i];
                int p = i - 1;
                while (p >= 0 && cnt[p] < keyCnt)
                {
                    idx[p + 1] = idx[p];
                    cnt[p + 1] = cnt[p];
                    p--;
                }
                idx[p + 1] = keyIdx;
                cnt[p + 1] = keyCnt;
            }
            int[,] buf = new int[n, m];
            for (int r = 0; r < n; r++)
            {
                int src = idx[r];
                for (int j = 0; j < m; j++)
                    buf[r, j] = matrix[src, j];
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = buf[i, j];
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            if (array == null) return null;
            long totalSum = 0;
            long totalCnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var row = array[i];
                if (row != null)
                {
                    totalCnt += row.Length;
                    for (int j = 0; j < row.Length; j++) totalSum += row[j];
                }
            }
            double globalAvg = totalCnt == 0 ? 0.0 : (double)totalSum / totalCnt;
            int keep = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var row = array[i];
                if (row == null) continue;
                long s = 0;
                int c = row.Length;
                for (int j = 0; j < c; j++) s += row[j];
                double avg = c == 0 ? 0.0 : (double)s / c;
                if (avg >= globalAvg) keep++;
            }
            int[][] res = new int[keep][];
            int w = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var row = array[i];
                if (row == null) continue;
                long s = 0;
                int c = row.Length;
                for (int j = 0; j < c; j++) s += row[j];
                double avg = c == 0 ? 0.0 : (double)s / c;
                if (avg >= globalAvg)
                {
                    int[] copy = new int[c];
                    for (int j = 0; j < c; j++) copy[j] = row[j];
                    res[w++] = copy;
                }
            }
            answer = res;
            // end

            return answer;
        }
    }
}
