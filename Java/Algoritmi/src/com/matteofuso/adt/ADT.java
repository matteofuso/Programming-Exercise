package com.matteofuso.adt;

public interface ADT<T> {
    public abstract void empty();
    public abstract boolean isEmpty();
    public abstract T get();
    public abstract T get(int index);
    public abstract void add(T element);
}
