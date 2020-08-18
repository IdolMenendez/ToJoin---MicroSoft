using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRU : MonoBehaviour {

	// Use this for initialization
//     ["LRUCache","put","get","put","get","get"]
//      [[1],[2,1],[2],[3,2],[2],[3]]
	void Start () {
		LRUCache cache = new LRUCache(2);
        cache.Put(2,1);
        cache.Put(2,2);
        print(cache.Get(2));
        cache.Put(1,1);
        cache.Put(4,1);
        print(cache.Get(2));
	}
	

}

public class LRUCache {
    int cap = 0;
    Dictionary<int,LinkedListNode<int>> keyToNode;
    Dictionary<LinkedListNode<int>,int> nodeToKey;
	LinkedList<int> cachedList;
    public LRUCache(int capacity) {
		cachedList = new LinkedList<int>();
        keyToNode = new Dictionary<int,LinkedListNode<int>>();
        nodeToKey = new Dictionary<LinkedListNode<int>, int>();
        cap = capacity;
    }
    
    public int Get(int key) {
        if(!keyToNode.ContainsKey(key)) return -1;
        LinkedListNode<int> cacheNode = keyToNode[key];
        MakeRecently(cacheNode);
        return cacheNode.Value;
    }
    
    public void Put(int key, int value) {
        if(cap == 0) return;
        if(keyToNode.ContainsKey(key))
        {
            LinkedListNode<int> cacheNode = keyToNode[key];
            keyToNode[key].Value = value;
            MakeRecently(cacheNode);
            return;
        }
		if(keyToNode.Count >= cap)
		{
			RemoveMinRecent();
		}
		LinkedListNode<int> newNode = new LinkedListNode<int>(value);
		cachedList.AddLast(newNode);
		keyToNode[key] = newNode;
        nodeToKey[newNode] = key;
    }

	public void RemoveMinRecent()
	{
		LinkedListNode<int> cacheNode = cachedList.First;
		cachedList.RemoveFirst();
		keyToNode.Remove(nodeToKey[cacheNode]);
        nodeToKey.Remove(cacheNode);
	}

    public void MakeRecently(LinkedListNode<int> node)
    {
        cachedList.Remove(node);
        cachedList.AddLast(node);
    }
}