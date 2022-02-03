using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private LayerMask explosionMask;
    void Start()
    {
        Invoke("Explode", 3f);
    }
    
    void Explode()
    {
        //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        var hit = Physics2D.OverlapCircleAll(transform.position, 1f,explosionMask);
        foreach (var collider in hit)
        {
            Destroy(collider.gameObject);
        }
        Destroy(gameObject);
    }
}
