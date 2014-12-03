using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

    public float RotationSpeed = 45.0f;

    public CoinManager CoinManagerReference;
    public WorldManager WorldManagerReference;
	
    private bool HasCollided = false;
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var angle = Quaternion.AngleAxis(RotationSpeed * Time.deltaTime, new Vector3(1,0,1));
        transform.rotation = transform.rotation * angle;
	}

    void OnTriggerEnter(Collider other)
    {
        if (!HasCollided)
        { 
            HasCollided = true; 
            CoinManagerReference.CollectCoin();
            WorldManagerReference.DestroySpawnnedObject(this.gameObject);
        }
    }
}
