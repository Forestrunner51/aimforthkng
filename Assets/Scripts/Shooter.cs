using UnityEngine;
using UnityEngine.InputSystem;
public class Shooter : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Fire;
    public GameObject HitPoint;
    InputAction shootAction;

    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Fire");
    }
    void Update()
    {
        if (shootAction.IsPressed())
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        Debug.Log("Shooting");


        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit, 100))
        {
            Debug.DrawRay(FirePoint.position, FirePoint.forward * hit.distance, Color.yellow, 2f);
            GameObject a = Instantiate(Fire, FirePoint.position, Quaternion.identity);
            GameObject b = Instantiate(HitPoint, hit.point, Quaternion.identity);
            Debug.Log("Did Hit: " + hit.collider.name);
            Destroy(a,1);
            Destroy(b,1);
        }

    }
}
