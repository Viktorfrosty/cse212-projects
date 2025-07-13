using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items and priorities: phebe (2), hecate (5), apollo (3) and
    // run until the queue is empty
    // Expected Result: hecate, apollo, phebe
    // Defect(s) Found: none.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("phebe", 2);
        priorityQueue.Enqueue("hecate", 5);
        priorityQueue.Enqueue("apollo", 3);

        var result = new List<string>();
        while (priorityQueue.Length > 0)
        {
            result.Add(priorityQueue.Dequeue());
        }

        Assert.AreEqual("hecate, apollo, phebe", string.Join(", ", result));
    }

    [TestMethod]
    // Scenario: Create a queue with the following items and priorities: phebe (12), hecate (5), apollo (3) and
    // run until the queue is empty
    // Expected Result: hecate, apollo, phebe
    // Defect(s) Found: none.
    public void TestPriorityQueue_2()
    {
        var phebe = new PriorityItem("phebe", 12);
        var hecate = new PriorityItem("hecate", 5);
        var apollo = new PriorityItem("apollo", 3);

        PriorityItem[] expectedResult = { phebe, hecate, apollo };

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(phebe.Value, phebe.Priority);
        priorityQueue.Enqueue(hecate.Value, hecate.Priority);
        priorityQueue.Enqueue(apollo.Value, apollo.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have run out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    // Add more test cases as needed below.
}