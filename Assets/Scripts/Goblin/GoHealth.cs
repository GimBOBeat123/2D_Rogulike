using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHealth : MonoBehaviour
{
    public int maxHealth = 50; // 몬스터의 최대 체력
    private int currentHealth; // 현재 체력

    void Start()
    {
        currentHealth = maxHealth; // 시작할 때 최대 체력으로 설정
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // 데미지만큼 체력 감소
        Debug.Log("몬스터가 " + amount + "의 데미지를 받았습니다. 현재 체력: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하면 사망 처리
        }
    }

    void Die()
    {
        Debug.Log("몬스터가 사망했습니다.");
        // 사망 처리 로직 추가 (예: 사망 애니메이션 재생, 게임 오브젝트 제거 등)
        Destroy(gameObject); // 예시로 게임 오브젝트를 제거하는 코드
    }
}