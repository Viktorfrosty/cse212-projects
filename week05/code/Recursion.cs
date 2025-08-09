using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1

        // If n is less than or equal to 0, return 0
        if (n <= 0)
            return 0;

        // Recursive handling n^2 + SumSquaresRecursive(n-1)
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2

        // If the word have the desired size, add it to the results.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        // Iteration through the letters and build permutations.
        for (int i = 0; i < letters.Length; i++)
        {
            // Select the current letter and add it to the word.
            char currentLetter = letters[i];
            // Remove the selected letter from the array.
            string remainingLetters = letters.Remove(i, 1);
            // Recursive call with the updated word and remaining letters (this is going to contain all the possible permutations)
            PermutationsChoose(results, remainingLetters, size, word + currentLetter);
        }

    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases.
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3

        // Initialize the dictionary for memoization.
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }
        // Check if the result are computed.
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }
        // If not, they will be computed, the result would be computed recursively and store it in the dictionary for future references.
        if (s < 0)
        {
            return 0; // If 's' is negative, there are no ways to climb the stairs.
        }
        // Solve using recursion.
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        // Store the result in the dictionary.
        remember[s] = ways; 
        // Return the computed result.
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4

        // Add the pattern to the results if there are no wildcards left.
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }
        // Replace the first wildcard with '0' and '1'.
        int wildcardIndex = pattern.IndexOf('*');
        string patternWithZero = pattern.Remove(wildcardIndex, 1).Insert(wildcardIndex, "0");
        string patternWithOne = pattern.Remove(wildcardIndex, 1).Insert(wildcardIndex, "1");
        // Recursive calls for both cases.
        WildcardBinary(patternWithZero, results);
        WildcardBinary(patternWithOne, results);

    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // TODO Start Problem 5

        // Initialize the current path if it is null.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }
        // Check if the current position is out of bounds or if it is a wall.
        if (x < 0 || x >= maze.Width || y < 0 || y >= maze.Height)
        {
            return;
        }
        // Check if the current position is a valid move.
        if (maze.Data[y * maze.Width + x] == 0 || !maze.IsValidMove(currPath, x, y))
        {
            return;
        }
        // Make a copy of the current path for this branch
        var newPath = new List<ValueTuple<int, int>>(currPath);
        newPath.Add((x, y));
        // Check if the current position is the end of the maze.
        if (maze.IsEnd(x, y))
        {
            results.Add($"<List>{{{string.Join(", ", newPath.Select(p => $"({p.Item1}, {p.Item2})"))}}}");
            return;
        }
        // right direction.
        SolveMaze(results, maze, x + 1, y, newPath);
        // down direction.
        SolveMaze(results, maze, x, y + 1, newPath);
        // left direction.
        SolveMaze(results, maze, x - 1, y, newPath);
        // up direction.
        SolveMaze(results, maze, x, y - 1, newPath);
    }
}