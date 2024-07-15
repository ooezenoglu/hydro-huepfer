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
    private AudioSource audioSource;
    public AudioClip whooshSound;

    public GameController GameController;

    private void Start()
    {
        _cam = Camera.main;
        _player = GameObject.FindGameObjectWithTag("Player");
        _baseSpeed = speed;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!Player.PlayerIsAlive) return;
        transform.Translate(Vector3.up * (speed * Time.deltaTime));

        DistanceBoost();
        BoostOverTime();
        KillPlayer();
    }


    // Falls die Distanz zwischen Wasser und Spieler zu hoch ist, wird das Wasser wieder schneller, damit der Spieler nicht unendlich
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
            audioSource.PlayOneShot(whooshSound);
            GameController.GameOver();
            Player.PlayerIsAlive = false;
        } 
    }
}
