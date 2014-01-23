using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PlatformTile : MonoBehaviour {

	public enum PlatformTileType {
		Grass,
		Rock,
		Water,
		Fire,
		Cloud,
		Exit
	}
	
	public PlatformTileType platformTileType;

	public int damage = 0;
	public float damageRate = 0.25f;
	public bool isWalkable = true;
	public PhysicsMaterial2D material;
	public float friction = 0;
	public float bounciness = 0;

	private float damageCooldown;

	void Start() {

		damageCooldown = damageRate;

		if (material != null) {

			material.bounciness = bounciness;
			material.friction = friction;
			transform.collider2D.sharedMaterial = material;

		}

	}

	void Update() {
		if (damageCooldown > 0)
			damageCooldown -= Time.deltaTime;
	}

	public bool CanDamage {
		get {
			return damageCooldown <= 0f;
		}
	}

	public void ResetDamage() {
			damageCooldown = damageRate;
	}

}
