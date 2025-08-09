public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // If the value is equal to the current node's data, do nothing (no duplicates allowed).
        if (value == Data)
        {
            return;
        }
        // If the value is less than the current node's data, insert it to the left.
        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        // If the value is greater than the current node's data, insert it to the right.
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        
        // Return true if the value is equal to the current node's data.
        if (value == Data)
        {
            return true;
        }
        // If the value is less than the current node's data, check the left subtree.
        else if (value < Data)
        {
            return Left?.Contains(value) ?? false;
        }
        // If the value is greater than the current node's data, check the right subtree.
        else
        {
            // Value not found in the right subtree.
            if (Right is null)
            {
                return false;
            }
            // Recursively check the right subtree.
            return Right?.Contains(value) ?? false;
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // If the current node is null, return 0 (base case).
        int leftHeight = Left?.GetHeight() ?? 0;
        // If the current node is null, return 0 (base case).
        int rightHeight = Right?.GetHeight() ?? 0;
        // Return the height of the current node, which is 1 plus the maximum height of its subtrees.
        return 1 + Math.Max(leftHeight, rightHeight);
    }

}