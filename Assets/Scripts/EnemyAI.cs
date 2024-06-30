using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // ĳ���͸� ����ٴϰ� �� Ÿ�� (ĳ����)
    public float speed = 3f; // ������ �̵� �ӵ�
    public float attackRange = 1.5f; // ���� ����
    public float stopChaseDistance = 10f; // �߰��� ���� �Ÿ�

    private Animator animator;
    private Vector3 direction;
   // private Health targetHealth; // ĳ������ Health ������Ʈ
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
       // targetHealth = target.GetComponent<Health>(); // ĳ������ Health ������Ʈ ��������
    }

    void Update()
    {
        // ���Ͱ� Ÿ���� ���� �̵��ϵ��� ������ ����
        direction = (target.position - transform.position).normalized;

        // ���⿡ ���� ������ �������� �����Ͽ� �¿� ������ �ٲ���
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // ���� ����
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // ���� ����
        }

        // Ÿ�ٰ��� �Ÿ� ���
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // �߰� �Ÿ��� �Ѿ�� ���� ���·� ��ȯ
        if (distanceToTarget > stopChaseDistance)
        {
            StopMoving();
            return;
        }

        // Ÿ���� ���� ���� �ȿ� �ְ� ���Ͱ� ���� ������ ������ ���� ��� ���
        if (distanceToTarget <= attackRange && !isAttacking)
        {
            isAttacking = true;
            animator.SetBool("Attack1", true); // Attack1 �Ķ���͸� true�� �����Ͽ� ���� �ִϸ��̼� ���
        }
        // Ÿ���� ���� ���� �ۿ� ������ �̵� ��� ���
        else if (distanceToTarget > attackRange && direction.magnitude > 0.1f)
        {
            isAttacking = false;
            Move();
        }
        else
        {
            isAttacking = false;
            StopMoving();
        }

        // ���� ���ε� Ÿ�ٰ��� �Ÿ��� �־����� ���� ���
        if (isAttacking && distanceToTarget > attackRange)
        {
            CancelAttack();
        }
    }

    void Move()
    {
        animator.SetFloat("Speed", 1); // Run �ִϸ��̼� ���
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void StopMoving()
    {
        animator.SetFloat("Speed", 0); // ���� ������ �� �ִϸ��̼� ����
    }

    void CancelAttack()
    {
        animator.SetBool("Attack1", false); // Attack1 �Ķ���͸� false�� �����Ͽ� ���� �ִϸ��̼� ���
    }

    // Attack �޼���� �� �̻� �ʿ����� ����

}
