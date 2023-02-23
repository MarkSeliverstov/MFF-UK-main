using UnityEngine;

public class BigBall : MonoBehaviour
{
    // Skript pro velké koule
    public int points = 50; // Body při konzumaci ducha

    private void Eat()
    {
        FindObjectOfType<GameManager>().BigBallsEat(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")){
            Eat();
        }
    }
}
