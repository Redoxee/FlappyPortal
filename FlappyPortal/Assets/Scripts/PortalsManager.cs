using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PortalsManager : MonoBehaviour {

    public float MinDistancePortals = 1.0f;

    public List<GameObject> PortalsList;

    public float PortalDesactivationDuration = 1.0f;
    private float PortalHitTimeStamp = 0;

    private int PortalCursor = 0;
    private GameObject LastPortal;
    

	// Use this for initialization
	void Start () {
        LastPortal = PortalsList[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            var v3 = Input.mousePosition;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = 0;
            float distance = (v3 - LastPortal.transform.position).magnitude;
            if (distance > MinDistancePortals)
            {
                GameObject portal = GetNextPortal();
                portal.transform.position = v3;
                LastPortal = portal;
            }
        }
	
	}

    private GameObject GetNextPortal() {
        PortalCursor = (PortalCursor + 1) % PortalsList.Count;
        return PortalsList[PortalCursor];
    }

   public  void notifyPortalHit(GameObject portalHitted, GameObject obj){
        var timeStamp = Time.time;
        if (timeStamp - PortalHitTimeStamp > PortalDesactivationDuration) {
            PortalHitTimeStamp = timeStamp;

            GameObject otherPortal = null;
            foreach (GameObject portal in PortalsList) {
                if (portal != portalHitted) {
                    otherPortal = portal;
                    break;
                }
            }
            var position = otherPortal.transform.position;
            position.z = obj.transform.position.z;
            obj.transform.position = position;
        }
    }
}
