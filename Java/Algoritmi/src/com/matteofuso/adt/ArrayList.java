package com.matteofuso.adt;

public class ArrayList<T> implements ADT<T> {
    public ArrayList() {
        this.listItems = new Object[INITIAL_CAPACITY];
        this.size = 0;
    }

    public ArrayList(T[] items)
    {
        this.listItems = new Object[INITIAL_CAPACITY];
        this.size = 0;
        if (items.length > this.listItems.length)
        {
            resize(items.length * 2);
        }
        System.arraycopy(items, 0, this.listItems, 0, items.length);
        this.size += items.length;
    }

    private void resize(int size){
        if (size < 1) {
            throw new IllegalArgumentException();
        }
        Object[] newElements = new Object[size];
        System.arraycopy(this.listItems, 0, newElements, 0, Math.min(this.size, size));
        this.listItems = newElements;
    }

    public void add(T element) {
        if (this.size == this.listItems.length) {
            resize(this.listItems.length * 2);
        }
        this.listItems[this.size++] = element;
    }

    public void add(T[] items)
    {
        if (this.size + items.length > listItems.length)
        {
            resize((this.size + items.length) * 2);   
        }
        System.arraycopy(items, 0, this.listItems, this.size, items.length);
        this.size += items.length;
    }

    public T get(int index) {
        if (index < 0 || index >= size) {
            throw new IndexOutOfBoundsException();
        }
        return (T) listItems[index];
    }

    public T get() {
        return get(this.size - 1);
    }

    public int length()
    {
        return this.size;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("[");
        for (int i = 0; i < size; i++) {
            sb.append(listItems[i]);
            if (i < size - 1) {
                sb.append(", ");
            }
        }
        sb.append("]");
        return sb.toString();
    }

    @Override
    public void empty() {
        this.size = 0;
    }

    @Override
    public boolean isEmpty() {
        return this.size == 0;
    }

    final int INITIAL_CAPACITY = 8;
    Object[] listItems;
    int size;
}
