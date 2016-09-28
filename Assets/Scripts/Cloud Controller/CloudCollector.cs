using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Cloud" || target.tag == "DarkCloud") {
            target.gameObject.SetActive(false);
		}
        if (target.tag == "Collectable") {
            target.gameObject.SetActive(false);
        }
	}

}
