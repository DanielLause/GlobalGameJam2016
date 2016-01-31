<<<<<<< HEAD
﻿
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
=======
﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc
{
    public bool ShowLaser;

    public float Damage;
    public float Delay = 0.2f;

<<<<<<< HEAD
    public float RotationSensivity;
    public float MaxYRotation = 100;
    public float MinYRotation = 0;

    public Transform TransFormToRotateFrom;
    [Tooltip("Put Cam Target here")]
    public Transform ReferenceTransfrom;

    public GameObject ImpactObject;

    [HideInInspector]
    public bool Shooting = false;

    public Animator Animator;

    public Transform myTransform;

    private ParticleSystem shootParticle;
    private AudioSource sound;
    private LineRenderer lineRenderer;
    private bool playSound = false;

    private bool canShoot = true;

    private float rotationY;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        shootParticle = GetComponent<ParticleSystem>();
        sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;
    }

    void Update()
    {
        RenderLaser();
        //Shoot();
        ShowTraycers();
        PlaySound();
    }

    void LateUpdate()
    {
        GetYRotation();
    }

    private void GetYRotation()
    {
        rotationY += Input.GetAxis("Mouse Y") * RotationSensivity;

        if (rotationY < MinYRotation)
            rotationY = MinYRotation;

        if (rotationY > MaxYRotation)
            rotationY = MaxYRotation;

        Vector3 target = TransFormToRotateFrom.position + (TransFormToRotateFrom.forward.normalized * 500);

        target.y = rotationY;

        //print(rotationY);

        TransFormToRotateFrom.LookAt(target);

    }
=======
    public GameObject ImpactObject;

    private Transform myTransform;
    private ParticleSystem shootParticle;
    private AudioSource sound;
    private LineRenderer lineRenderer;

    private bool canShoot = true;

	void Awake () 
    {
        lineRenderer = GetComponent<LineRenderer>();
        myTransform = GetComponent<Transform>();
        shootParticle = GetComponent<ParticleSystem>();
        sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;
	}
	
	void Update () 
    {
        RenderLaser();
        Shoot();
        ShowTraycers();
        PlaySound();
	}
>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc

    private void RenderLaser()
    {
        if (ShowLaser)
        {
            Vector3 end = myTransform.position + (myTransform.forward.normalized * 1000);

            lineRenderer.SetPosition(0, myTransform.position);
            lineRenderer.SetPosition(1, end);
        }
    }

    private void Shoot()
    {
        float input = Input.GetAxis("Fire1");

        if (canShoot && input == 1)
        {
            RaycastHit hit = new RaycastHit();

            Ray ray = new Ray(myTransform.position, myTransform.forward);

            if (Physics.Raycast(ray, out hit, 10000))
            {
                if (hit.transform.gameObject.GetComponent<Health>() as Health != null)
                {
                    Health otherHealth = hit.transform.gameObject.GetComponent<Health>();

                    otherHealth.RemoveHealth(this.Damage);
                }
                else
                {
                    Vector3 tempPos = myTransform.position - hit.point;

                    Quaternion q = Quaternion.LookRotation(tempPos);

                    Instantiate(ImpactObject, hit.point, q);
                }
            }
        }
    }

    private void PlaySound()
    {
        float input = Input.GetAxis("Fire1");

        if (canShoot && input == 1)
        {
<<<<<<< HEAD
            if (!playSound)
            {
                StartCoroutine(SoundDelay());
            }
            if (!sound.isPlaying && playSound)
            {
                sound.Play();
            }
        }
        else
        {
            sound.Stop();
            playSound = false;
        }
=======
            if (!sound.isPlaying)
                sound.Play();
        }
        else
            sound.Stop();
>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(Delay);
        canShoot = true;
        StartCoroutine(ShootTimer());
    }

    private void ShowTraycers()
    {
        float input = Input.GetAxis("Fire1");

        if (input == 1)
        {
<<<<<<< HEAD
            Animator.SetInteger("Shoot", 1);
            StartCoroutine(AnimationDelay());
=======
            if (!shootParticle.isPlaying)
                shootParticle.Play();
>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc
        }
        else
        {
            if (shootParticle.isPlaying)
                shootParticle.Stop();
<<<<<<< HEAD
            Shooting = false;
            Animator.SetInteger("Shoot", 0);
        }
    }

    IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(1.05f);
        if (!shootParticle.isPlaying)
            shootParticle.Play();
        Shooting = true;
    }

    IEnumerator SoundDelay()
    {
        yield return new WaitForSeconds(1.05f);
        Shoot();
        playSound = true;
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(ShootTimer());
    }
}
=======
        }
    }
}
>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc
