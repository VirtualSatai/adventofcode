#include <stdio.h>
#include <stdlib.h>

int subStringExists(char * buf, char * substring, int bufLen)
{
    int res = 0;
    int i, j;
    for (i = 0; i < bufLen - 1; ++i)
    {
        if(buf[i] == substring[0] && buf[i + 1] == substring[1])
            res = 1;
    }

    return res;
}

int main(int argc, char const *argv[])
{
    if(argc != 2) {
        printf("fail\n");
        return -1;
    }
    FILE * file = fopen(argv[1], "r");

    char buf[16];
    int res;
    int count = 0;

    do {
        res = fscanf(file, "%s ", buf);

        int vowelCount = 0, i, j;

        const char vowels[] = "aeiou";
        for (i = 0; i < 16; ++i)
        {
            for (j = 0; j < 5; ++j)
            {
                if(buf[i] == vowels[j]) {
                    vowelCount++;
                }

            }
        }

        if(vowelCount <3) {
            printf("Too few vowels %s\n", buf);
            continue;
        } 
          
        int good = 0;
        for (i = 0; i < 15; ++i)
        {
            if(buf[i + 1] == buf[i])
                good = 1;
        }

        if(!good) {
            printf("double %s\n", buf);
            continue;
        } 

        if(subStringExists(buf, "ab", 16)){
            printf("ab %s\n", buf);
            continue;
        } 

        if(subStringExists(buf, "cb", 16)){
            printf("cb %s\n", buf);
            continue;
        } 

        if(subStringExists(buf, "pq", 16)){
            printf("pq %s\n", buf);
            continue;
        } 

        if(subStringExists(buf, "xy", 16)){
            printf("xy %s\n", buf);
            continue;
        } 


        count++;
        printf("%s => %d\n", buf, vowelCount);
    } while(res != EOF);

    printf("%d\n", count);

    fclose(file);
    return 0;
}
