using UnityEngine;
using System.Collections.Generic;

public class TreeComposer : MonoBehaviour
{
    [SerializeField] Tree _treePrefab;

    // To add more 
    [SerializeField] GameObject _piece10;

    Dictionary<int, (int rows, float badSparsity)> _difficultSheet;

    void Awake()
    {
        _difficultSheet = new Dictionary<int, (int rows, float badSparsity)>()
        {
            {1, (5,0.1f)},
            {2, (5,0.5f)},
            {3, (5,1f)},
            {4, (10,0.1f)},
            {5, (10,0.4f)},
            {6, (10,1f)},
        };
    }

    public Tree Create(int level)
    {

        Tree tree = Instantiate(_treePrefab, Vector3.zero, Quaternion.identity);

        (int rows, float badSparsity) = (3, 0.1f);
        if (level > 0)
            (rows, badSparsity) = _difficultSheet[Mathf.Min(level, 6)];

        tree.Create(rows, badSparsity, 10, _piece10);
        return tree;
    }
}
