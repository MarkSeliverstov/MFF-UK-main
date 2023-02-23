using UnityEngine;

public class GhostEyes : MonoBehaviour
{
    // Ovládá pohled duchů
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;
    
    public Movement movement {get; private set;}
    public SpriteRenderer SpriteRenderer {get; private set;}

    private void Awake() {
        this.movement = GetComponentInParent<Movement>(); //odebírá "movement" od rodiče
        this.SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (this.movement.direction == Vector2.up){
            this.SpriteRenderer.sprite = this.up;
        }
        if (this.movement.direction == Vector2.down){
            this.SpriteRenderer.sprite = this.down;
        }
        if (this.movement.direction == Vector2.left){
            this.SpriteRenderer.sprite = this.left;
        }
        if (this.movement.direction == Vector2.right){
            this.SpriteRenderer.sprite = this.right;
        }
    }
}

