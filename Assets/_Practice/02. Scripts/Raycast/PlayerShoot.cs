using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;

    public float shootPower = 30f;
    public float maxRange = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hitInfo, maxRange))
            targetPoint = hitInfo.point;
        else
            targetPoint = ray.GetPoint(maxRange);

        var shootDir = (targetPoint - shootPoint.position).normalized;
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.LookRotation(shootDir));
        
        var arrowRb =  arrow.GetComponent<Rigidbody>();
        arrowRb.AddForce(shootDir * shootPower, ForceMode.Impulse);
    }
}