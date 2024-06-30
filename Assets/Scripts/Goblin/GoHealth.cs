using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHealth : MonoBehaviour
{
    public int maxHealth = 50; // ������ �ִ� ü��
    private int currentHealth; // ���� ü��

    void Start()
    {
        currentHealth = maxHealth; // ������ �� �ִ� ü������ ����
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // ��������ŭ ü�� ����
        Debug.Log("���Ͱ� " + amount + "�� �������� �޾ҽ��ϴ�. ���� ü��: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ���ϸ� ��� ó��
        }
    }

    void Die()
    {
        Debug.Log("���Ͱ� ����߽��ϴ�.");
        // ��� ó�� ���� �߰� (��: ��� �ִϸ��̼� ���, ���� ������Ʈ ���� ��)
        Destroy(gameObject); // ���÷� ���� ������Ʈ�� �����ϴ� �ڵ�
    }
}