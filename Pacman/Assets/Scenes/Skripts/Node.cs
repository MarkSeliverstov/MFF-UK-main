using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Vector2> availableDir {get; private set;}
    public LayerMask BarrierLayer;

    // Hledají se povolené směry na křižovatce
    void Start()
    {
        this.availableDir = new List<Vector2>();

        CheckIfAvailible(Vector2.up);
        CheckIfAvailible(Vector2.down);
        CheckIfAvailible(Vector2.right);
        CheckIfAvailible(Vector2.left);
    }

    private void CheckIfAvailible(Vector2 direct)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direct, 1.0f, this.BarrierLayer);
        if (hit.collider == null)
        {
            this.availableDir.Add(direct);
        }
    }
}
