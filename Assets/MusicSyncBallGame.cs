using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooler))]
public class MusicSyncBallGame : MonoBehaviour
{
    public Transform shootAt;
    public Transform shooter0;
    public Transform shooter1;
    public float speed = 5.0f;
    //public float interval = 3f;

    private float nextBallTime = 0f;
    private ObjectPooler pool;
    private GameObject activeBall;
    private int shooterId = 0;
    private Transform shooter;

    private void Start()
    {
        if (shootAt == null)
        {
            shootAt = Camera.main.transform;
        }
        pool = GetComponent<ObjectPooler>();
        if (pool == null)
        {
            Debug.LogError("BallGame requires ObjectPooler component");
        }

        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onBeatDetected);
    }

    void onBeatDetected()
    {
        if (Random.value > 0.5f)
        {
            shooterId = 1;
            shooter = shooter1;
        } else
        {
            shooterId = 0;
            shooter = shooter0;
        }
        ShootBall();
    }

    private void ShootBall()
    {
        activeBall = pool.GetPooledObject();
        activeBall.transform.position = shooter.position;
        activeBall.transform.rotation = Quaternion.identity;
        shooter.transform.LookAt(shootAt);
        activeBall.GetComponent<Rigidbody>().velocity = shooter.forward * speed;
        activeBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        activeBall.SetActive(true);
    }
}
