using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls picking up and interacting with objects in the scene.
/// </summary>
public class PickUpControl : MonoBehaviour
{
    [Header("Interactable Info")]
    [SerializeField] private float sphereCastRadius = 0.5f;
    [SerializeField] private int interactableLayerIndex;
    private Vector3 raycastPos;
    [SerializeField] private GameObject lookObject;
    private PhysicsObject physicsObject;
    private Camera mainCamera;

    [Header("Pickup")]
    [SerializeField] private Transform pickupParent;
    private GameObject currentlyPickedUpObject;
    private Rigidbody pickupRB;

    [Header("Object Follow")]
    [SerializeField] private float minSpeed = 0;
    [SerializeField] private float maxSpeed = 300f;
    [SerializeField] private float maxDistance = 10f;
    private float currentSpeed = 0f;
    private float currentDist = 0f;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 100f;
    private Quaternion lookRot;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // A simple visualization of the point we're following in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pickupParent.position, 0.5f);
    }

    // Interactable Object detections and distance check
    void Update()
    {
        // Check if we're currently looking at an interactable object
        raycastPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.SphereCast(raycastPos, sphereCastRadius, mainCamera.transform.forward, out hit, maxDistance, 1 << interactableLayerIndex))
        {
            lookObject = hit.collider.transform.gameObject;
        }
        else
        {
            lookObject = null;
        }

        // Check if the pickup button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<AudioManager>().Stop("gun equipped");
            FindObjectOfType<AudioManager>().Stop("Laser Gun 2");

            // Check if we're not holding anything and looking at an interactable object
            if (currentlyPickedUpObject == null && lookObject != null)
            {
                PickUpObject(); // Pick up the object
            }
            // Check if we press the pickup button and have something, then drop it
            else if (currentlyPickedUpObject != null)
            {
                BreakConnection(); // Release the object
            }
        }
    }

    // Velocity movement toward pickup parent and rotation
    private void FixedUpdate()
    {
        if (currentlyPickedUpObject != null)
        {
            currentDist = Vector3.Distance(pickupParent.position, pickupRB.position);
            currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, currentDist / maxDistance);
            currentSpeed *= Time.fixedDeltaTime;
            Vector3 direction = pickupParent.position - pickupRB.position;
            pickupRB.velocity = direction.normalized * currentSpeed;

            // Rotation
            lookRot = Quaternion.LookRotation(mainCamera.transform.position - pickupRB.position);
            lookRot = Quaternion.Slerp(mainCamera.transform.rotation, lookRot, rotationSpeed * Time.fixedDeltaTime);
            pickupRB.MoveRotation(lookRot);
        }
    }

    // Release the object
    public void BreakConnection()
    {
        pickupRB.constraints = RigidbodyConstraints.None;
        currentlyPickedUpObject = null;
        physicsObject.pickedUp = false;
        currentDist = 0;
    }

    // Pick up the object
    public void PickUpObject()
    {
        physicsObject = lookObject.GetComponentInChildren<PhysicsObject>();
        currentlyPickedUpObject = lookObject;
        pickupRB = currentlyPickedUpObject.GetComponent<Rigidbody>();
        pickupRB.constraints = RigidbodyConstraints.FreezeRotation;
        physicsObject.playerInteractions = this;
        StartCoroutine(physicsObject.PickUp());
    }
}
