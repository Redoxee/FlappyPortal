using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public CharacterBehavior HeroReference;
    private bool HasHit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You Died");
        if (!HasHit) {
            HasHit = true;
            HeroReference.NotifyHit();
        }
    }
}
