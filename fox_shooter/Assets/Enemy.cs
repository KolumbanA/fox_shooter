using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	public int startingHeath;
	private int health;
	public GameObject deathEffect;
	public GameObject spawnPoint;
	public AudioSource hitEffect;
	public AudioSource deathSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void Awake()
	{
		health = startingHeath;
	}

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
		{
			deathSoundEffect.Play();
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			//Destroy(gameObject);
			transform.position = spawnPoint.transform.position;
			health = startingHeath;
		}
    }
	
	
	public void TakeDamage(int damage)
	{
		hitEffect.Play();
		health -= damage;
	}
	
	private void OnTriggerEnter2D(Collider2D collison)
    {
        if ( collison.gameObject.tag == "Player")
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }
}
