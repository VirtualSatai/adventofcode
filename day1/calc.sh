expr $(sed "s/)//g" input | wc -c) - $(sed "s/(//g" input | wc -c)
