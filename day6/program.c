#include <stdio.h>
#include <stdlib.h>

void turn(size_t l[1000][1000], size_t x_0, size_t y_0, size_t x_1, size_t y_1, size_t OnOff) {
    size_t i, j;
    for(i = x_0; i < x_1; i++) {
        for(j = y_0; j < y_1; j++) {
            printf("%d, %d\n", i, j);
            l[i][j] = OnOff;
        }
    }
}

void toggle(size_t l[1000][1000], size_t x_0, size_t y_0, size_t x_1, size_t y_1) {
    size_t i, j;
    for(i = x_0; i < x_1; i++) {
        for(j = y_0; j < y_1; j++) {
            l[i][j] ^= 1;
        }
    }
}

int main(size_t argc, char const *argv[])
{
    printf("a\n");

    if(argc != 2) {
        printf("fail\n");
        return -1;
    }

    printf("a\n");
    FILE * file = fopen(argv[1], "r+");

     printf("a\n");

    //size_t leds[1000][1000];

    size_t ** leds = (size_t **) calloc(10000 * 10000, sizeof(int));

    char inBuffer[64];

    size_t x_0, y_0, x_1, y_1;

    printf("a\n");

     while(fgets(inBuffer, 64, file)) {


        printf("%s => %c\n", inBuffer, inBuffer[6]);

        if(inBuffer[6] == 'n') {
            /* Turn on */
            /* ex. turn on 957,736 through 977,890 */
            sscanf(inBuffer, "turn on %d,%d through %d,%d", &x_0, &y_0, &x_1, &y_1);
            turn(leds, x_0, y_0, x_1, y_1, 1);

        } else if(inBuffer[6] == 'f') { 
            /* Turn off */
            /* ex. turn off 957,736 through 977,890 */
            sscanf(inBuffer, "turn off %d,%d through %d,%d", &x_0, &y_0, &x_1, &y_1);
            printf("%d,%d %d,%d\n", x_0, y_0, x_1, y_1);
            turn(leds, x_0, y_0, x_1, y_1, 0);
        } else {
            /* Toggle */
            /* toggle 223,39 through 454,511 */
            sscanf(inBuffer, "toggle %d,%d through %d,%d", &x_0, &y_0, &x_1, &y_1);
            toggle(leds, x_0, y_0, x_1, y_1);
        }
    }

    size_t count = 0, i, j;

    for(i = 0; i < 1000; i++) {
        for(j = 0; j < 1000; j++) {
            count += leds[i][j];
        }
    }

    printf("%d\n", count);


    fclose(file);
    return 0;
}
