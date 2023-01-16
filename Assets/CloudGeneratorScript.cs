using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{

    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CloudSpawnLoop(spawnInterval));
    }

    void SpawnCloud()
    {
        float scale = UnityEngine.Random.Range(0.8f, 1.4f);
        float generatorVerticalPosition = transform.position.y;
        float cloudVerticalPosition = UnityEngine.Random.Range(generatorVerticalPosition - 10, generatorVerticalPosition + 10);
        GameObject cloudClone = Instantiate(cloud);

        //endPoint is a GameObject that is put physically on the scene
        //instead of hardcoding or calculating the place where the object gets destroyed, it gets x position fo End Point GameObject.
        cloudClone.transform.localScale = new Vector2(scale, scale);
        cloudClone.transform.position = new Vector3(transform.position.x, cloudVerticalPosition, 9);
        cloudClone.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);
    }

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
