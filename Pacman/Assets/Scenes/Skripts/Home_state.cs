using UnityEngine;

public class Home_state : Ghost_base
{
    public Transform outOfHome;

    private void OnDisable() { 
        // Útěk duchů z domova
        if (outOfHome != null){
            ghost.SetPosition(outOfHome.transform.position);
        }
        this.ghost.movement.enabled = true;
        this.ghost.movement.SetDirection(Vector2.right);
        ghost.scatter.Enable();
    }
}