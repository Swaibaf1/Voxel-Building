using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoxelFunctionality : MonoBehaviour
{
#region variables
    [SerializeField] VoxelData m_currentVoxelData = null;
    [SerializeField] Material m_currentMaterial;
    [SerializeField] Material m_highlightMaterial;
    [SerializeField] Material m_blankMaterial;
    bool m_isHighlighted = false;
    public bool GetIsHighlighted => m_isHighlighted;
#endregion
    [SerializeField] List<GameObject> m_faces = new List<GameObject>();
    public void UpdateVoxelType(VoxelData _newVoxelData)
    {
            m_currentVoxelData = _newVoxelData;
            UpdateBaseMaterials(_newVoxelData.GetMaterial);
    }
    public void SelectVoxel()
    {
        m_isHighlighted = true;
        UpdateHighlightedMaterial(1, m_highlightMaterial);
    }
    public void DeselectVoxel()
    {
       m_isHighlighted = false;
       UpdateHighlightedMaterial(1,null);
    }
    public void UpdateHighlightedMaterial(int _index, Material _material)
    {
        for (int i = 0; i <  m_faces.Count; i++) 
        {
            VoxelFace _script = m_faces[i].GetComponent<VoxelFace>();
            _script.UpdateAdditionalMaterials(_index, _material);
        }
    }
    public void UpdateBaseMaterials(Material _material)
    {
        for(int i = 0;  i < m_faces.Count; i++)
        {
            VoxelFace _script = m_faces[i].GetComponent<VoxelFace>();
            _script.UpdateBaseMaterial(_material);
        }
    }
    public void Break()
    {
        Destroy(this.gameObject);
    }
    public void Paint(VoxelData _voxelData)
    {
        UpdateBaseMaterials(_voxelData.GetMaterial);
    }
}


