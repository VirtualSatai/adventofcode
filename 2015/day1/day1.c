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

    char temp;
    int flr = 0;
    int count = 0;
    int firsttime = 1;

    do
    {
        temp = fgetc(file);

        count++;

        if(temp == '(') {
            flr += 1;
        } else {
            flr -= 1;
        }

        if(flr == -1 && firsttime) {
            firsttime = 0;
            printf("Part 2: %d\t%d\n", count, flr);
        }
    } while(temp != EOF);

    printf("Part 1: %d\t%d\n", count, flr);

    fclose(file);
    return 0;
}
