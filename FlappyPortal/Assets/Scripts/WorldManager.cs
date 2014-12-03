using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour {

    public MonoBehaviour    HeroReference = null;
    public Camera           CameraReference = null;

    public int              MarkerPoolSize = 5;
    public int              yMarkerOffset = 5;
    public int              xMarkerDistance = 6;
    public int              playgroundWidth = 20;
    public int              playgroundHeight = 10;
    public List<GameObject> SpawnablesList;


    private List<GameObject> MarkerPool = null;
    private int MarkerCursor = 0;
    private GameObject LastMarkerPlaced = null;
    private float markerYPos = 0;

    private float TimeAccumulator = 0.0f;

    public float MinTimeBetweenElements = 0.5f;
    public float MaxTimeBetweenElements = 2.0f;

    private List<GameObject> SpawnedObjectList = new List<GameObject>();
    private List<GameObject> ToBeDestroyedList = new List<GameObject>();
	// Use this for initialization
	void Start () {
        this.MarkerPool = new List<GameObject>(this.MarkerPoolSize);
        var initPos = new Vector3(-20,-20,-20);
        
        for (int i = 0; i < this.MarkerPoolSize; ++i){
            GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
            marker.transform.position = initPos;
            this.MarkerPool.Add(marker);
        }

        markerYPos = HeroReference.transform.position.x + yMarkerOffset;
        var nbMarker = playgroundWidth / xMarkerDistance;
        for (int i = 0; i < nbMarker + 1; ++i) {
            LastMarkerPlaced = GetPooledMarker();

            var pos = HeroReference.transform.position;
            pos.y = markerYPos;
            pos.x = pos.x - playgroundWidth / 2 + i * xMarkerDistance;
            LastMarkerPlaced.transform.position = pos;
        }
	}

    // Update is called once per frame
    void Update()
    {
        PlaceMarkerIfNeeded();
        ElementsUpdate();
        destroyFarObject();
	}

    private GameObject GetPooledMarker() {
        this.MarkerCursor = (this.MarkerCursor + 1) % this.MarkerPoolSize;
        return this.MarkerPool[this.MarkerCursor];
    }

    private void PlaceMarkerIfNeeded() {
        var lastPosX = LastMarkerPlaced.transform.position.x;
        var nextPosX = CameraReference.transform.position.x + playgroundWidth / 2;
        if (lastPosX < nextPosX - xMarkerDistance ) { 
            var nextPos = new Vector3(nextPosX,markerYPos,0);
            LastMarkerPlaced = GetPooledMarker();
            LastMarkerPlaced.transform.position = nextPos;
        }
    }


    private void ElementsUpdate() {
        var dt = Time.deltaTime;
        TimeAccumulator -= dt;
        if (TimeAccumulator <= 0) {
            var span = MaxTimeBetweenElements - MinTimeBetweenElements;
            TimeAccumulator = Random.value * span + MinTimeBetweenElements;
            var element = SpawnRandomElements();
            SpawnedObjectList.Add(element);
        }
    }

    private GameObject SpawnRandomElements()
    {
        var eltBase = SpawnablesList[Mathf.FloorToInt(Random.value * SpawnablesList.Count *0.999f)];
        var originalPos = CameraReference.transform.position;
        var y = Mathf.Floor(Random.value * (playgroundHeight - 1)) - (playgroundHeight / 2) + 2;
        var eltPosition = new Vector3(originalPos.x + playgroundWidth / 2, y, 0.0f);
        var element = Instantiate(eltBase, eltPosition, Quaternion.identity) as GameObject;
        return element;
    }

    private void destroyFarObject() {
        var destroyLimit = CameraReference.transform.position.x - (playgroundWidth / 2);
        foreach (GameObject obj in SpawnedObjectList){
            if (obj.transform.position.x < destroyLimit) {
                ToBeDestroyedList.Add(obj);
            }
        }
        foreach (GameObject obj in ToBeDestroyedList)
        {
            DestroySpawnnedObject(obj);
        }
    }

    public void DestroySpawnnedObject(GameObject obj) {
        SpawnedObjectList.Remove(obj);
        Destroy(obj);
    }
}
