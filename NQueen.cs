    IList<IList<string>> res;
    public IList<IList<string>> SolveNQueens(int n) {
        res = new List<IList<string>>();
        char[][] ch = new char[n][];
        for(int i = 0;i<ch.Length;i++)
        {
            ch[i] = new char[n];
            for(int j = 0;j<n;j++)
            {
                ch[i][j]='.';
            }
        }
        BackTrack(ch,0);
        return res;
    }
    public void BackTrack(char[][] ch,int row)
    {
        if(ch.Length == row)
        {
            res.Add(Convert(ch));
            return;
        }
        for(int i = 0;i<ch.Length;i++)
        {
            if(!IsValid(ch,row,i)) continue;
            ch[row][i] = 'Q';
            BackTrack(ch,row + 1);
            ch[row][i] = '.';
        }
    }
    public bool IsValid(char[][] ch,int row,int col)
    {
        for(int i =0;i<ch.Length;i++)
        {
            if(ch[i][col] == 'Q') return false;
        }
        for(int i = row -1,j = col -1;i>=0&&j>=0;i--,j--)
        {
            if(ch[i][j] == 'Q') return false;
        }
        for(int i = row -1,j = col +1;i>=0&&j<ch.Length;i--,j++)
        {
            if(ch[i][j] == 'Q') return false;
        }
        return true;
    }
    public IList<string> Convert(char[][] ch)
    {
        IList<string> li = new List<string>();
        for(int i = 0;i< ch.Length ;i++)
        {
            li.Add(new string(ch[i]));
        }
        return li;
    }
}