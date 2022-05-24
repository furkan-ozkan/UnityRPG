using UnityEditor.PackageManager;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class InteractWithItems : MonoBehaviour
{
    #region Attributes

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private bool interract = false;
    [SerializeField] private RaycastHit lastHitItem;

    private PlayerMovement _playerMovement;

    #endregion

    #region Start-Update

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        InterractItem();
    }

    #endregion

    #region Interract With Items Metods

    // Work on right click used on mouse.
    public void InterractItem()
    {
        bool rightMouseClicked = Input.GetMouseButtonDown(1);

        if (rightMouseClicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask) &&
                hit.collider.gameObject.GetComponent(typeof(IInteraction)))
            {
                // If you are close enough to item than directly interract with item.
                if (GetDistanceLower(transform.position, hit.transform.position, 2f))
                {
                    InterractFunc(hit);
                }
                // If you are not close enough than using PlayerMovement and walk to do interractable object.
                // and change interractable attribute because of control "am i close enough?"
                // save the last clicked item for use it later (when you close enough to object than we can interract with this attribute)
                else
                {
                    _playerMovement.clickedPoint = hit.point;
                    _playerMovement.WalkToPosition();
                    interract = true;
                    lastHitItem = hit;
                }
            }
        }
        // if we are close enough to object than update interractable boolean attribute an stop walkin(_isWalking for animation)
        // and use lastHitItem for reInterract with object
        if (interract && GetDistanceLower(transform.position, _playerMovement.clickedPoint, 1f))
        {
            interract = false;
            _playerMovement._isWalking = false;
            InterractFunc(lastHitItem);
        }
    }
    
    // Interract with object. You need an hit and this hit must be an IInterraction type.
    public void InterractFunc(RaycastHit hit)
    {
        hit.collider.GetComponent<IInteraction>().Action();
    }
    
    // Simple func. its gettin distance between current and target, and if distance shortest than distance attribute than return true.
    public bool GetDistanceLower(Vector3 current, Vector3 target, float distance)
    {
        return Vector3.Distance(current, target) < distance;
    }

    #endregion
}