using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - MOVE THE "PLAYER" AND THE "OBSTACLE" IN THE SCENE TO CHECK HOW THE VIEWING ANGLE BEHAVES ///
/// </summary>

public class Raycasting_FoV_Example_EnemyShooting : MonoBehaviour
{
    public Transform bulletPrefab;
    public Transform player;

    public float rateOfFire = 0.25f;
    private float cooldownTimer = 0;

    // our field of view
    private float fieldOfViewAngle = 20f;

    // Update is called once per frame
    void Update()
    {
        // every frame subtract the passed time to our cooldown
        cooldownTimer -= Time.deltaTime;

        // once the cooldown gets below 0
        if (cooldownTimer <= 0)
        {
            // we reset the cooldown with the established rate of fire
            cooldownTimer = rateOfFire;

            // now, this method will check if the enemy sees the player
            if (CheckVisionAngle())
            {
                Fire(); // if it does, fire bullets
            }
                
        }
    }

    private bool CheckVisionAngle()
    {
        bool canShoot = false;

        // this will get us a vector from the enemy towards the player
        Vector3 targetDir = player.position - transform.position;

        // we use "Vector3.Angle" to calculate angles between vectors, 
        //in this case we calculate the angle between the enemy "transform.up" (where he is facing) and the vector that faces the player
        // to check if the enemy is seeing the player
        float angle = Vector3.Angle(targetDir, transform.up);

        // if the angle between them is less than half the enemy field of view, then he can see the player
        if (angle < fieldOfViewAngle * 0.5f)
        {
            // a debug ray, so we can see the raycast
            Debug.DrawRay(transform.position, targetDir.normalized * Mathf.Infinity, Color.green);

            // we create a layer mask to ignore the enemy related elements - bullet and enemy itself - (our Bullet prefab must also be assigned to this layer)
            // here, our raycast will detect every layer, except the "Enemy" layer
            LayerMask mask = ~(1 << LayerMask.NameToLayer("Enemy"));

            // then we raycast... It has the purpose to check if there's no obstacles between him and the player
            // if there is any obstacle, that means the enemy can't shoot the player because he can't see him
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDir.normalized, Mathf.Infinity, mask);
            if (hit)
            {
                // if the object that is hit, is the player, that means the enemy is seeing him, so now he can shoot
                if (hit.collider.transform == player)
                {
                    canShoot = true;
                }     
            }
        }
        // this method "CheckVisionAngle()" returns a boolean with the value of our "canShoot" value
        // informing our Update() directly, if the enemy can fire or not
        return canShoot;
    }

    private void Fire()
    {
        // we instantiate the bullet (it has a script of its own to deal with the movement)
        Transform instance = Instantiate(bulletPrefab);

        // set the rotation and position to be the same as the enemy
        instance.rotation = transform.rotation;
        instance.position = transform.position;
    }
}
