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

void sortNetworkThree(int a[3])
{
    compareAndSwap(&a[0], &a[1]);
    compareAndSwap(&a[0], &a[2]);
    compareAndSwap(&a[1], &a[2]);
}

int main(int argc, char const *argv[])
{
    if(argc != 2) {
        printf("fail\n");
        return -1;
    }
    FILE * file = fopen(argv[1], "r");
    int args[3];
    int wrapping_paper_sum = 0;
    int ribbon_sum = 0;
    while(fscanf(file, "%dx%dx%d", &args[0], &args[1], &args[2]) != EOF)
    {
        int this_wp_sim = 0;
        this_wp_sim += (2 * args[0] * args[1]);
        this_wp_sim += (2 * args[0] * args[2]);
        this_wp_sim += (2 * args[1] * args[2]);
        
        int min = args[0] * args[1];
        if(min > (args[0] * args[2]))
            min = (args[0] * args[2]);
        if(min > (args[1] * args[2]))
            min = (args[1] * args[2]);

        this_wp_sim += min;
        wrapping_paper_sum += this_wp_sim;

        int this_ribbon_sum = 0;
        int sidesBySize[3] = { args[0], args[1], args[2] };

        sortNetworkThree(sidesBySize);

        this_ribbon_sum += (sidesBySize[0] + sidesBySize[1]) * 2;
        this_ribbon_sum += (args[0] * args[1] * args[2]);

        ribbon_sum += this_ribbon_sum;

        printf("%dx%dx%d => %d & %d\n", args[0], args[1], args[2], this_wp_sim, this_ribbon_sum);
    }

    printf("%d & %d\n", wrapping_paper_sum, ribbon_sum);

    fclose(file);
    return 0;
}