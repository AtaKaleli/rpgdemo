using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : BaseProjectile
{

    private WeaponSO weapon;

    [Header("Laser growth information")]
    [SerializeField] private float laserGrowTime = 1f;
    private CapsuleCollider2D capsuleCollider;
    private float ccStartSizeX;
    private float ccStartOffsetX;

    [Header("Laser Fade Out Information")]
    [SerializeField] private float fadeOutTime = 1.0f;

    protected override void Awake()
    {
        base.Awake();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        weapon = ActiveWeapon.instace.CurrentActiveWeapon.GetComponent<IWeapon>().GetWeapon();

        ccStartSizeX = capsuleCollider.size.x;
        ccStartOffsetX = capsuleCollider.offset.x;
    }

    protected override void Start()
    {
        base.Start();
        startPos = ActiveWeapon.instace.transform;

        projectileRange = weapon.weaponRange;
        UpdateProjectileRange(projectileRange);

        StartCoroutine(IncreaseLaserLengthCoroutine());
    }
    
    private IEnumerator IncreaseLaserLengthCoroutine()
    {
        GameManager.instance.CurrentState = GameManager.GameState.Freezed;
        float elapsedTime = 0f;

        while(sr.size.x < projectileRange)
        {
            elapsedTime += Time.deltaTime;

            sr.size = new Vector2(Mathf.Lerp(1f, projectileRange, elapsedTime / laserGrowTime), 1f);
            capsuleCollider.size = new Vector2(Mathf.Lerp(ccStartSizeX, projectileRange, elapsedTime / laserGrowTime), capsuleCollider.size.y);
            capsuleCollider.offset = new Vector2(Mathf.Lerp(ccStartOffsetX, projectileRange/2.0f, elapsedTime / laserGrowTime), 0f);
            yield return null;
        }

        StartCoroutine(FadeOutLaserCoroutine());

    }

    private IEnumerator FadeOutLaserCoroutine()
    {
        capsuleCollider.enabled = false;
        GameManager.instance.CurrentState = GameManager.GameState.Playing;
        float elapsedTime = 0f;

        while(elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1, 0, elapsedTime / fadeOutTime);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }

        Destroy(this.gameObject);
    }

    
}
