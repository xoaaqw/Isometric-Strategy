using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponAnimator : MonoBehaviour
{
    public static string BaseLayer = "BaseLayer.";

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public int extraSortingOrder;

    public void Play(string movementName, int sortingOrder)
    {
        spriteRenderer.sortingOrder = sortingOrder + extraSortingOrder;
        animator.Play(BaseLayer + movementName);
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float t = stateInfo.length;
        Destroy(gameObject, t);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
