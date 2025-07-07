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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // plan:
        // 1. Validate input: if 'length' <= 0, throw an ArgumentOutOfRangeException.
        // 2. Allocate a double array 'result' of size 'length'.
        // 3. For each index i from 0 till 'length' value:
        //    a. Compute the (i+1) multiple as number * (i + 1).
        //    b. Store it in result[i].
        // 4. Return the filled result array.

        // Ensure 'length' is valid
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "length must be positive");
        }

        // Create the result array to hold each multiple.
        double[] result = new double[length];

        // Fill the array: result[i] = number * (i + 1)
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Return the filled result array containing the multiples of the number.
        return result;

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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // plan:
        // 1. Validate input: if 'amount' <= 0 or 'amount' > data.Count, throw an ArgumentOutOfRangeException.
        // 2. create a for loop that will iterate 'amount' times.
        // 3. In each iteration:
        //    a. Store the last element of the list in a temporary variable.
        //    b. Shift all elements to the right by one position.
        //    c. Place the stored last element at the front of the list.
        // 4. After the loop, the list will be rotated to the right by 'amount'.
        
        // Ensure 'amount' is valid
        if (amount <= 0 || amount > data.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "amount must be in the range of 1 to data.Count, inclusive");
        }

        // iterate 'amount' times:
        for (int i = 0; i < amount; i++)
        {
            // Store the last element of the list
            int lastIndex = data[data.Count - 1];

            // Shift all elements to the right
            for (int j = data.Count - 1; j > 0; j--)
            {
                data[j] = data[j - 1];
            }

            // Place the last element at the front
            data[0] = lastIndex;
        }
    }
}
