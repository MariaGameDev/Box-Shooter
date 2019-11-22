using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TargetBehavior : MonoBehaviour
{

    // target impact on game
    public int ballsAmount = 0;
    public float ballsSize = 0.0f;



    // explosion when hit?
    public GameObject explosionPrefab;

   

    // when collided with another gameObject
    void OnCollisionEnter(Collision newCollision)
    {
        // exit if there is a game manager and the game is over
        if (GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
                return;
        }

        // only do stuff if hit by a projectile
        if (newCollision.gameObject.tag == "Projectile")
        {
            if (explosionPrefab)
            {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            // if game manager exists, make adjustments based on target properties
            if (GameManager.gm)
            {
                
                GameManager.gm.targetHit( ballsAmount, ballsSize);
            }

            

            // destroy the projectile
            Destroy(newCollision.gameObject);

            // destroy self
            Destroy(gameObject);


            
        }

        
    }

    
}
