import com.matteofuso.arrays.Arrays;
import com.matteofuso.adt.ArrayList;
import com.matteofuso.adt.LinkedList;

public class Main {
    public static void main(String[] args) {
        System.out.println("Array Sorting:");
        testSort();
        System.out.println();
        System.out.println("Array Sorting:");
        testSearch();
        System.out.println();
        System.out.println("ADT:");
        testADT();
    }

    public static void testSort()
    {
        Integer[] array = {5, 2, 9, 1, 5, 6};
        Integer[] selectionSort = Arrays.clone(array);
        Integer[] insertionSort = Arrays.clone(array);
        Integer[] bubbleSort = Arrays.clone(array);
        Integer[] mergeSort = Arrays.clone(array);
        Integer[] quickSort = Arrays.clone(array);
        Arrays.Order order = Arrays.Order.DESCENDING;

        Arrays.sort(selectionSort, Arrays.SortAlgorithm.SELECTION_SORT, order);
        Arrays.sort(insertionSort, Arrays.SortAlgorithm.INSERTION_SORT, order);
        Arrays.sort(bubbleSort, Arrays.SortAlgorithm.BUBBLE_SORT, order);
        Arrays.sort(mergeSort, Arrays.SortAlgorithm.MERGE_SORT, order);
        Arrays.sort(quickSort, order);
        
        System.out.print("Unsorted:  ");
        System.out.println(Arrays.printable(array));
        System.out.print("Selection: ");
        System.out.println(Arrays.printable(selectionSort));
        System.out.print("Insertion: ");
        System.out.println(Arrays.printable(insertionSort));
        System.out.print("Bubble:    ");
        System.out.println(Arrays.printable(bubbleSort));
        System.out.print("Merge:     ");
        System.out.println(Arrays.printable(mergeSort));
        System.out.print("Quick:     ");
        System.out.println(Arrays.printable(quickSort));
    }

    public static void testSearch()
    {
        int linear, binary, item;
        Integer[] unsorted = {5, 2, 9, 1, 5, 6};
        Integer[] sorted = Arrays.clone(unsorted);
        Arrays.sort(sorted, Arrays.Order.DESCENDING);
        
        item = 6;
        linear = Arrays.search(unsorted, item, Arrays.SearchAlgorithm.LINEAR);
        binary = Arrays.search(sorted, item, Arrays.SearchAlgorithm.BINARY);

        System.out.print("Unsorted: ");
        System.out.println(Arrays.printable(unsorted));
        System.out.print("Sorted:   ");
        System.out.println(Arrays.printable(sorted));
        System.out.println("Linar Search: " + linear);
        System.out.println("Binary Search: " + binary);
    }

    public static void testADT()
    {
        ArrayList<Number> arraylist = new ArrayList<>(new Number[] {1, 2.4, 3L});
        LinkedList<Integer> linkedList = new LinkedList<>(new Integer[] {1, 2, 3, 4, 5, 7, 8});

        arraylist.add(new Integer[] {1, 2, 3, 4, 5, 7, 8});
        linkedList.add(100, 3);

        System.out.println(arraylist);
        System.out.println(linkedList);
    }
}
