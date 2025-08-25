using UnityEngine;

public class Sun : PoolingObj
{
    [SerializeField] protected SunSO sunSO;
    public SunSO SunSO => sunSO;
    [SerializeField] protected SunSpawner spawner;
    [SerializeField] protected float dropToYPos;
    [SerializeField] protected float speed;
    [SerializeField] protected SetDownPlant setDownPlant;
    public LayerMask layerMask;
    [SerializeField] protected Sun sun;
    protected override void OnEnable()
    {
        this.PosRandom();
    }
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.speed = this.sunSO.speedDrop;
        this.layerMask = this.sunSO.layer;
    }
    protected virtual void PosRandom()
    {        
        transform.position = new Vector2(Random.Range(this.sunSO.randomPosDop.posX_A, this.sunSO.randomPosDop.posX_B),this.sunSO.randomPosDop.posY);        
        this.dropToYPos = Random.Range(this.sunSO.randomToDopY.posA, this.sunSO.randomToDopY.posB);
    }
    public override string NameObj()
    {
        return "Sun";
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSunSO();
        sun = gameObject.GetComponent<Sun>();
        this.SunSpawn();
        this.LoadSetdownPlant();
    }
    protected virtual void LoadSunSO()
    {
        if (this.sunSO != null) return;
        this.sunSO = Resources.Load<SunSO>("Sun/Sun");
    }
    protected virtual void LoadSetdownPlant()
    {
        if (this.setDownPlant != null) return;
        this.setDownPlant = FindAnyObjectByType<SetDownPlant>();
    }
    protected virtual void SunSpawn()
    {
        if (this.spawner != null) return;
        this.spawner = FindAnyObjectByType<SunSpawner>();
    }   
    protected virtual void Update()
    {
        this.Falling();
        this.PickedSun();
    }
    protected virtual void Falling()
    {
        if (transform.position.y <= dropToYPos) return;        
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    protected virtual void PickedSun()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider == null) return;        
        if (Input.GetMouseButtonDown(0))
        {            
            Debug.Log("DropSUn :" + hit.collider.name, hit.collider.gameObject);
            ProgressLevel.Instance.IncreaseSun(this.sunSO.quantitySun);
            //spawner.Despawn(gameObject.GetComponent<Sun>());            
            spawner.Despawn(hit.collider.GetComponent<Sun>());            
        }
    }
    public virtual void DopToYPos(float pos)
    {
        dropToYPos = pos;
    }
}
