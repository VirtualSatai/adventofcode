#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <openssl/md5.h>

int main(int argc, char const *argv[])
{
    if(argc != 2) {
        printf("fail\n");
        return -1;
    } 

    printf("%s\n", argv[1]);

    char input[16];
    sprintf(input, "%s", argv[1]);
    int input_len = strlen(input);    

    int count = 0;
    unsigned char res_buffer[64];

    int pt1 = 1;

    while(1) {
        sprintf(input + input_len, "%lu", count);
        MD5(input, strlen(input), res_buffer);
        
        if(!res_buffer[0] && !res_buffer[1] && res_buffer[2] < 0x10) {

            if(pt1) {
                pt1 = 0;
                printf("pt1: md5(%s)\n", input);
            }

            if(!res_buffer[2]) {
                printf("pt2: md5(%s)\n", input);
                break;
            }
        }

        if(count % 100000 == 0) {
            printf("c: %d\n", count);
        }

        count++;
    }

    return 0;
}
