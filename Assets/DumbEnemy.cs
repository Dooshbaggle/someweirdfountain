using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemy : MonoBehaviour
{

	 public void Die()
	 {
		 Destroy(gameObject, 2f);
	 }
}
