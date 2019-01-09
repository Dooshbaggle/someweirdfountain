using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemy : MonoBehaviour
{

	 public void Die()
	 {
		 GetComponent<BoxCollider2D>().size = new Vector2(15.06425f, 0.06f);
		 GetComponent<BoxCollider2D>().offset = new Vector2(-1.972885f, -6.3f);
	 }
}
