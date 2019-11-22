using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour
{

	// Reference to projectile prefab to shoot
	[SerializeField]
	private GameObject projectile;
	public float power = 100.0f;

    private GameObject newProjectile;

    private float powerStep = 0.005f;

   
    // public Transform playerBall;

    // Reference to AudioClip to play
    [SerializeField]
	public AudioClip shootSFX;

    

    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("DOWN!!");
            if (newProjectile == null)
            {
                newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            
            Debug.Log("UP");
            // if the projectile does not have a rigidbody component, add one
            if (newProjectile!=null)
            {
                newProjectile.AddComponent<Rigidbody>();

                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { 
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else
                    {
                        
                        AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
                    }
                }
            }
            // Apply force to the newProjectile's Rigidbody component if it has one
            

            // play sound effect if set
            
        }

        


        if (Input.GetButton("Jump"))
        {
            // if projectile is specified
            if (projectile)
            {
                Debug.Log("Long press");
                Transform playerBallTransf = this.transform;
              

                float x = 1 - playerBallTransf.localScale.x;
                float y = 1 - playerBallTransf.localScale.y;
                float z = 1 - playerBallTransf.localScale.z;


                if (newProjectile!=null)
                {
                    newProjectile.transform.localScale = new Vector3(x, y, z);
                }
                

                float leftXscale = playerBallTransf.localScale.x - powerStep;
                float leftYscale = playerBallTransf.localScale.y - powerStep;
                float leftZscale = playerBallTransf.localScale.z - powerStep;


                if (leftXscale < 0)
                {
                    leftXscale = 0.1f;
                    leftYscale = 0.1f;
                    leftZscale = 0.1f;

                }

                playerBallTransf.transform.localScale = new Vector3(leftXscale, leftYscale, leftZscale);

                
            }
        }
        // Detect if fire button is pressed
        /*if ( Input.GetButtonDown("Jump"))
		{	
			// if projectile is specified
			if (projectile)
			{
                
                Transform playerBallTransf = this.transform;
                //playerBall.transform.lossyScale
               // projectileTransform.localScale = new Vector3();
                
				// Instantiante projectile at the camera + 1 meter forward with camera rotation
				GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;


                float x = 1 - playerBallTransf.localScale.x;
                float y = 1 - playerBallTransf.localScale.y;
                float z = 1 - playerBallTransf.localScale.z;

                newProjectile.transform.localScale = new Vector3(x,y,z);

                float leftXscale = playerBallTransf.localScale.x - x;
                float leftYscale = playerBallTransf.localScale.y - y;
                float leftZscale = playerBallTransf.localScale.z - z;


                if (leftXscale<0)
                {
                    leftXscale = 0.1f;
                    leftYscale = 0.1f;
                    leftZscale = 0.1f;

                }
                playerBallTransf.transform.localScale = new Vector3(leftXscale, leftYscale, leftZscale);
                
				// if the projectile does not have a rigidbody component, add one
				if (!newProjectile.GetComponent<Rigidbody>()) 
				{
					newProjectile.AddComponent<Rigidbody>();
				}
				// Apply force to the newProjectile's Rigidbody component if it has one
				newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
				
				// play sound effect if set
				if (shootSFX)
				{
					if (newProjectile.GetComponent<AudioSource> ()) { // the projectile has an AudioSource component
						// play the sound clip through the AudioSource component on the gameobject.
						// note: The audio will travel with the gameobject.
						newProjectile.GetComponent<AudioSource> ().PlayOneShot (shootSFX);
					} else {
						// dynamically create a new gameObject with an AudioSource
						// this automatically destroys itself once the audio is done
						AudioSource.PlayClipAtPoint (shootSFX, newProjectile.transform.position);
					}
				}
			}
		}*/
    }


	


}
