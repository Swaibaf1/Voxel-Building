using Unity.VisualScripting.FullSerializer;
using UnityEngine;



[CreateAssetMenu(menuName = "Voxel Object")]
public class VoxelData : ScriptableObject
{
    [SerializeField] E_VoxelType m_type;
    public Material m_material;
    public E_VoxelType GetBlockType { get { return m_type; } }
    public Material GetMaterial { get { return m_material; } }

}
