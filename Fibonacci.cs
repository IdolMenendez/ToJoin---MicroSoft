public class Fibonacci
{
	public int Fib(int N) 
	{
        if(N < 1) return 0;
        if(N <= 2) return 1;
        int prev = 1;
        int cur = 1;
        int sum = 0;
        for(int i = 3;i<=N;i++)
        {
            sum = prev + cur;
            prev = cur;
            cur = sum;
        }
        return cur;
    }
}
