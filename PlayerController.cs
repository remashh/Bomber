using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask raycastMask;

    private bool isMovement;

    private void Update()
    {
        if (isMovement)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayerTo(Vector2.left);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayerTo(Vector2.right);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayerTo(Vector2.up);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayerTo(Vector2.down);
        }
        
    }

    private void MovePlayerTo(Vector2 dir)
    {
        if (Raycast(dir))
        {
            return;
        }

        isMovement = true;

        var pos = (Vector2)transform.position + dir;
        transform.DOMove(pos, 0.5f).OnComplete(() =>
        {
            isMovement = false;
        });
    }

    private bool Raycast(Vector2 dir)
    {
        Debug.Log("text");
        var hit = Physics2D.Raycast(transform.position, dir, 1f, raycastMask);
        return hit.collider != null;
    }
    
}
