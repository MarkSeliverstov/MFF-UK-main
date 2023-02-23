using UnityEngine;

public class Pacman : MonoBehaviour
{
    public Movement movement {get; private set;}

    void Awake()
    {
        this.movement = GetComponent<Movement>();
    }

    // Ovládání Pakman pomocí klávesnice
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            this.movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            this.movement.SetDirection(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            this.movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            this.movement.SetDirection(Vector2.left);
        }

        // Určuje úhel v tangentu
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);

        // Změní úhel na vhodný (úhel se překládá z radiánů do stupňů "Mathf.Rad2Deg" 
        // a udává směr "forward")
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward); 
    }

    public void ResetState()
    {
        enabled = true;
        movement.ResetState();
        gameObject.SetActive(true);
    }

    public void ChangeDirect(int direct)
    {
        if (direct == 1){
            this.movement.SetDirection(Vector2.up);
        }
        else if (direct == 0){
            this.movement.SetDirection(Vector2.right);
        }
        else if (direct == -1){
            this.movement.SetDirection(Vector2.down);
        }
        else if (direct == 2){
            this.movement.SetDirection(Vector2.left);
        }
    }
}
