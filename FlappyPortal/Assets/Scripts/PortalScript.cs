using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {

    public PortalsManager managerReference;

    void OnTriggerEnter(Collider other)
    {
        managerReference.NotifyPortalHit(this.gameObject, other.gameObject);
    }
}
