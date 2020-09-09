//https://github.com/labuladong/fucking-algorithm/blob/master/%E7%AE%97%E6%B3%95%E6%80%9D%E7%BB%B4%E7%B3%BB%E5%88%97/%E4%BA%8C%E5%88%86%E6%9F%A5%E6%89%BE%E8%AF%A6%E8%A7%A3.md
public class Solution {
    //寻找一个数
	public int BinarySearch(int[] nums,int result)
	{
		int left = 0;
		int right = nums.Length - 1;
		while(left <= right)
		{
			int mid = left + (right - left)/2;
			if(nums[mid] == result)
			{
				return mid;
			}
			else if(nums[mid] < result)
			{
				left = mid + 1;
			}
			else if(nums[mid] > result)
			{
				right = mid - 1;
			}
		}
		return -1;
	}
    //寻找左侧边界
	public int BinarySearch_LeftBorder(int[] nums,int result)
	{
		int left = 0;
		int right = nums.Length;
		while(left < right)
		{
			int mid = left + (right - left)/2;
			if(nums[mid] == result)
			{
				right = mid;
			}
			else if(nums[mid] < result)
			{
				left = mid + 1;
			}
			else if(nums[mid] > result)
			{
				right = mid;
			}
		}
		if(left == nums.Length) return -1;
		return left;
	}
    //寻找右侧边界
	public int BinarySearch_RightBorder(int[] nums,int result)
	{
		int left = 0;
		int right = nums.Length;
		while(left < right)
		{
			int mid = left + (right - left)/2;
			if(nums[mid] == result)
			{
				left = mid + 1;
			}
			else if(nums[mid] < result)
			{
				left = mid + 1;
			}
			else if(nums[mid] > result)
			{
				right = mid;
			}
		}
		if (left == 0) return -1;
		return nums[left -1] == result ?nums[left -1]:-1;
	}
}