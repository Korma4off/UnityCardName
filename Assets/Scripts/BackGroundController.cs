using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    void Start()
    {
        foreach(Transform child in transform)
        {
            Sprite sprite = _sprites[Random.Range(0, _sprites.Count)];
            _sprites.Remove(sprite);
            child.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

}
