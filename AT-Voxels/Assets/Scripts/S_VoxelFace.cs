using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class VoxelFace : MonoBehaviour
{
    [SerializeField] float m_raycastDistance;
    [SerializeField] Transform m_originTransform;
    [SerializeField] List<GameObject> m_meshes = new List<GameObject>();

    public Transform GetOriginTransform => m_originTransform;

    Material m_currentMaterial;
   

   
    public void UpdateBaseMaterial(Material _newMaterial)
    {
        if(m_currentMaterial != _newMaterial) 
        { 
            for (int i = 0; i < m_meshes.Count; i++)
            {
                MeshRenderer _meshRenderer = m_meshes[i].GetComponent<MeshRenderer>();
                _meshRenderer.material = _newMaterial;
            }

            
        }
        
    }


    public void UpdateAdditionalMaterials(int _index, Material _material)
    {
        for(int i = 0; i < m_meshes.Count; i++) 
        { 
           MeshRenderer _meshRenderer = m_meshes[i].GetComponent<MeshRenderer>();
           Material[] _materialArray = _meshRenderer.materials;
          
           _materialArray[_index] = _material; 
           _meshRenderer.materials = _materialArray;
                
        }       
    }


}
