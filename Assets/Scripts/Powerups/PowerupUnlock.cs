using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupUnlock : MonoBehaviour
{

    public bool doubleJump, wallJump, attack;

    public GameObject powerupFX;

    public void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Player") {
            PlayerAbilityControl player = other.GetComponent<PlayerAbilityControl>();

            if (doubleJump) {
                player.canDoubleJump = true;
            }
            if (wallJump) {
                player.canWallJump = true;
            }
            if (attack) {
                player.canAttack = true;
            }
        }
        Instantiate(powerupFX,transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
