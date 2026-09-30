package com.matteofuso.adt;

public interface Queue<T> {
    public class EmptyQueueException extends RuntimeException {}
    public void enqueue(T item);
    public T dequeue();
    public T getFront();
}
