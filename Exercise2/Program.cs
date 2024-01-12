int total = 0;
int a = 1;
int b = 2;

while (b < 4000000)
{
    if (b % 2 == 0)
    {
        total += b;
    }

    int next = a + b;
    a = b;
    b = next;
}

Console.WriteLine(total);
