using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField]
    private Texture2D _moveCursorTexture;
    [SerializeField]
    private Texture2D _resizeCursorTexture;
    [SerializeField]
    private LayerMask _interactableLayerMask;

    private Camera _camera;

    private const string EFFECTOR_CENTER_TAG_NAME = "EffectorCenter";
    private const string EFFECTOR_EDGE_TAG_NAME = "EffectorEdge";

    private Transform _activeEffector;
    private bool _isMoving;
    private bool _isResizing;
    

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        
    }


    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
            {
            Collider2D collider = CastRay();
              if(collider != null)
                {
                    _activeEffector = collider.transform; 
                    
                if(_activeEffector.CompareTag(EFFECTOR_CENTER_TAG_NAME))
                    {
                    _isMoving = true;
                    }
                else if(_activeEffector.CompareTag(EFFECTOR_EDGE_TAG_NAME))
                    {
                    _isResizing = true;
                    }
                }

           }
        if(Input.GetMouseButtonUp(0))
        {
            _isMoving = false;
            _isResizing = false;
            _activeEffector = null;
        }
        if(_isMoving)
        {
            DoMove();
        }
        if(_isResizing)
        {
            DoResize();
        }

        
    }

    private void DoMove ()
    {
        Vector3 worldMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _activeEffector.transform.parent.position = new Vector3(worldMousePosition.x, worldMousePosition.y, _activeEffector.transform.parent.position.z);

    }
    private void DoResize()
    {
        Vector3 worldMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _activeEffector.GetComponent<CircleShape>().Radius = Mathf.Clamp(Vector2.Distance(_activeEffector.position, worldMousePosition),.5f, 3f);
        Debug.Log("resize");
    }
   private Collider2D CastRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, _interactableLayerMask);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(EFFECTOR_CENTER_TAG_NAME))
            {
                //move
                Cursor.SetCursor(_moveCursorTexture, new Vector2(_moveCursorTexture.width / 2, _moveCursorTexture.height / 2), CursorMode.ForceSoftware);
            }
            else if (hit.collider.CompareTag(EFFECTOR_EDGE_TAG_NAME))
            {
                //resize
                Cursor.SetCursor(_resizeCursorTexture, new Vector2(_resizeCursorTexture.width / 2, _resizeCursorTexture.height / 2), CursorMode.ForceSoftware);
            }

        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        return hit.collider;
    }

    private void FixedUpdate()
    {
        CastRay();
    }
}
