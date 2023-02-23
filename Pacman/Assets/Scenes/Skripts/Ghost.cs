using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Movement movement { get; private set; }
    public Home_state home { get; private set; }
    public Chase_state chase { get; private set; }
    public Scatter_state scatter {get; private set;}
    public Frightened_sate frightened {get; private set;}
    public Ghost_base initial;

    public Transform target;
    public int points = 200;

    //public bool frightened = false;
    public float FrightenedPeriod = 5f;

    private void Awake() 
    {
        this.GetComponent<Animator>();
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<Home_state>();
        this.chase = GetComponent<Chase_state>();
        this.scatter = GetComponent<Scatter_state>();
        this.frightened = GetComponent<Frightened_sate>();
    }

    public void ResetState()
    {
        // Nastavení stavů
        this.movement.ResetState();
        this.gameObject.SetActive(true);

        this.chase.Disable();
        this.scatter.Disable();
        this.frightened.Disable();

        if (this.home != this.initial) {
            this.home.Disable();}
        else{
            this.movement.enabled = false;
        }

        this.initial.Enable();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    // Pokud se setkal Pacman na cestě
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (frightened.enabled == true) {
                FindObjectOfType<GameManager>().GhostEaten(this);
            } 
            else {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }
}   

