using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public int CoinCount = 0;

    GUIStyle LabelStyle;
	// Use this for initialization
	void Start () {
        LabelStyle = new GUIStyle();
        LabelStyle.fontSize = 18;
        LabelStyle.fontStyle = FontStyle.Bold;
        LabelStyle.normal.textColor = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CollectCoin() {
        CoinCount += 1;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 20, 100, 20), CoinCount.ToString() + " Coins !", LabelStyle);
    }
}
