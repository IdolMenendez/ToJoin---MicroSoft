    //https://github.com/labuladong/fucking-algorithm/blob/master/%E7%AE%97%E6%B3%95%E6%80%9D%E7%BB%B4%E7%B3%BB%E5%88%97/%E6%BB%91%E5%8A%A8%E7%AA%97%E5%8F%A3%E6%8A%80%E5%B7%A7.md
    //最小覆盖子串
    public Dictionary<char,int> needs = new Dictionary<char,int>();
    public Dictionary<char,int> window = new Dictionary<char,int>();
    public string MinWindow(string s, string t) {
        int left  = 0;
        int right = 0;
        int start = 0;
        int minLen = int.MaxValue;
        int match = 0;
        string res = s;
        foreach(var ch in t)
        {
            if(needs.ContainsKey(ch))
                needs[ch]++;
            else
                needs[ch] = 1;
        }
        while(right < s.Length)
        {
            char c1 = s[right];
            if(needs.ContainsKey(c1))
            {
                if(window.ContainsKey(c1))
                {
                    window[c1]++;
                }
                else
                {
                    window[c1] = 1;
                }
                if(window[c1] == needs[c1])
                    match++;
            }
            right++;

            while(needs.Count == match)
            {
                if(right - left < minLen)
                {
                    minLen = right-left;
                    start = left;
                }
                char c2 = s[left];
                if(needs.ContainsKey(c2))
                {
                    if(needs[c2] == window[c2])
                    {
                        match --;
                    }
                    window[c2]--;
                }
                left ++;
            }
        }
        return minLen == int.MaxValue ? "" : s.Substring(start,minLen);
    }
    //二、找到字符串中所有字母异位词
    public Dictionary<char ,int> needs = new Dictionary<char,int>();
    public Dictionary<char ,int> window = new Dictionary<char,int>();
    public IList<int> li = new List<int>();
    public IList<int> FindAnagrams(string s, string p) 
    {
        int left =0;
        int right = 0;
        int match = 0;
        foreach(var ch in p){
            if(needs.ContainsKey (ch))
                needs[ch]++;
            else
                needs[ch] = 1;
        }
        while(right < s.Length)
        {
            char c1 = s[right];
            if(needs.ContainsKey(c1))
            {
                if(window.ContainsKey(c1))
                    window[c1]++;
                else
                    window[c1] = 1;
                if(window[c1]== needs[c1])
                    match ++;
            }
            right ++;
            while(match == needs.Count)
            {
                if(right - left == p.Length)
                {
                    li.Add(left);
                }
                char c2 = s[left];
                if(needs.ContainsKey(c2))
                {
                    if(needs[c2] == window[c2])
                        match--;
                    window[c2]--;
                }
                left ++;
            }
        }
        return li;
    }
    //三、无重复字符的最长子串
        public Dictionary<char,int> window = new Dictionary<char,int>();
    public int LengthOfLongestSubstring(string s) 
    {
        int left = 0;
        int right = 0;
        int maxLen = 0;
        while(right < s.Length)
        {
            char c1 = s[right];
            if(window.ContainsKey(c1))
            {
                window[c1]++;
            }
            else
            {
                window[c1] = 1;
            }
            right ++;
            while(window[c1] > 1)
            {
                char c2 = s[left];
                if(window.ContainsKey(c2))
                {
                    window[c2] --;
                }
                left ++;
            }
            maxLen = Math.Max(maxLen ,right - left);
        }
        return maxLen;
    }
    

