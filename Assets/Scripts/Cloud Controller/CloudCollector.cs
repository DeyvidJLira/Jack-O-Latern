using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.CompareTag ("Cloud")) {
			Destroy (target);
		}
	}

}
