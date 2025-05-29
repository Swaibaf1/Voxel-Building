using UnityEngine;
using UnityEngine.InputSystem;


public class SelectionScript : MonoBehaviour
{
    VoxelPlacer m_voxelPlacer;

    Camera m_cam;
   
    VoxelFunctionality m_previousVoxelScript;
    VoxelFunctionality m_currentVoxelScript;
    VoxelFace m_previousFaceScript;
    VoxelFace m_currentFaceScript;

    E_BrushType m_brushType;

    [SerializeField] LayerMask m_hittableLayer;

    VoxelData m_selectedVoxelData;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_cam = Camera.main;
        m_voxelPlacer = this.gameObject.GetComponent<VoxelPlacer>();
        m_brushType = E_BrushType.PAINT;
        m_selectedVoxelData = m_voxelPlacer.InitialVoxel;
    }



    // Update is called once per frame
    void Update()
    {
       
        Vector3 _mousePosition = Input.mousePosition;

        Ray _ray = Camera.main.ScreenPointToRay(_mousePosition);

        // does a raycast from parent's transform to the object the mouse is hovering over. 
        // if the object has the correct layer mask, check for Voxel script in object's parent
        // if script is found, run "select voxel" functionality

        if(Physics.Raycast(_ray, out RaycastHit _hitData, 100, m_hittableLayer))
        {

            m_currentVoxelScript = 
                _hitData.collider.gameObject.GetComponentInParent<VoxelFunctionality>();
            m_currentFaceScript = 
                _hitData.collider.gameObject.GetComponentInParent<VoxelFace>();

            if (m_currentFaceScript == null)
            { print("null face script"); }

            if( m_currentVoxelScript  != null)
            {
                if(m_previousVoxelScript == null)
                {
                    m_currentVoxelScript.SelectVoxel();
                    m_previousVoxelScript = m_currentVoxelScript;

                }
                else if(!m_currentVoxelScript.GetIsHighlighted)
                {
                    m_previousVoxelScript.DeselectVoxel();
                    m_currentVoxelScript.SelectVoxel();
                    m_previousVoxelScript = m_currentVoxelScript;
                }
            }
            
        }
        else if(m_previousVoxelScript != null)
        {
            m_previousVoxelScript.DeselectVoxel();
            m_currentVoxelScript = null;
            m_currentFaceScript = null;


        }
       
    }



    public void OnVoxelClicked(InputAction.CallbackContext _context)
    {
        if(_context.started && m_currentVoxelScript != null)
        {
            if(m_selectedVoxelData != null)
            {
                switch(m_brushType)
                {
                    case (E_BrushType)0:
                        m_currentVoxelScript.Paint(m_selectedVoxelData);
                        break;
                    case (E_BrushType)1:
                        m_currentVoxelScript.Break();
                        break;
                    case (E_BrushType)2:
                        m_voxelPlacer.OnVoxelPlaced(m_currentFaceScript.GetOriginTransform, m_selectedVoxelData);
                        break;
                }
            }

        }
    }

    public void OnToolButtonClicked(int _type)
    {
        switch(_type)
        {
            case 0:
                m_brushType = E_BrushType.ERASE;
                break;
            case 1:
                m_brushType = E_BrushType.PAINT;
                break;
            case 2:
                m_brushType = E_BrushType.PLACE;
                break;

        }
    }

    public void OnMaterialButtonClicked( VoxelData _data)
    {
        
        m_selectedVoxelData = _data;

    }

}
