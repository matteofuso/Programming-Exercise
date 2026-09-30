package com.matteofuso.adt;

import com.matteofuso.adt.exceptions.LinkedListOutOfBoundExeption;

public class LinkedList<T> implements ADT<T>{
    private class Node
    {
        public Node(T obj, Node next)
        {
            this.obj = obj;
            this.next = next;
        }

        T obj;
        Node next;
    }

    private Node getNode(int i)
    {
        Node head = this.head;
        for (int j = 0; j < i; j++)
        {
            head = head.next;
        }
        return head;
    }

    public LinkedList()
    {
        empty();
    }

    public LinkedList(T[] array)
    {
        empty();
        for (T item : array)
        {
            add(item);
        }
    }

    public void add(T element, int index)
    {
        if (index > length)
        {
            throw new LinkedListOutOfBoundExeption();
        }
        Node before = getNode(index);
        Node after = before.next;
        before.next = new Node(element, after);
        if (after == null)
        {
            tail = before.next;
        }
        length++;
    }

    public void add(T element)
    {
        add(element, length);
    }

    public void addFirst(T element)
    {
        add(element, 0);
    }

    public T get(int i)
    {
        if (i >= length)
        {
            throw new LinkedListOutOfBoundExeption();
        }
        return getNode(i + 1).obj;
    }

    public T get()
    {
        return get(length);
    }

    public T getFirst()
    {
        return get(0);
    }

    public void empty() {
        head = tail = new Node(null, null);
        length = 0;
    }

    @Override
    public boolean isEmpty() {
        return head == tail;
    }

    @Override
    public String toString()
    {
        StringBuilder s = new StringBuilder("[");
        Node head = this.head.next;
        for (int i = 0; i < length; i++)
        {
            s.append(head.obj);
            if (i != length - 1)
            {
                s.append(", ");
            }
            head = head.next;
        }
        s.append("]");
        return s.toString();
    }

    int length;
    Node head;
    Node tail;
}
