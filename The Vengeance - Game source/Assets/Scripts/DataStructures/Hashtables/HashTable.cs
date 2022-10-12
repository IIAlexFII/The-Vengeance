using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashTableNode
{
    public string Key
    {
        set;
        get;
    }
    public object Value
    {
        set;
        get;
    }
    public HashTableNode Next
    {
        set;
        get;
    }

    public HashTableNode(string key, object value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

public class HashTable
{
    private HashTableNode[] buckets;
    private int tableSize;

    public HashTable(int size)
    {
        buckets = new HashTableNode[size];
        tableSize = size;
    }
    private int HashFunction(string key)
    {
        long index = 7;
        int asciiCode = 0;
        for (int i = 0; i < key.Length; i++)
        {
            asciiCode = (int)key[i] * i;
            index = index * 31 + asciiCode;
        }
        return (int)(index % tableSize);
    }

    public void Insert(string key, object value) //insert values
    {
        int hashIndex = HashFunction(key);
        HashTableNode node = buckets[hashIndex];
        if (node == null)
        {
            buckets[hashIndex] = new HashTableNode(key, value);
        }
        else
        {
            if (node.Key == key)
            {
                node.Value = value;
            }
            else
            {
                while (node.Next != null)
                {
                    node = node.Next;
                    if (node.Key == key)
                    {
                        node.Value = value;
                        return;
                    }
                }
                HashTableNode newNode = new HashTableNode(key, value);
                node.Next = newNode;
            }
        }
    }

    public object GetValue(string key) //get values by giving the key
    {
        int hashIndex = HashFunction(key);
        HashTableNode node = buckets[hashIndex];
        while (node != null)
        {
            if (node.Key == key)
            {
                return node.Value;
            }
            node = node.Next;
        }
        return null;
    }

    public bool Remove(string key) //remove values by giving the key
    {
        int hashIndex = HashFunction(key);
        HashTableNode node = buckets[hashIndex];
        if (node == null)
        {
            return false;
        }
        if (node.Key == key)
        {
            buckets[hashIndex] = node.Next;
            return true;
        }
        HashTableNode previous = node;
        while (node != null)
        {
            if (node.Key == key)
            {
                previous.Next = node.Next;
                return true;
            }
            previous = node;
            node = node.Next;
        }
        return false;
    }

    public bool ContainsKey(string key) //see if a certain key is in the hashtable
    {
        int hashIndex = HashFunction(key);
        HashTableNode node = buckets[hashIndex];
        if (node == null)
        {
            return false;
        }
        else
        {
            if (node.Key == key)
            {
                return true;
            }
            else
            {
                while (node.Next != null)
                {
                    node = node.Next;
                    if (node.Key == key)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }

    public bool ContainsValue(object value) //see if a certain value is in the hashtable
    {
        for (int i = 0; i < tableSize; i++)
        {
            HashTableNode node = buckets[i];
            if (node != null)
            {
                if (node.Value == value)
                {
                    return true;
                }
                while (node.Next != null)
                {
                    node = node.Next;
                    if (node.Value == value)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public int Count()
    {
        int count = 0;
        for (int i = 0; i < tableSize; i++)
        {
            HashTableNode node = buckets[i];
            if (node != null)
            {
                count++;
                while (node.Next != null)
                {
                    node = node.Next;
                    count++;
                }
            }
        }
        return count;
    }
}

