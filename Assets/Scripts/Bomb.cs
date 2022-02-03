using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private LayerMask explosionMask;
    private int j;
    void Start()
    {
        Invoke("Explode", 3f);
        var _vector = new Vector2(1, 1);
    }
    
    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        var hit = Physics2D.OverlapCircleAll(transform.position, 1f,explosionMask);
        foreach (var collider in hit)
        {
            Destroy(collider.gameObject);
        }
        Destroy(gameObject);
    }
}
