using UnityEngine;

public class Scatter_state : Ghost_base
{
    private void OnDisable() {
        ghost.chase.Enable();
    }

    // Randomní pohyb duchů
    private void OnTriggerEnter2D(Collider2D other)
    {
       Node node = other.GetComponent<Node>();

        if (node != null && enabled)
        {
            // Vybere náhodný dostupný směr
            int ind = Random.Range(0, node.availableDir.Count);

            // Aby ghost neměnil směr naopak. Pokud je opak, zvolí se jiný směr
            if (node.availableDir[ind] == -ghost.movement.direction && node.availableDir.Count > 1 )
            {
                ind++;
                if (ind >= node.availableDir.Count){
                    ind = 0;
                }
            }

            ghost.movement.SetDirection(node.availableDir[ind]);
        }

    }
}
