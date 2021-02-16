using UnityEngine.UI;

public partial class QLRaycastBox : Image
{
    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        toFill.Clear();
    }
}
