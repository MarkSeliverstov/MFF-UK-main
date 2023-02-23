using UnityEngine;

public class Ball : MonoBehaviour
{
    // Skript pro malé koule
    public int points = 10;

    private void Eat()
    {
        FindObjectOfType<GameManager>().BallsEat(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")){
            Eat();
        }
    }
}
