using UnityEngine;
using System.Collections;

public class BackgroundCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Background") {
            target.gameObject.SetActive(false);
        }
    }
}
