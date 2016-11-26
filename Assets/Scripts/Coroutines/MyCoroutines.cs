using UnityEngine;
using System.Collections;

public static class MyCoroutines {
    
    public static IEnumerator WaitForRealSeconds(float time) {
        float timeStart = Time.realtimeSinceStartup;

        while(Time.realtimeSinceStartup < (timeStart + time)) {
            yield return null;
        }
    }
	
}
