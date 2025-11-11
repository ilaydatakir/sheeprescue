using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed; // 1
    public float gotHayDestroyDelay; // 2
    private bool hitByHay; // 3
    private bool hasDropped;

    public float dropDestroyDelay; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody; // 3
    private SheepSpawner sheepSpawner;

    public float heartOffset; // 1
    public GameObject heartPrefab; // 2



    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        hitByHay = true; // 1
        runSpeed = 0; // 2

        Destroy(gameObject, gotHayDestroyDelay); // 3

        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);

        TweenScale tweenScale = gameObject.AddComponent<TweenScale>(); ; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // 3

        SoundManager.Instance.PlaySheepHitClip();
        GameStateManager.Instance.SavedSheep();
    }

    private void HitByFireball()
    {
        runSpeed = 0; // 2

        Destroy(gameObject, gotHayDestroyDelay); // 3

        TweenScale tweenScale = gameObject.AddComponent<TweenScale>(); ; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // 3

        SoundManager.Instance.PlaySheepDroppedClip();
        GameStateManager.Instance.DroppedSheep();
    }

    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag("Hay") && !hitByHay) // 2
        {
            Destroy(other.gameObject); // 3
            HitByHay(); // 4
        }

        else if (other.CompareTag("DropSheep") && !hasDropped)
        {
            Drop();
        }

        else if (other.CompareTag("Fireball") && !hasDropped)
        {
            Destroy(other.gameObject);
            HitByFireball();
        }

    }
    private void Drop()
    {
        hasDropped = true;
        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2

        SoundManager.Instance.PlaySheepDroppedClip();
        GameStateManager.Instance.DroppedSheep();

        Destroy(gameObject, dropDestroyDelay); // 3


    }

}