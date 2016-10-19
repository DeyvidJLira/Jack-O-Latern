using UnityEngine;
using System.Collections;

public class GroundCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Ground" || target.tag == "DarkCloud") {
            target.gameObject.SetActive(false);
		}
        if (target.tag == "Collectable") {
            target.gameObject.SetActive(false);
        }
	}

}
