using UnityEngine;
using TMPro;

public class PlayerSwordPickup : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Drag the sword GameObject here")]
    public GameObject sword;
    [Tooltip("Drag the player's right hand bone here")]
    public Transform rightHand;
    [Tooltip("Drag the player's Animator component here")]
    public Animator animator;
    [Tooltip("Drag the sword-wielding Animator Controller here")]
    public RuntimeAnimatorController swordAnimatorController;
    [Tooltip("Drag the TextMeshPro UI element for pickup prompts here")]
    public TextMeshProUGUI pickupPrompt;

    [Header("Animation Parameters")]
    [Tooltip("Matches the 'isIdle' parameter in Animator")]
    public string idleParam = "isIdle";
    [Tooltip("Matches the 'moveSpeed' parameter in Animator")]
    public string moveParam = "moveSpeed";
    [Tooltip("Matches the 'attack' trigger in Animator")]
    public string attackParam = "attack";
    [Tooltip("Matches the 'jump' trigger in Animator")]
    public string jumpParam = "jump";

    private bool isNearSword = false;
    private bool hasSword = false;

    void Update()
    {
        if (!hasSword)
        {
            // Only check for pickup when player doesn't have sword
            if (isNearSword && Input.GetKeyDown(KeyCode.I))
            {
                PickUpSword();
            }
            return;
        }

        // Calculate movement input magnitude (0-1)
        float moveInput = Mathf.Clamp01(
            Mathf.Abs(Input.GetAxis("Vertical")) + 
            Mathf.Abs(Input.GetAxis("Horizontal"))
        );

        // Set animation parameters
        animator.SetBool(idleParam, moveInput < 0.1f);
        animator.SetFloat(moveParam, moveInput);

        // Combat controls
        if (Input.GetMouseButtonDown(0)) // Left click attack
        {
            animator.SetTrigger(attackParam);
            // Reset other triggers to prevent conflicts
            animator.ResetTrigger(jumpParam);
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Jump
        {
            animator.SetTrigger(jumpParam);
            animator.ResetTrigger(attackParam);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword") && !hasSword)
        {
            isNearSword = true;
            pickupPrompt.text = "Press I to pick up the sword";
            pickupPrompt.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            isNearSword = false;
            pickupPrompt.text = "";
            pickupPrompt.gameObject.SetActive(false);
        }
    }

    void PickUpSword()
    {
        // Attach sword to hand
        sword.transform.SetParent(rightHand);
        sword.transform.localPosition = Vector3.zero;
        sword.transform.localRotation = Quaternion.Euler(182, 182, 30);

        // Disable sword physics
        var swordCollider = sword.GetComponent<Collider>();
        if (swordCollider != null) swordCollider.enabled = false;
        
        var swordRigidbody = sword.GetComponent<Rigidbody>();
        if (swordRigidbody != null) swordRigidbody.isKinematic = true;

        // Switch to sword-wielding animations
        if (swordAnimatorController != null)
        {
            animator.runtimeAnimatorController = swordAnimatorController;
            
            // Initialize animation state
            animator.SetBool(idleParam, true);
            animator.SetFloat(moveParam, 0f);
            animator.ResetTrigger(attackParam);
            animator.ResetTrigger(jumpParam);
        }
        else
        {
            Debug.LogError("Sword Animator Controller not assigned!");
        }

        // Clean up pickup prompt
        pickupPrompt.text = "";
        pickupPrompt.gameObject.SetActive(false);
        isNearSword = false;
        hasSword = true;

        Debug.Log("Sword picked up successfully");
    }
}