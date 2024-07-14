using UnityEngine;

public class WavesParallax : MonoBehaviour
{
    [SerializeField] private GameObject[] waves;
    [SerializeField] private float speed;

    [SerializeField] private float verticalAmplitude = 0.5f;
    [SerializeField] private float verticalFrequency = 1f;

    private float _verticalOffset;
    private float _spriteWidth;

    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;

        if (waves.Length > 0)
        {
            _spriteWidth = waves[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    private void Update()
    {
        _verticalOffset = Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;

        MoveSprites();
    }

    private void MoveSprites()
    {

        if (_player == null) return;
        foreach (var sprite in waves)
        {
            sprite.transform.position += new Vector3(speed * Time.deltaTime, _verticalOffset * Time.deltaTime, 0);

            if (sprite.transform.position.x > _player.position.x - _spriteWidth * (waves.Length-1)/2)
            {
                RepositionSprite(sprite, -_spriteWidth * waves.Length);
            }

            if (sprite.transform.position.x < _player.position.x - _spriteWidth * (waves.Length - 1)/2)
            {
                RepositionSprite(sprite, _spriteWidth * waves.Length);
            }
        }
    }

    private void RepositionSprite(GameObject sprite, float offset)
    {
        sprite.transform.position += new Vector3(offset, 0, 0);
    }
}