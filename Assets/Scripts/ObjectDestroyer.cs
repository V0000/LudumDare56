using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public int destroyCounter = 0;
    public Animator dogAnimator;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Проверяем, касается ли объект с тегом "Hero" или "Clone"
        if (collider.gameObject.CompareTag("Hero") || collider.gameObject.CompareTag("Clone"))
        {
            // Уничтожаем объект, который коснулся
            Destroy(collider.gameObject);
            destroyCounter++;
            PlayAnimation();
        }
    }
    
    public void PlayAnimation()
    {
        if (dogAnimator != null)
        {
            // Проигрываем анимацию по имени
            // dogAnimator.SetBool("MoveLeg", true);
            // dogAnimator.SetBool("MoveLeg", false);
            
            dogAnimator.Play("Leg");
        }
    }
}