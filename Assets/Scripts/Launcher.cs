using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject prefabProjectiles;
    [SerializeField] private Transform transformShootPos;
    [SerializeField] private float projectileSpeed;

    private XRGrabInteractable _grabInteractable;

    private void OnEnable()
    {
        _grabInteractable = this.GetComponent<XRGrabInteractable>();
        _grabInteractable.activated.AddListener(Fire);
    }

    private void OnDisable()
    {
        if (!_grabInteractable) return;
        
        _grabInteractable.activated.RemoveListener(Fire); 
    }

    public void Fire(ActivateEventArgs args)
    {
        GameObject newObject = Instantiate(prefabProjectiles, transformShootPos.position, transformShootPos.rotation);
        if (newObject.TryGetComponent(out Rigidbody rb))
        {
            ApplyForce(rb);
        }
    }

    private void ApplyForce(Rigidbody rb)
    {
        Vector3 force = transformShootPos.forward * projectileSpeed;
        rb.AddForce(force);
    }
    
}
