using UnityEngine;

// Základní chování duchů.
// Zapnutí a vypnutí stavů s dobou platnosti
public class Ghost_base : MonoBehaviour
{
    public Ghost ghost {get; private set;}
    public float period; // doba různých režimů

    private void Awake() {
        this.ghost = GetComponent<Ghost>();
    }


    public void Enable()
    {
        this.enabled = true;

        CancelInvoke();
        Invoke("Disable", this.period);
    }

    public void Disable()
    {
        this.enabled = false;
    }
}
