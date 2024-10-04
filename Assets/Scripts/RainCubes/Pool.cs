using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    [SerializeField] private Transform _containerObjects;
    [SerializeField] private T _prefabObject;
    [SerializeField] private TextMeshProUGUI _text;

    private Queue<T> _objects = new();

    public virtual T GetObject(T prefab)
    {
        if (_objects.Count == 0)
        {
            var newObj = GameObject.Instantiate(_prefabObject);
            newObj.transform.parent = _containerObjects;
            newObj.gameObject.transform.position = prefab.transform.position;
            return newObj;
        }

        var obj = _objects.Dequeue();
        obj.transform.position = prefab.transform.position;
        return obj;
    }

    public virtual void PutObject(T prefab)
    {
        _objects.Enqueue(prefab);
        prefab.gameObject.SetActive(false);
    }
}