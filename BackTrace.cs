
//全排列
public class BackTrace
{

	IList<IList<int>> res = new List<IList<int>>();
	IList<IList<int>> Permute(int[] nums)
	{
		IList<int> trace = new List<int>();
		BackTraceDemo(nums,trace);
		return res;
	}

	void BackTraceDemo(int[] nums,IList<int> traceList)
	{
		if(nums.Length == traceList.Count)
		{
			res.Add(new List<int>(traceList));
			return;
		}

		for(int i = 0;i<nums.Length;i++)
		{
			if(traceList.Contains(nums[i]))
				continue;
			traceList.Add(nums[i]);
			BackTraceDemo(nums,traceList);
			traceList.RemoveAt(traceList.Count - 1);
		}
	}
}