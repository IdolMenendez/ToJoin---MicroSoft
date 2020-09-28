	//寻找一个数组中的重复数字
    int FindRepeatNumber(int[] nums)
    {
		int temp = 0;
        for (int i = 0; i < nums.Length; i++)
        {
			while(nums[i] != i)
			{
				if(nums[i] == nums[nums[i]])
				{
					return nums[i];
				}
				temp = nums[i];
				nums[i] = nums[temp];
				nums[temp] = temp;
			}
        }
		return 0;
    }
	//判断二维数组中是否包含某个数
	bool GetMatrixNumber(int[][] matrix,int target)
	{
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) 
        {
            return false;
        }
        int rows = matrix.Length, columns = matrix[0].Length;
        int row = 0, column = columns - 1;
        while (row < rows && column >= 0) 
        {
            int num = matrix[row][column];
            if (num == target) {
                return true;
            } else if (num > target) {
                column--;
            } else {
                row++;
            }
        }
        return false;
	}
	//替换空格
	public string ReplaceSpace(string s) 
	{
        int len = s.Length;
		char[] puzzle = new char[len * 3];
		int size = 0;
		for(int i = 0;i < len;i++)
		{
			if(s[i]==' ')
			{
				puzzle[size++]='%';
				puzzle[size++]='2';
				puzzle[size++]='0';
			}
			else
			{
				puzzle[size++] = s[i];
			}
		}
		string str = new string(puzzle,0,size);
		return str;
    }
 	public class ListNode {
 	    public int val;
 	    public ListNode next;
 	    public ListNode(int x) { val = x; }
 	}
	//从尾部到头打印链表
	public int[] ReversePrint(ListNode head) {
        ListNode node = head;
		int count = 0;
		while(node != null)
		{
			node = node.next;
			count ++;
		}

		int[] arr = new int[count];
		node = head;
		for(int i = count - 1;i>=0;i--)
		{
			arr[i] = node.val;
			node = node.next;
		}
		return arr;
    }	