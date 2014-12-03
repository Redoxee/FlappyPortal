using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    public MonoBehaviour Target = null;

    public float OffsetTargetX = 5.0f;

    public float DampVelocity = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Target) {
            var wantedX = Target.transform.position.x + OffsetTargetX;
            var posX = Mathf.SmoothDamp(transform.position.x,wantedX,ref DampVelocity,0.2f,15f, Time.deltaTime);
            var pos = transform.position;
            pos.x = posX;

            transform.position = pos;
        }
	}
}
