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
    
    int position[2][2] = { 128, 128 }; // Should this work?!
    int robot = 1; // 0 is santa, 1 is robot

    ground[position[0][robot] * 256 + position[1][robot]]++;
    int count = 1;

    char temp;
    do
    {
        robot ^= 1;

        temp = fgetc(file);

        switch(temp) {
            case '^':
                position[1][robot]++;
                break;
            case '>':
                position[0][robot]++;
                break;
            case 'v':
                position[1][robot]--;
                break;
            case '<':
                position[0][robot]--;
                break;
            default:
                break;
        }

    if(ground[position[0][robot] * 256 + position[1][robot]] == 0)
        count++;

    printf("%c: (%5d,%5d) = %5d\n", robot ? 'R' : 'S', position[0][robot] - 128, position[1][robot] - 128, ground[position[0][robot] * 256 + position[1][robot]]);

    ground[position[0][robot] * 256 + position[1][robot]]++;

    } while(temp != EOF);

    printf("%d\n", count);

    fclose(file);
    return 0;
}
