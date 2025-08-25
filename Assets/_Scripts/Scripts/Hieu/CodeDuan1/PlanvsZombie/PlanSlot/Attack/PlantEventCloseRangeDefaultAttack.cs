using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlantEventCloseRangeDefaultAttack : DamageSenderAbstract
{
    [SerializeField] protected PlantCtrl planCtrl;
    [SerializeField] protected CapsuleCollider2D rangeCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlantCtrl();
        this.LoadCollider();
    }
    protected virtual void LoadPlantCtrl()
    {
        if (this.planCtrl != null) return;
        this.planCtrl = GetComponentInParent<PlantCtrl>();
    }
    protected virtual void LoadCollider()
    {
        if (this.rangeCollider != null) return;
        this.rangeCollider = GetComponent<CapsuleCollider2D>();
        this.rangeCollider.isTrigger = true;
        this.rangeCollider.offset = new Vector2(this.planCtrl.PlantSO.rangeAttack,0);
        this.rangeCollider.size = new Vector2(1.27f, 0.68f);
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyDamageReceive>() == null) return;        
        EnemyDamageReceive damageReceive = collider.GetComponent<EnemyDamageReceive>();
        this.PlayMusic();
        damageReceive.TakeDamage(this.planCtrl.PlantSO.damage);
    }       
    protected virtual void PlayMusic()
    {
        SoundSO soundSO = this.GetSoundByName();
        if (soundSO == null)
        {
            Debug.LogError("Không tìm thấy SoundSO với SoundName.SoundSwingWord trong PlantSO!");
            return;
        }
        SoundCtrl soundCtrl = soundSO.objSound.GetComponent<SoundCtrl>();
        this.planCtrl.SoundSpawner.Spawn(soundCtrl,transform.position,Quaternion.identity);
    }
    protected virtual SoundSO GetSoundByName()
    {
        return this.planCtrl.PlantSO.GetSoundSO(SoundName.SoundSwingWord);
    }
}
