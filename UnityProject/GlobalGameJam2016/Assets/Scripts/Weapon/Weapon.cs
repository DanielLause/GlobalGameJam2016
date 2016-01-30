using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
    public bool ShowLaser;

    public float Damage;
    public float Delay = 0.2f;

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
            if (!sound.isPlaying)
                sound.Play();
        }
        else
            sound.Stop();
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
            if (!shootParticle.isPlaying)
                shootParticle.Play();
        }
        else
        {
            if (shootParticle.isPlaying)
                shootParticle.Stop();
        }
    }
}
