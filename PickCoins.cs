using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickCoins : MonoBehaviour
{
    void Start()
    {
		ExchangeCoins coins = new ExchangeCoins();
		coins.CoinChange(new int[]{196,419,83,408},419);
    }
	// 假设 f(n) 代表要凑齐金额为 n 所要用的最少硬币数量，那么有：
	// f(n) = min(f(n - c1), f(n - c2), ... f(n - cn)) + 1
	// 其中 c1 ~ cn 为硬币的所有面额。
	// ----
	// 再具体解释一下这个公式吧，例如这个示例：
	// 输入: coins = [1, 2, 5], amount = 11
	// 输出: 3 
	// 解释: 11 = 5 + 5 + 1
    public class ExchangeCoins
    {
		public int CoinChange(int[] coins,int amount)
		{
			int[] dp = new int[amount + 1];
			for(int i = 0;i < dp.Length;i++)
			{
				dp[i] = amount + 1;
			}
			dp[0] = 0;
			for(int i = 0;i<dp.Length;i ++)
			{
				foreach(var coin in coins)
				{
					if (i >= coin)
					{
						dp[i] = Math.Min(dp[i],1 + dp[i - coin]);
					}
				}
			}
			return dp[amount] == amount + 1 ? -1:dp[amount];
		}
    }
}
