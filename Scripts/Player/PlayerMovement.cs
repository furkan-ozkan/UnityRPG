using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    #region Attributes

    private NavMeshAgent _navMeshAgent;

    [Header("Walk Attributes")]
    [SerializeField] private LayerMask _layerMask;
    public bool _isWalking = false;

    [Header("Destination Informations")]
    [Tooltip("Dont change just for debuging!")]
    public Vector3 clickedPoint;

    #endregion

    #region Start Update

    private void Start()
    {
        //  Getting "NavMesh Agent" component
        _navMeshAgent = GetComponent<NavMeshAgent>();

        //  Setting a default value for first time.
        clickedPoint = transform.position;
    }

    private void Update()
    {
        GetWalkPoint();
    }

    #endregion

    #region Walking

    //  After mouse 0 clicked update clickedPoint and set destination for walk.
    public void GetWalkPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //  When clicked mouse 0 update values and change _isWalking as true.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
            {
                clickedPoint = hit.point;
                _isWalking = true;
                Walk();
            }
        }

        //  If character closer than 0.2f to clicked point than change _isWalking as false.
        if (Vector3.Distance(transform.position, clickedPoint) < 0.2f)
        {
            _isWalking = false;
        }
    }

    public void WalkToPosition()
    {
        if (Vector3.Distance(transform.position, clickedPoint) > 0.2f)
        {
            _isWalking = true;
            Walk();
        }
    }

    //  If _isWaling true than move character.
    public void Walk()
    {
        if (_isWalking)
        {
            _navMeshAgent.SetDestination(clickedPoint);
        }
    }

    #endregion
}