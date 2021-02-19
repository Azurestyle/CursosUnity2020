using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;

    public float jumpForce = 1f;

    public float gravityMultiplaier;
    // Start is called before the first frame update
    public bool OnGround = true;
    private Animator _animator;
    const string speedMultiplier = "Speed_multiplier";
    private const string jumpTrig = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";
    private bool _gameOver = false;
    public ParticleSystem explosion, dirt;
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    [Range(0,1)]
    public float audioVolume = 1f;

    private float speedMultiplier2;
    public bool GameOver
    {
        get => _gameOver;
    }
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplaier*new Vector3(0,-9.81f,0);
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed_f", 1);
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier2 += Time.deltaTime / 10;
        _animator.SetFloat(speedMultiplier,speedMultiplier2);
        if (Input.GetKeyDown(KeyCode.Space) && OnGround && !GameOver)
        {   
            playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse); // F= m*a
            OnGround = false;
            _animator.SetTrigger(jumpTrig);
            dirt.Stop();
            _audioSource.PlayOneShot(jumpSound,audioVolume );
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        OnGround = true;
        dirt.Play();

        if (other.gameObject.CompareTag("Enemy"))
        {
            _gameOver = true;
            explosion.Play();
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATH_TYPE_INT, Random.Range(1,3));
            dirt.Stop();
            _audioSource.PlayOneShot(crashSound,audioVolume );
            Invoke("RestartGame",1.0f);
        }
        
    }

    void RestartGame()
    {
        speedMultiplier2 = 1;
        SceneManager.LoadSceneAsync("Prototype 3", LoadSceneMode.Single);
    }
}
