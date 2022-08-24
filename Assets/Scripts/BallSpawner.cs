using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    public bool enableRandomSpawnPoint = true;
    [SerializeField]
    Transform spawnLocation = null;
    [SerializeField]
    Transform SpawnPointParent = null;
    [SerializeField]
    GameObject Ball = null;
    [SerializeField]
    float BounceCoefficient = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        GameObject newBall = Instantiate(Ball);
        newBall.GetComponent<BouncyBall>().SetBounceCoefficient(BounceCoefficient);
        if (enableRandomSpawnPoint)
        {
            int spawmPointCount = SpawnPointParent.childCount;
            int randomSpawnPointIndex = Random.Range(0, spawmPointCount);
            newBall.transform.position = SpawnPointParent.GetChild(randomSpawnPointIndex).position;
        }
        else
        {
            newBall.transform.position = spawnLocation.position;
        }
    }

    public void SetBounceCoefficient(float bounceCoeff)
    {
        BounceCoefficient = bounceCoeff;
    }
}
