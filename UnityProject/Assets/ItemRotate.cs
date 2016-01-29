using UnityEngine;
using System.Collections;

public class ItemRotate : MonoBehaviour {

    public float RotationSpeed = 1;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(RotationSpeed * Time.deltaTime, 0, 0);
	}
}
