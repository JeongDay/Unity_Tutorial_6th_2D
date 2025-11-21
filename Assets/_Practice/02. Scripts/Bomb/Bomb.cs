using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Collider[] colliders;
    public LayerMask layerMask;

    public GameObject particleObj;
    public GameObject particleObj2;

    public float bombPower = 500f;
    public float bombRange = 100f;
    public float bombHeight = 10f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2.2f);
        particleObj2.SetActive(true);

        yield return new WaitForSeconds(4f);
        particleObj.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        Explosion();
    }

    private void Explosion()
    {
        colliders = Physics.OverlapSphere(transform.position, 10f, layerMask);

        foreach (var coll in colliders)
            coll.GetComponent<Rigidbody>().AddExplosionForce(bombPower, transform.position, bombRange, bombHeight);

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}