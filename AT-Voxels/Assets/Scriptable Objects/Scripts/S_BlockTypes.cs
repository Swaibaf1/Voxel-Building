using UnityEngine;
[CreateAssetMenu(menuName = "Voxel Types")]
public class VoxelTypes : ScriptableObject
{
    [SerializeField] VoxelData m_grayVoxel;
    [SerializeField] VoxelData m_redVoxel;
    [SerializeField] VoxelData m_greenVoxel;
    [SerializeField] VoxelData m_darkGrayVoxel;
    [SerializeField] VoxelData m_darkRedVoxel;
    [SerializeField] VoxelData m_darkGreenVoxel;

    public VoxelData GetGrayVoxel => m_grayVoxel;
    public VoxelData GetRedVoxel => m_redVoxel;
    public VoxelData GetGreenVoxel => m_greenVoxel;
    public VoxelData GetDarkGrayVoxel => m_darkGrayVoxel;
    public VoxelData GetDarkRedVoxel => m_darkRedVoxel;

    public VoxelData GetDarkGreenVoxel => m_darkRedVoxel;

}
