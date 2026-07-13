using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several items with different priorities, then dequeue them all.
    // Expected Result: Items come out in order of highest priority first; among equal
    // priorities, the one added first (FIFO) comes out first.
    // Defect(s) Found: Dequeue's loop skipped the last item in the list (index < Count - 1),
    // so the true highest-priority item could be missed. It also used >= instead of >, which
    // picked the LAST of any tied-priority items instead of the first one added.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High2", 5); // same priority as "High", added later

        Assert.AreEqual("High", priorityQueue.Dequeue());   // first of the tied highs
        Assert.AreEqual("High2", priorityQueue.Dequeue());  // second of the tied highs
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Dequeue never removed the item from the internal list (only read its
    // value), so items stayed in the queue and could be dequeued more than once.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}
