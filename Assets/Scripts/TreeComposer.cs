using UnityEngine;

public class TreeComposer : MonoBehaviour
{
    [SerializeField] Tree _treePrefab;
    [SerializeField] GameObject _piece10;

    public Tree Create(int numberOfRows, int fraction)
    {
        Tree tree = Instantiate(_treePrefab, Vector3.zero, Quaternion.identity);
        tree.Create(numberOfRows, 10, _piece10);
        return tree;
    }
}
