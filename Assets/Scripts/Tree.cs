using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Tree : MonoBehaviour
{
    [SerializeField] GameObject _treeScaler;
    [SerializeField] Material _goodMaterial;
    [SerializeField] Material _badMaterial;

    public float _ROW_HEIGHT = 5f;

    [Header("DEBUG INFO")]
    GameObject _piece;
    public int _fraction;
    public int _numberOfRows;

    public float height => _treeScaler.transform.localScale.y;

    UnityEvent<(GameObject player, GameObject piece)> _onBadPieceCollision;
    UnityEvent<(GameObject player, GameObject piece)> _onGoodPieceCollision;

    public void Awake()
    {
        _onBadPieceCollision = new UnityEvent<(GameObject player, GameObject piece)>();
        _onBadPieceCollision.AddListener((arg) => { GameManager.Get.GameOver(); });
        _onBadPieceCollision.AddListener(Bounce);

        _onGoodPieceCollision = new UnityEvent<(GameObject player, GameObject piece)>();
        _onGoodPieceCollision.AddListener(Bounce);
    }

    void Bounce((GameObject player, GameObject piece) arg)
    {
        arg.player.transform.DOPunchScale(transform.up.normalized / 3f, 0.3f, 1, 1)
            .SetRelative(true)
            .SetLoops(1, LoopType.Yoyo)
            .OnComplete(() => { arg.player.transform.localScale = Vector3.one; });
    }


    public void Create(int numberOfRows, int fraction, GameObject piece)
    {
        _piece = piece;
        _fraction = fraction;
        _numberOfRows = numberOfRows;
        _Create();
    }

    private void _Create()
    {
        _treeScaler.transform.localScale = new Vector3(1, _ROW_HEIGHT * _numberOfRows, 1);
        for (int i = 0; i < _numberOfRows; i++)
            _CreateRow(i);
    }

    private void _CreateRow(int i)
    {
        int elapsed = Random.Range(0, _fraction);
        for (int k = 0; k < _fraction; k++)
        {
            if (k == elapsed)
                continue;
            GameObject obj = Instantiate(_piece, new Vector3(0, i * _ROW_HEIGHT, 0), Quaternion.Euler(0, k * 360 / _fraction, 0), this.transform);
            MeshRenderer var = obj.GetComponentInChildren<MeshRenderer>();

            if (Random.Range(0, 100) <= 10)
            {
                var.material = _badMaterial;
                obj.GetComponentInChildren<PizzaSlide>()._onCollision = _onBadPieceCollision;
            }
            else
            {
                var.material = _goodMaterial;
                obj.GetComponentInChildren<PizzaSlide>()._onCollision = _onGoodPieceCollision;
            }
        }
    }

}
