using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {

    public PortalsManager managerReference;

    void OnTriggerEnter(Collider other)
    {
        managerReference.notifyPortalHit(this.gameObject, other.gameObject);
    }
}
