﻿using UnityEngine;
using static UnityEngine.Mathf;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	[SerializeField]
	private int health = 100;

	private Animator animator;
	public GameObject cross;
	private Image HealthBar; 

	void Start() {
		animator = GetComponent<Animator>();
		HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();
	}

    public int getHealth()
    {
        return health;
    }
	public void SpawnCross() {
		Vector2 spawnPosition = new Vector2 {
			x = transform.position.x,
			y = -0.1f
		};
		Instantiate(cross, spawnPosition, Quaternion.identity);
	}

	public void Die() {
		Destroy(gameObject);
	}

	public void TakeDamage() {
		int damage = 10;
		health = Max(health - damage, 0);
		animator.SetInteger("Health", health);
		animator.SetTrigger("TookDamage");

		HealthBar.fillAmount -= (float)damage/(float)health;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.parent != transform
			&& collision.gameObject.CompareTag("Hitbox")) {

			TakeDamage();
		}
	}
}