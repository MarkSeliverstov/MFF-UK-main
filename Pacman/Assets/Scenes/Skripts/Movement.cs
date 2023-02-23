using UnityEngine;

public class Movement : MonoBehaviour // Jak se bude pohybovat.
{
    public new Rigidbody2D rigidbody {get; private set;}
    public float speed = 8.0f; // Normalni rychlost
    public float speed_rate = 1.0f; // Multiplikátor rychlosti
    public Vector2 inition_direction; // Počáteční směr
    public LayerMask BarrierLayer; // Steny

    public Vector2 direction {get; private set;}
    public Vector2 next_direction {get; private set;}
    public Vector3 start_pos;
        
    private void Awake() {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        this.start_pos = this.transform.position;
        ResetState();
    }
    
    public void ResetState()
    {
        // Obnovit nastavení.

        this.speed_rate = 1.0f;
        this.direction = this.inition_direction;
        this.next_direction = Vector2.zero;
        this.transform.position = this.start_pos;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    private void FixedUpdate() {
        // Přemístění
        // Fix aby malba byla nezávislá na počítači

        Vector2 pos = this.rigidbody.position;
        Vector2 transition = this.direction * this.speed * this.speed_rate * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(pos + transition);
    }

    void Update()
    {
        // Pokud zvolíte následující směr, přesměrováme.
        if (this.next_direction != Vector2.zero)
        {
            SetDirection(this.next_direction);
        }
    }

    public void SetDirection(Vector2 direct)
    {
        // Nastavení směru
            if ( !Occupied(direct) )
            {
                this.direction = direct;
                this.next_direction = Vector2.zero;
            }
            else
            {
                this.next_direction = direct;
            }
    }

    public bool Occupied(Vector2 direct)
    {
        // Kontroluje, zda je buňka obsazena v daném směru
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direct, 1.5f, this.BarrierLayer);
        return hit.collider != null;
    }
}
