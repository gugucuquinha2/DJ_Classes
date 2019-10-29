using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders_KickBallAdvanced_Example : MonoBehaviour
{
    public Transform prefab;

    private Transform curBall;
    private Rigidbody curRb;

    private bool canKickBall;
    private float kickPower;

    // Start is called before the first frame update
    void Start()
    {
        // we want to have a ball instantiated at the start, so we make sure there's a ball already on the ground to kick once we start the game
        // otherwise we'd only see a ball, after the first time we pressed the "Shoot" button
        SetFootball();
    }

    private void Update()
    {
        // while we keep pressing the "Space" key ("Shoot" button)
        if (Input.GetButton("Shoot"))
        {
            // we charge the power of our kick, by adding the time we're keeping the "Shoot" button pressed:
            // - Time.deltaTime gives us the duration of the last frame
            // - since we're adding the duration of every frame to our kickPower variable
            // - we're storing the time we spend pressing the "Shoot" button
            kickPower += Time.deltaTime;
        }
        // and once we release the button
        else if (Input.GetButtonUp("Shoot"))
        {
            // we check if we can kick the ball
            if (canKickBall)
            {
                // this is a different way of give movement to an instanced object
                // here, instead of giving the prefab a script allowing it to deal with the movement itself
                // we store each instance as a reference "curBall" so we can use it when needed (in this case to get the Rigidbody and apply a force)
                curRb = curBall.GetComponent<Rigidbody>();
                // when adding the force to kick, we multiply our default force value ("20" in this case) by our kickPower, so it works as a multiplier
                curRb.AddForce(curBall.forward * (20 * kickPower), ForceMode.Impulse);

                // as soon as we kick the ball, we're not allowed to kick anymore, because the ball is already kicked
                canKickBall = false;

                // "Invoke" allows to call methods after a certain amount of time
                // In this case, we wait for a second, until a new ball appears for us to kick
                Invoke("SetFootball", 1);
            }
            // if we can't, then we reset our kick power
            else kickPower = 0;
        }
    }

    private void SetFootball()
    {
        // we want our ball positon to be just above the ground (so it looks like it's lying on the ground)
        // so we set its position (center of the sphere) to be half its scale 
        // - since the scale of the ball is 1 and the ground position is 0 - a position of 0.5 (Y axis) means the center of the ball will be just above the ground
        Vector3 instancePos = new Vector3(0, 0.5f, 0);
        // our ball should be rotated slightly upwards, so it lifts once its kicked
        // since the X rotation is inverted in Unity (negative values represent upwards rotation and vice-versa) we set a negativee X rotation
        Quaternion instanceRot = Quaternion.Euler(-15, 0, 0);

        // instatiate a new ball and store it as a reference (so we can use later)
        curBall = Instantiate(prefab, instancePos, instanceRot);

        // once the new ball is set, we are allowed to kick
        canKickBall = true;

        // also reset the power of our kick, to make sure it starts at 0, when the new ball is ready to kick
        kickPower = 0;
    }
}
