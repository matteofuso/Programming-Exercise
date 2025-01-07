#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 33

void print_array(int *array, int size)
{
    printf("[ ");
    for (int i = 0; i < size; i++)
    {
        printf("%d, ", array[i]);
    }
    printf("\b\b ]\n");
}

void fill_array(int *array, int size, int min, int max)
{
    for (int i = 0; i < size; i++)
    {
        array[i] = rand() % (max - min + 1) + min;
    }
}

void merge(int *array, int center, int len)
{
    int i = 0, j = center, k = 0;
    int *temp = malloc(len * sizeof(int));
    if (temp == NULL)
    {
        printf("Memory allocation failed\n");
        exit(1);
    }
    while (i < center && j < len)
    {
        if (array[i] <= array[j])
        {
            temp[k++] = array[i++];
        }
        else
        {
            temp[k++] = array[j++];
        }
    }
    while (i < center)
    {
        temp[k++] = array[i++];
    }
    while (j < len)
    {
        temp[k++] = array[j++];
    }
    for (i = 0; i < len; i++)
    {
        array[i] = temp[i];
    }
    free(temp);
}


void merge_sort(int *array, int len)
{
    if (len < 2)
    {
        return;
    }
    int center = len / 2;
    merge_sort(array, center);
    merge_sort(array + center, len - center);
    merge(array, center, len);
}

int main(int argc, char *argv[])
{
    int array[SIZE];
    srand(time(NULL));
    fill_array(array, SIZE, 0, 100);
    printf("Unsorted array: ");
    print_array(array, SIZE);
    merge_sort(array, SIZE);
    printf("Sorted array: ");
    print_array(array, SIZE);
    return 0;
}