using UnityEngine;

/// <summary>
/// Manages children in poolers like Coin Pooler.
/// </summary>
public class PoolerChildrenManager : MonoBehaviour
{
    //Set boundaries here on in inspector
    [SerializeField, Range(-20, 20)]
    private float _minPosX = 0, _maxPosX = 0, _minPosY = 0, _maxPosY = 0;

    private void Start()
    {
        SetRandomPos();
    }

    /// <summary>
    /// Sets position of the children to be random within the boundaries
    /// </summary>
    private void SetRandomPos()
    {
        foreach (Transform child in gameObject.transform)
        {           
            if (child.gameObject.activeSelf == false)
            {
                var randomX = Random.Range(_minPosX, _maxPosX);
                var randomY = Random.Range(_minPosY, _maxPosY);
                Vector2 randomPos = new Vector2(randomX, randomY);

                child.position = randomPos;
                child.gameObject.SetActive(true);
            }
        }
    }
}
