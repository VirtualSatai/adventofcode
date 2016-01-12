#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

int64_t cnt = 0;

void turn(size_t *l, size_t x_0, size_t y_0, size_t x_1, size_t y_1, size_t OnOff) {
    size_t i, j;
    for(i = x_0; i < x_1; i++) {
        for(j = y_0; j < y_1; j++) {
            int offset = i * 1000 + j;
            int * pos = l + offset;
            cnt += (OnOff != *pos) ? (OnOff == 1) ? 1 : -1 : 0;
            *pos = OnOff;
        }
    }
}

void toggle(size_t *l, size_t x_0, size_t y_0, size_t x_1, size_t y_1) {
    size_t i, j;
    for(i = x_0; i < x_1; i++) {
        for(j = y_0; j < y_1; j++) {
            int offset = i * 1000 + j;
            int * pos = l + offset;
            cnt += (*pos == 0) ? 1 : -1;
            *pos = (*pos == 0) ? 1 : 0;
        }
    }
}

int main(int argc, char const *argv[])
{
    if(argc != 2) {
        printf("fail\n");
        return -1;
    }

    FILE * file = fopen(argv[1], "r+");

    size_t * leds = (size_t *) calloc(1000 * 1000, sizeof(size_t));

    size_t count = 0, nount = 0, i, j;

    for(i = 0; i < 1000; i++) {
        for(j = 0; j < 1000; j++) {
            if(leds[i * 1000 + j] == 1) 
                count++;
            else 
                nount++;
        }
    }

    printf("%d %d %d\n", count, nount, cnt);

    char inBuffer[64];

    size_t x_0, y_0, x_1, y_1;

    while(fgets(inBuffer, 64, file)) {
        if(inBuffer[6] == 'n') {
            /* Turn on */
            /* ex. turn on 957,736 through 977,890 */
            sscanf(inBuffer, "%*s %*s %d,%d %*s %d,%d", &x_0, &y_0, &x_1, &y_1);
            turn(leds, x_0, y_0, x_1, y_1, 1);

        } else if(inBuffer[6] == 'f') { 
            /* Turn off */
            /* ex. turn off 957,736 through 977,890 */
            sscanf(inBuffer, "%*s %*s %d,%d %*s %d,%d", &x_0, &y_0, &x_1, &y_1);
            turn(leds, x_0, y_0, x_1, y_1, 0);
        } else {
            /* Toggle */
            /* toggle 223,39 through 454,511 */
            sscanf(inBuffer, "%*s %d,%d %*s %d,%d", &x_0, &y_0, &x_1, &y_1);
            toggle(leds, x_0, y_0, x_1, y_1);
        }

        if(cnt < 0) 
        {
            printf("%s\n", inBuffer);
        }
    }

    for(i = 0; i < 1000; i++) {
        for(j = 0; j < 1000; j++) {
            if(leds[i * 1000 + j] == 1) 
                count++;
            else 
                nount++;
        }
    }

    printf("%d %d %d\n", count, nount, cnt);

    fclose(file);
    return 0;
}