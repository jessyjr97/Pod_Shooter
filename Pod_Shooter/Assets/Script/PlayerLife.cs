using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerLife : NetworkBehaviour {
    public RectTransform healthBar;
    public const int maxLife = 100;
    private NetworkStartPosition[] spawnPoints;

    [SyncVar]
    int currentLife = maxLife;
    
	void Start () {
		if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
	}

    public void TakeDamage(int damage)
    {
        if (isServer)
        {
            currentLife -= damage;
            if (currentLife <= 0)
            {
                currentLife = 0;
                Die();
            }
        }
    }

    private void Die()
    {
        RpcReSpawn();
    }

    private void UpdateLife(int NewLife)
    {
        healthBar.sizeDelta = new Vector2(NewLife, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    private void RpcReSpawn()
    {
        if (isLocalPlayer)
        {
            currentLife = maxLife;
            Vector3 spawnPoint = Vector3.zero;
            if (spawnPoints != null && spawnPoints.Length > 0){
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
