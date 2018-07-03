using System.Collections;
using UnityEngine;

public class BeginAnimation : MonoBehaviour {

	void Start () {
        StartCoroutine(chageScale());
    }
	
    private IEnumerator chageScale()
    {
        float scale = transform.localScale.x;
        for (; scale < 1; scale += 0.02f) 
        {  
            transform.localScale = new Vector3(scale, scale, 1);
            yield return new WaitForFixedUpdate();
        }
    }
}
