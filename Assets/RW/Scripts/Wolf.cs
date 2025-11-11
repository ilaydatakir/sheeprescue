using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public float runSpeed = 10f;
    public float gotFireDestroyDelay = 1f;
    public float dropDestroyDelay = 4f;
    private bool hitByFire;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;

    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByFire()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByFire = true;
        runSpeed = 0;

        Rotate rotate = gameObject.AddComponent<Rotate>();
        rotate.rotationSpeed = new Vector3(0, 360, 0);

        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = gotFireDestroyDelay;

        GameStateManager.Instance.SavedSheep();

        Destroy(gameObject, gotFireDestroyDelay);
    }

    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
        GameStateManager.Instance.DroppedSheep();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball") && !hitByFire)
        {
            Destroy(other.gameObject);
            HitByFire();
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }

        else if (other.CompareTag("Hay"))
        {
            runSpeed = runSpeed * 1.2f;
            transform.position += transform.forward * 3;
        }
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}