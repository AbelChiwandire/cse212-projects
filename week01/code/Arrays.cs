public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Allocate the result container with a fixed size equal to the required number of multiples
        var multiples = new double[length];

        // For each position i, store the (i + 1)th multiple of the input number
        // Index 0 corresponds to number * 1, index 1 to number * 2, etc.
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Return the populated array of multiples in ascending order
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Identify the trailing segment of the list that will wrap around to the front
        // This segment consists of the last 'amount' elements, preserving their order
        var range = data.GetRange(data.Count - amount, amount);

        // Remove the trailing segment so the remaining elements shift right
        data.RemoveRange(data.Count - amount, amount);

        // Prepend the extracted segment to complete the right rotation
        data.InsertRange(0, range);
    }
}
