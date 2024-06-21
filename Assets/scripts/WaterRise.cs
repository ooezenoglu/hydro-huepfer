using UnityEngine;

public class WaterRise : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float boostDistance;
    [SerializeField] private float boostTime;

    private Camera _cam;
    private float _baseSpeed;
    private float _distance;
    private GameObject _player;
    private bool _playerAlive = true;

    private void Start()
    {
        _cam = Camera.main;
        _player = GameObject.FindGameObjectWithTag("Player");
        _baseSpeed = speed;
    }

    private void Update()
    {
        if (!_playerAlive) return;
        //TODO: after first jump -> boolean
        transform.Translate(Vector3.up * (speed * Time.deltaTime));

        DistanceBoost();
        BoostOverTime();
        KillPlayer();
    }

    private void DistanceBoost()
    {
        _distance = Vector2.Distance(transform.position, _cam.transform.position);
        speed = _distance > boostDistance ? _baseSpeed + _distance / 100 : _baseSpeed;
    }

    private void BoostOverTime()
    {
        if (!(Time.timeSinceLevelLoad >= boostTime)) return;
        speed = _baseSpeed + boostTime / 100;
        _baseSpeed = speed;
        boostTime += boostTime;
    }

    private void KillPlayer()
    {
       

        if (_player.transform.position.y <= transform.position.y)
        {
            UnityEngine.Object.Destroy(_player);
            _playerAlive = false;
        }
        
    }
}
