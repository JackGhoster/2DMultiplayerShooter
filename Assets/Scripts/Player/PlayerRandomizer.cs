using UnityEngine;

/// <summary>
/// Randomizes various features of the player
/// </summary>
public class PlayerRandomizer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _playerSprite;

    private void Awake()
    {
        RandomizeColor();
    }

    /// <summary>
    /// Randomizes the hue of the player's part you want to reference! :)
    /// </summary>
    private void RandomizeColor()
    {
        var randomHue = Random.Range(0f, 1f);

        _playerSprite.color = Color.HSVToRGB(randomHue, 1, 1);
    }
}
