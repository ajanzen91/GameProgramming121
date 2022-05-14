using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public int _maxCubes;
    public float _quickestSpawnTime, _slowestSpawnTime;
    public GameObject _baseCube;
    public int _numCubes;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = .25f;
        _numCubes = 0;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Wait());
        //Time.fixedDeltaTime = Time.timeScale;
        if (_numCubes < _maxCubes)
        {
            SpawnCubes();
        }

    }

    void SpawnCubes()
    {
        

        Instantiate(_baseCube);
        ++_numCubes;
    }

    IEnumerator Wait()
    {
        float randomTime = Random.Range(_quickestSpawnTime, _slowestSpawnTime);

        yield return new WaitForSeconds(randomTime);
    }
    
}
