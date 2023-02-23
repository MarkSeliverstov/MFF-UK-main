using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Frightened_sate : Ghost_base
{
    // Stav útěku
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer frightened;

    private void OnEnable() {
        this.ghost.movement.speed_rate = 0.5f;
        this.body.enabled = false;
        this.eyes.enabled = false;
        this.frightened.enabled = true;
    }

    private void OnDisable() {
        this.ghost.movement.speed_rate = 1f;
        this.body.enabled = true;
        this.eyes.enabled = true;
        this.frightened.enabled = false;
    }
    
    
}
