using UnityEngine;
using System.Collections;

public class CharacterBehavior : MonoBehaviour {

    public Vector3 Speed = new Vector3(1,0,0);
    
    public int HitPoint = 6;
    public float ShrinkFactor = 0.85f;
	
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += this.Speed * Time.deltaTime;
	}


    public void NotifyHit() {
        Debug.Log("HIT");
        HitPoint--;
        if (HitPoint >= 0) {
            transform.localScale *= ShrinkFactor;
        } else {
            Application.LoadLevel("TitleScene");
        }
    }
}
