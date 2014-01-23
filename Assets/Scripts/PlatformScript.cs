using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public enum PlatformType {
		Rock,
		Grass,
		Water,
		Exit
	};

	public PlatformType platformType;

	public bool isWalkable = true;
	public int damage = 0;

}
