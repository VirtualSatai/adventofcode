#include <stdio.h>
#include <stdlib.h>

void compareAndSwap(int * a, int * b)
{
    if(*a > *b) 
    {
        int c = *b;
        *b = *a;
        *a = c;
    }
}

int main(int argc, char const *argv[])
{
    if(argc != 2) {
        printf("fail\n");
        return -1;
    }
    FILE * file = fopen(argv[1], "r");

    

    fclose(file);
    return 0;
}
