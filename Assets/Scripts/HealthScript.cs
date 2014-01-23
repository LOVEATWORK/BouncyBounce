using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int HP = 0;
	public bool isEnemy = false;
	PlatformTile platformTile = null;

	void OnCollisionStay2D(Collision2D coll) {

		platformTile = coll.gameObject.transform.GetComponent<PlatformTile> ();
		// Debug.Log (platformTile.platformTileType);

		if (platformTile.damage > 0 && platformTile.CanDamage == true) {
			platformTile.ResetDamage();
			HP -= platformTile.damage;
		}


		if (HP <= 0)
			Destroy (gameObject);

	}
}
