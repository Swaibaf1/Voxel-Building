using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VoxelPlacer : MonoBehaviour
{
    #region variable info 
    [SerializeField] VoxelData m_initialVoxel;
    [SerializeField] Vector3 m_GridDimensions;
    [SerializeField] float m_cellSize;

    [SerializeField] Transform m_parentTransform;
    
    [SerializeField] GameObject m_obj;
    [SerializeField] List<GameObject> m_VoxelList = new List<GameObject>();
    [SerializeField] VoxelTypes m_voxelTypes;
    #endregion
    public VoxelTypes GetVoxelTypes => m_voxelTypes;
    public VoxelData InitialVoxel => m_initialVoxel;

    void Awake()
    {
        InstantiateVoxels();

    }

    void InstantiateVoxels()
    {
        // Places initial voxels based on grid values put in by user
        for (int i = 0; i < m_GridDimensions.x; i++)
        {
            for (int j = 0; j < m_GridDimensions.y; j++)
            {
                for (int k = 0; k < m_GridDimensions.z; k++)
                {
                    Vector3 _indexes = new Vector3(i,j,k) * m_cellSize;

                    PlaceVoxel(m_parentTransform.localPosition + _indexes, Quaternion.identity, m_initialVoxel);
               
                }
            }
        }
    }

    public void PlaceVoxel(Vector3 _position, Quaternion _rotation, VoxelData _voxelData)
    {
        //Instantiates a voxel object, sets its transform values, adds it to the voxel list and sets its type

        GameObject _obj = 
            Instantiate(m_obj, _position, _rotation, m_parentTransform);

        _obj.transform.localScale = new Vector3(m_cellSize, m_cellSize, m_cellSize);

        m_VoxelList.Add(_obj);

        if (_obj.GetComponent<VoxelFunctionality>() != null)
        {
            VoxelFunctionality _script = _obj.GetComponent<VoxelFunctionality>();
            _script.UpdateVoxelType(_voxelData);
        }

    }

    public void OnVoxelPlaced(Transform _transform, VoxelData _voxelData)
    {
        PlaceVoxel(_transform.position, _transform.rotation, _voxelData);       
    }

    public void ResetAllVoxels()
    {
        m_parentTransform.position = Vector3.zero;
        for (int i = 0; i < m_VoxelList.Count; i++)
        {
            GameObject _obj = m_VoxelList[i];

            Destroy(_obj);
        }
        m_VoxelList.Clear();
        ResetRotation();
        InstantiateVoxels();
        
    }

    public void ResetRotation()
    {
        m_parentTransform.rotation = Quaternion.identity;
        m_parentTransform.position = Vector3.zero;
    }

}
