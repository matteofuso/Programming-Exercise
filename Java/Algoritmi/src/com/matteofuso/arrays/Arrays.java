package com.matteofuso.arrays;

/**
 * Container of utility methods for arrays
 */
public class Arrays {
    /**
     * Indicate the order in which the array will be sorted
     */
    public enum Order {
        /**
         * Ascending order
         */
        ASCENDING,
        /**
         * Descending order
         */
        DESCENDING
    }

    /**
     * Indicate the algorithm used in the sorting process
     */
    public enum SortAlgorithm {
        /**
         * Selection Sort Algorithm
         */
        SELECTION_SORT,
        /**
         * Insertion Sort Algorithm
         */
        INSERTION_SORT,
        /**
         * Bubble Sort Algorithm
         */
        BUBBLE_SORT,
        /**
         * Merge Sort Algorithm
         */
        MERGE_SORT,
        /**
         * Quick Sort Algorithm
         */
        QUICK_SORT
    }

    /**
     * Indicate the algorithm used in the searching process
     */
    public enum SearchAlgorithm
    {
        /**
         * Linear Search Algorithm
         */
        LINEAR,
        /**
         * Binary Search Algorithm
         */
        BINARY
    }

    private Arrays() {}

    private static <T> void swap(T[] array, int i, int j)
    {
        T temp;
        temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    private static <T extends Comparable<T>> void selectionSort(T[] array, Order order)
    {
        int swapIndex;
        boolean check;
        for (int i = 0; i < array.length - 1; i++) {
            swapIndex = i;
            for (int j = i + 1; j < array.length; j++)
            {
                if (order == Order.ASCENDING)
                {
                    check = array[j].compareTo(array[swapIndex]) < 0;
                } else {
                    check = array[j].compareTo(array[swapIndex]) > 0;
                }
                if (check)
                {
                    swapIndex = j;
                }
            }
            if (i != swapIndex)
            {
                swap(array, swapIndex, i);
            }
        }
    }

    private static <T extends Comparable<T>> void insertion_sort(T[] array, Order order)
    {
        boolean check;
        int j;
        T temp;
        for (int i = 1; i < array.length; i++)
        {
            temp = array[i];
            j = i;
            do
            {
                if (order == Order.ASCENDING)
                {
                    check = temp.compareTo(array[j-1]) < 0;
                } else {
                    check = temp.compareTo(array[j-1]) > 0;
                }
                if (check)
                {
                    array[j] = array[j-1];
                    j--;
                }
            } while (j > 0 && check);
            array[j] = temp;
        }
    }

    private static <T extends Comparable<T>> void bubble_sort(T[] array, Order order)
    {
        boolean sorted, check;
        sorted = false;
        for (int i = array.length - 2; i >= 0 && !sorted; i--)
        {
            sorted = true;
            for (int j = 0; j <= i; j++)
            {
                if (order == Order.ASCENDING)
                {
                    check = array[j].compareTo(array[j+1]) > 0;
                } else {
                    check = array[j].compareTo(array[j+1]) < 0;
                }
                if (check)
                {
                    swap(array, j, j + 1);
                    sorted = false;
                }
            }
        }
    }

    private static <T extends Comparable<T>> void merge_sort(T[] array, Order order, int left, int right)
    {
        int size, mid;
        int i, iL, iR;
        boolean check;
        T[] leftArray, rightArray;
        if (left >= right)
        {
            return;
        }

        size = right - left + 1;
        mid = size / 2;
        leftArray = (T[]) java.lang.reflect.Array.newInstance(array.getClass().getComponentType(), mid);
        rightArray = (T[]) java.lang.reflect.Array.newInstance(array.getClass().getComponentType(), size - mid);
        System.arraycopy(array, left, leftArray, 0, mid);
        System.arraycopy(array, left + mid, rightArray, 0, size - mid);

        merge_sort(leftArray, order, 0, mid - 1);
        merge_sort(rightArray, order, 0, size - mid - 1);

        i = left;
        iL = iR = 0;
        while (iL < leftArray.length && iR < rightArray.length)
        {
            if (order == Order.ASCENDING)
            {
                check = leftArray[iL].compareTo(rightArray[iR]) < 0;
            } else {
                check = leftArray[iL].compareTo(rightArray[iR]) > 0;
            }
            if (check)
            {
                array[i++] = leftArray[iL++];
            } else {
                array[i++] = rightArray[iR++];
            }
        }
        if (iL < leftArray.length)
        {
            System.arraycopy(leftArray, iL, array, i, leftArray.length - iL);
            i += leftArray.length - iL;
        }
        if (iR < rightArray.length)
        {
            System.arraycopy(rightArray, iR, array, i, rightArray.length - iR);
        }
    }

    private static <T extends Comparable<T>> void quick_sort(T[] array, Order order, int left, int right)
    {
        int pivot;
        boolean check;
        if (left >= right)
        {
            return;
        }

        pivot = left;
        for (int j = left; j < right; j++)
        {
            if (order == Order.ASCENDING)
            {
                check = array[j].compareTo(array[right]) < 0;
            } else {
                check = array[j].compareTo(array[right]) > 0;
            }
            if (check)
            {
                swap(array, pivot, j);
                pivot++;
            }
        }
        swap(array, right, pivot);

        quick_sort(array, order, left, pivot - 1);
        quick_sort(array, order, pivot + 1, right);
    }

    private static <T extends Comparable<T>> int linear_search(T[] array, T item)
    {
        for (int i = 0; i < array.length; i++)
        {
            if (array[i].compareTo(item) == 0)
            {
                return i;
            }
        }
        return -1;
    }

    private static <T extends Comparable<T>> int binary_search(T[] array, T item, int left, int right, Order order)
    {
        int mid;
        if (left > right)
        {
            return -1;
        }

        mid = (right + left) / 2;
        if (array[mid].compareTo(item) == 0)
        {
            return mid;
        }
        if ((array[mid].compareTo(item) > 0 && order == Order.ASCENDING) ||
            (array[mid].compareTo(item) < 0 && order == Order.DESCENDING))
        {
            return binary_search(array, item, left, mid - 1, order);
        }
        return binary_search(array, item, mid + 1, right, order);
    }

    private static <T extends Comparable<T>> int binary_search(T[] array, T item, int left, int right)
    {
        Order order;

        if (array[left].compareTo(array[right]) < 0)
        {
            order = Order.ASCENDING;
        } else {
            order = Order.DESCENDING;
        }

        return binary_search(array, item, left, right, order);
    }

    /**
     * Return a clone of the given array
     * @param <T> The type of the elements of the array
     * @param array The array to clone
     * @return The reference to the new array
     * @throws NullPointerException In case of uninitialised array
     */
    public static <T> T[] clone(T[] array) throws NullPointerException
    {
        if (array == null)
        {
            throw new NullPointerException();
        }

        T[] clone = (T[]) java.lang.reflect.Array.newInstance(array.getClass().getComponentType(), array.length);
        System.arraycopy(array, 0, clone, 0, array.length);
        return clone;
    }

    /**
     * Sort an array in a given order with a given algorithm
     * @param <T> The type of the elements of the array
     * @param array The array to sort
     * @param algorithm The algorithm used in sorting
     * @param order The order the array will be
     * @throws NullPointerException In case of uninitialised array
     */
    public static <T extends Comparable<T>> void sort(T[] array, SortAlgorithm algorithm, Order order) throws NullPointerException
    {
        if (array == null)
        {
            throw new NullPointerException();
        }

        switch (algorithm) {
            case SELECTION_SORT:
                selectionSort(array, order);
                break;
            case INSERTION_SORT:
                insertion_sort(array, order);
                break;
            case BUBBLE_SORT:
                bubble_sort(array, order);
                break;
            case MERGE_SORT:
                merge_sort(array, order, 0, array.length -1);
                break;
            case QUICK_SORT:
                quick_sort(array, order, 0, array.length - 1);
                break;
        }
    }

    /**
     * Sort an array with a given algorithm
     * @param <T> The type of the elements of the array
     * @param array The array to sort
     * @param algorithm The algorithm used in sorting
     * @throws NullPointerException In case of uninitialised array
     */
    public static <T extends Comparable<T>> void sort(T[] array, SortAlgorithm algorithm) throws NullPointerException
    {
        sort(array, algorithm, Order.ASCENDING);
    }

    /**
     * Sort an array in a given order
     * @param <T> The type of the elements of the array
     * @param array The array to sort
     * @param order The order the array will be
     * @throws NullPointerException In case of uninitialised array
     */
    public static <T extends Comparable<T>> void sort(T[] array, Order order) throws NullPointerException
    {
        sort(array, SortAlgorithm.QUICK_SORT, order);
    }

    /**
     * Sort an array
     * @param <T> The type of the elements of the array
     * @param array The array to sort
     * @throws NullPointerException In case of uninitialised array
     */
    public static <T extends Comparable<T>> void sort(T[] array) throws NullPointerException
    {
        sort(array, SortAlgorithm.QUICK_SORT, Order.ASCENDING);
    }

    /**
     * Search an element 
     * @param <T> The type of the elements of the array
     * @param array The array to search into
     * @param item The item to find
     * @param algorithm The algorithm used to search
     * @return The index of the first occurance
     * @throws NullPointerException In case of uninitialised array or item
     */
    public static <T extends Comparable<T>> int search(T[] array, T item, SearchAlgorithm algorithm) throws NullPointerException
    {
        if (array == null || item ==  null)
        {
            throw new NullPointerException();
        }
        if (algorithm == SearchAlgorithm.LINEAR)
        {
            return linear_search(array, item);
        }
        return binary_search(array, item, 0, array.length - 1);
    }

    /**
     * Format the array into a printable version of the array
     * @param <T> The type of the elements of the array
     * @param array The array to rappresent
     * @param start The starting point of the array in the string rappresentation
     * @param length The length of the array to rappresent from the starting point
     * @return String rappresentation of the array
     * @throws NullPointerException In case of uninitialised array
     * @throws IndexOutOfBoundsException In case of unvalid indexes
     */
    public static <T> String printable(T[] array, int start, int length) throws NullPointerException, IndexOutOfBoundsException
    {
        if (array == null)
        {
            throw new NullPointerException();
        }
        if (start < 0 || length < 2 || start + length > array.length)
        {
            throw new IndexOutOfBoundsException();
        }

        StringBuilder sb = new StringBuilder();
        sb.append("[");
        for (int i = 0; i < length; i++) {
            sb.append(array[start + i]);
            if (i < length - 1) {
                sb.append(", ");
            }
        }
        sb.append("]");
        return sb.toString();
    }

    /**
     * Format the array into a printable version of the array
     * @param <T> The type of the elements of the array
     * @param array The array to rappresent
     * @return String rappresentation of the array
     * @throws NullPointerException In case of uninitialised array
     * @throws IndexOutOfBoundsException In case of unvalid indexes
     */
    public static <T> String printable(T[] array) throws NullPointerException, IndexOutOfBoundsException
    {
        return printable(array, 0, array.length);
    }
}
