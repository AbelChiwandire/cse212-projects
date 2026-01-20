using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A(1), B(5), C(10) and dequeue once
    // Expected Result: C
    // Defect(s) Found: The last element is never checked because the loop is off-by-one and never reaches.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("C", result);
    }

    [TestMethod]
    // Scenario: Enqueue A(1), B(2) and dequeue twice
    //Expected Result: B, A
    //Defect(s) Found: Item was not being removed from the queue after being dequeued
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A(5), B(5), C(5) and dequeue three times
    // Expected Result: A, B, C
    // Defect(s) Found: The condition in the loop in the dequeue method allows later items with the same priority to be chosen first violating FIFO order.
    public void TestPriorityQueue_EqualPriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5); 
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with FIFO among highest only. Enqueue A(1), B(5), C(5), D(10), E(5)
    // Expected: D, B, C, E, A
    // Defect(s) Found:
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 10);
        priorityQueue.Enqueue("E", 5);

        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: No exception was thrown.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
            priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}