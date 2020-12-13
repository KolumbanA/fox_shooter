using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public float offset;
	
	public GameObject projectile;
	public Transform shotPoint;
	public float startTimeBtwShots;
	private float timeBtwShots;
	private SpriteRenderer mySpriteRenderer;


	private bool m_FacingRight = true; 


	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Only runs once, the moment the component loads
	private void Awake()
   {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
   }


    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		
		
		//getting the player_movement speed, and flipping the weapon accordingly
		/*
		float currentSpeed=0;
		if(Input.GetButtonDown("a"))
		{
			Flip();
		}
		if(currentSpeed > 0)
		{
			Flip();
		}
			*/
		//--
		
		
		
		//weapon rotation limitation and flipping
		Debug.Log(rotZ);
		
		if(rotZ > 90 || rotZ < -90)
		{
			//rotZ = 120;
			//transform.rotation = Quaternion.Euler(180f,0f,0f);
			mySpriteRenderer.flipY = true;
		}
		else
		{
			//rotZ = -120;
			mySpriteRenderer.flipY = false;
		}
		//----------------
		
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

		if (timeBtwShots <= 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Instantiate(projectile, shotPoint.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
		}
        else
        {
			timeBtwShots -= Time.deltaTime;
        }
		
    }
	
	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
