using UnityEngine;

public class Chase_state : Ghost_base
{
    // Stav pronásledování
    private void OnDisable()
    {
        ghost.scatter.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            // Najde dostupný směr, který je nejblíže k pacmanu
            foreach (Vector2 available in node.availableDir)
            {
                // Pokud je Vzdálenost v tomto směru menší než aktuální, 
                // minimální vzdálenost, pak se tento směr stává novým nejbližším
                Vector3 newPos = this.transform.position + new Vector3(available.x, available.y, 0.0f);
                float distance = (this.ghost.target.position - newPos).magnitude; //vypočítá vzdálenost do pacmanu
                
                if (distance < minDistance)
                {
                    if (available != -this.ghost.movement.direction)
                    {
                        direction = available;
                        minDistance = distance;
                    }
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }
}
