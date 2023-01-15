using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{

    [SerializeField] private GameObject[] clouds;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CloudSpawnLoop(spawnInterval));
    }

    void SpawnCloud()
    {
        int randomCloudIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomCloudIndex]);
        //endPoint is a GameObject that is put physically on the scene
        //instead of hardcoding or calculating the place where the object gets destroyed, it gets x position fo End Point GameObject.
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);
    }

    // TODO: Keep only 1 cloud Object and populate it randomly on screen

    private IEnumerator CloudSpawnLoop(float time)
    {
        WaitForSeconds waitTime = new WaitForSeconds(time);
        while (true)
        {
            SpawnCloud();
            yield return waitTime;
        }
    }

}
