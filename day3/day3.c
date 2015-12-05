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

    int * ground = (int *) calloc(sizeof(int), 256 * 256);
    
    int center[2] = { 128, 128 };
    int position[2] = { 128, 128 };

    ground[position[0] * 256 + position[1]]++;
    int count = 1;

    char temp;
    do
    {
        temp = fgetc(file);

        switch(temp) {
            case '^':
                position[1]++;
                break;
            case '>':
                position[0]++;
                break;
            case 'v':
                position[1]--;
                break;
            case '<':
                position[0]--;
                break;
            default:
                break;
        }

    if(ground[position[0] * 256 + position[1]] == 0)
        count++;

    printf("(%5d,%5d) = %5d\n", position[0] - 128, position[1] - 128, ground[position[0] * 256 + position[1]]);

    ground[position[0] * 256 + position[1]]++;

    } while(temp != EOF);

    printf("%d\n", count);

    fclose(file);
    return 0;
}
