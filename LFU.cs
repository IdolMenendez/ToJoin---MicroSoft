public class LFUCache 
{
    public Dictionary<int,int> keyToVal;
    public Dictionary<int,int> keyToFreq;
    public Dictionary<int,LinkedListNode<int>> keyToNode;
    public Dictionary<int,LinkedList<int>> freqToKeys;
    public int cap;
    public int minFreq;

    public LFUCache(int capacity) 
	{
        keyToVal = new Dictionary<int,int>();
        keyToFreq = new Dictionary<int,int>();
        keyToNode = new Dictionary<int,LinkedListNode<int>>();
        freqToKeys = new Dictionary<int,LinkedList<int>>();
        cap = capacity;
        minFreq = 0;
    }
    
    public int Get(int key) 
	{
        if(!keyToVal.ContainsKey(key)) return -1;
        IncreaseFreq(key);
        return keyToVal[key];
    }
    
    public void Put(int key, int value) 
	{
        if(cap == 0) return;
        if(keyToVal.ContainsKey(key))
        {
            keyToVal[key] = value;
            IncreaseFreq(key);
            return;
        }
        if(cap <= keyToVal.Count)
        {
            RemoveMinFreqKey();
        }
        keyToVal.Add(key,value);
        keyToFreq.Add(key,1);
        if(!freqToKeys.ContainsKey(1))
        {
            freqToKeys.Add(1,new LinkedList<int>());
        }
        minFreq = 1;
        LinkedListNode<int> addNode = freqToKeys[1].AddLast(key);
        keyToNode[key] = addNode;
    }

    public void IncreaseFreq(int key)
    {
        int freq = keyToFreq[key];
        keyToFreq[key] = freq + 1;
        LinkedListNode<int> deleteNode = keyToNode[key];
        freqToKeys[freq].Remove(deleteNode);
        if(!freqToKeys.ContainsKey(freq + 1))
        {
            freqToKeys.Add(freq + 1,new LinkedList<int>());
        }
        LinkedListNode<int> addNode = freqToKeys[freq + 1].AddLast(key);
        keyToNode[key] = addNode;
        if(freqToKeys[freq].Count == 0)
        {
            freqToKeys.Remove(freq);
            if(minFreq == freq)
            {
                minFreq = freq + 1;
            }
        }
    }

    public void RemoveMinFreqKey()
    {
        LinkedList<int> keyList = freqToKeys[minFreq];
        int deleteKey = keyList.First.Value;
        freqToKeys[minFreq].RemoveFirst();
        if(freqToKeys[minFreq].Count == 0)
        {
            freqToKeys.Remove(minFreq);
        }
        keyToNode.Remove(deleteKey);
        keyToVal.Remove(deleteKey);
        keyToFreq.Remove(deleteKey);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

