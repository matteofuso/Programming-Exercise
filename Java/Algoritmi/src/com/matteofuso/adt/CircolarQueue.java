package com.matteofuso.adt;

import com.matteofuso.adt.Queue;

public class CircolarQueue<T> implements Queue<T>{
    private final int INIT_SIZE =  8;
    private Object[] array;
    private int left, right; // Ignoriamo overflow

    public CircolarQueue()
    {
        array = new Object[INIT_SIZE];
        left = right = 0;
    }

    private void resize()
    {
        Object[] newArray = new Object[array.length * 2];
        int head, tail;

        head = left % array.length;
        tail = right % array.length;

        if (tail > head)
        {
            System.arraycopy(array, head, newArray, 0, tail - head);
        } else {
            System.arraycopy(array, head, newArray, 0, array.length - head);
            System.arraycopy(array, 0, newArray, array.length - head, tail);
        }

        array = newArray;
        right = right - left;
        left = 0;
    }

    public void enqueue(T item)
    {
        if (right - left == array.length)
        {
            resize();
        }

        array[right % array.length] = item;
        right++;
    }

    public T dequeue()
    {
        T item = getFront();
        array[left % array.length] = null;
        left++;
        return item;
    }

    public T getFront()
    {
        if (left == right)
        {
            throw new Queue.EmptyQueueException();
        }

        return (T) array[left % array.length];
    }
}
