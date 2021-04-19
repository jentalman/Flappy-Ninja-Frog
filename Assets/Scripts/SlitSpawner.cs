using UnityEngine;

public class SlitSpawner : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawns;
    [SerializeField] private float _maxSpwnPositinY;
    [SerializeField] private float _minSpwnPositinY;
    [SerializeField] private float _maxSecondsSpawn;
    [SerializeField] private float _minSecondsSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Init(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawns)
        {
            if (TryGetObject(out GameObject slit))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minSpwnPositinY, _maxSpwnPositinY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                slit.SetActive(true);
                slit.transform.position = spawnPoint;

                _secondsBetweenSpawns = Random.Range(_minSecondsSpawn, _maxSecondsSpawn);

                DisableObjectAbroadScreen();
            }
        }
    }
}
