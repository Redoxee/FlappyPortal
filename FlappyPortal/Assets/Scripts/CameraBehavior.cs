using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    public MonoBehaviour target = null;

    public float offsetTargetX = 5.0f;

    public float dampVelocity = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.target) {
            var wantedX = target.transform.position.x + offsetTargetX;
            var posX = Mathf.SmoothDamp(transform.position.x,wantedX,ref dampVelocity,0.2f,15f, Time.deltaTime);
            var pos = transform.position;
            pos.x = posX;

            transform.position = pos;
        }
	}
}
