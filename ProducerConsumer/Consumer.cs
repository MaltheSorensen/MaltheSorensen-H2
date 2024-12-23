﻿
/// <summary>
/// This class can consume objects of type T from a Queue
/// </summary>
/// <typeparam name="T">Type of objects consumed</typeparam>
public class Consumer<T> where T : new()
{
    private QueueWithLimit<T> _queue;
    private int _itemsConsumed;
    private readonly object _consumeLock = new object();

    /// <summary>
    /// Create a new consumer.
    /// </summary>
    /// <param name="queue">Queue from which objects are consumed</param>
    public Consumer(QueueWithLimit<T> queue)
    {
        _queue = queue;
        _itemsConsumed = 0;
    }

    /// <summary>
    /// Consume a single object from the Queue.
    /// </summary>
    public void Consume()
    {
        if (_queue.CountCurrent > 0)
        {
            var item = _queue.Remove();
            lock (_consumeLock)
            {
                _itemsConsumed++;
            }
        }
    }

    public void Consume2()
    {
        if ( _queue.CountCurrent > 0)
        {
            var item = _queue.Remove();
            lock (_consumeLock)
            {
                _itemsConsumed++;
            }
        }
    }

    /// <summary>
    /// Returns the total number of objects consumed by this consumer.
    /// </summary>
    public int ItemsConsumed
    {
        get { return _itemsConsumed; }
    }
}
