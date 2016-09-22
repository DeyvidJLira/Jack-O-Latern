using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider target) {
		if (target.gameObject.CompareTag ("Cloud")) {
			Destroy (target);
		}
	}

}
