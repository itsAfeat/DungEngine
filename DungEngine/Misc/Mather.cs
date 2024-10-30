namespace DungEngine.Misc
{
    public static class Mather
    {
        public static T[,] To2DArray<T>(IList<T[]> arrays)
        {
            int minorLength = arrays[0].Length;
            T[,] result = new T[arrays.Count, minorLength];
            
            for (int i = 0; i < arrays.Count; i++)
            {
                var arr = arrays[i];
                if (arr.Length != minorLength)
                { throw new ArgumentException("Not all arrays were the same length"); }

                for (int j = 0; j < minorLength; j++)
                { result[i,j] = arr[j]; }
            }
            return result;
        }
    }
}