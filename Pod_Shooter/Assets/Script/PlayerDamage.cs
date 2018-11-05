using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {
    PlayerLife playerLife;

    public void DealDamage(int damage) {
        playerLife.TakeDamage(damage);
    }

	void Start () {
        playerLife = GetComponent<PlayerLife>();
	}
}
