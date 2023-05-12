using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColor : MonoBehaviour
{
    [SerializeField]
    private List<SpriteRenderer> _walls = new List<SpriteRenderer>();

    private float _hueMod = 0.1f;

    private void Start()
    {
        InvokeRepeating("ChangeHueOverTime",0.2f,0.2f);
    }

    private void ChangeHueOverTime()
    {
        if (_hueMod <= 1f)
        {
            foreach (var sprite in _walls)
            {
                sprite.color = Color.HSVToRGB(_hueMod, 1f, 1f);
            }
            
        }
        else
        {
            _hueMod = 0f;
        }
        _hueMod += 0.01f;
    }
}
