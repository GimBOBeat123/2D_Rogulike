using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // 캐릭터를 따라다니게 할 타겟 (캐릭터)
    public float speed = 3f; // 몬스터의 이동 속도
    public float attackRange = 1.5f; // 공격 범위
    public float stopChaseDistance = 10f; // 추격을 멈출 거리

    private Animator animator;
    private Vector3 direction;
   // private Health targetHealth; // 캐릭터의 Health 컴포넌트
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
       // targetHealth = target.GetComponent<Health>(); // 캐릭터의 Health 컴포넌트 가져오기
    }

    void Update()
    {
        // 몬스터가 타겟을 향해 이동하도록 방향을 설정
        direction = (target.position - transform.position).normalized;

        // 방향에 따라 몬스터의 스케일을 조정하여 좌우 방향을 바꿔줌
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 좌측 방향
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 우측 방향
        }

        // 타겟과의 거리 계산
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // 추격 거리를 넘어서면 정지 상태로 전환
        if (distanceToTarget > stopChaseDistance)
        {
            StopMoving();
            return;
        }

        // 타겟이 일정 범위 안에 있고 몬스터가 공격 중이지 않으면 공격 모션 재생
        if (distanceToTarget <= attackRange && !isAttacking)
        {
            isAttacking = true;
            animator.SetBool("Attack1", true); // Attack1 파라미터를 true로 설정하여 공격 애니메이션 재생
        }
        // 타겟이 일정 범위 밖에 있으면 이동 모션 재생
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

        // 공격 중인데 타겟과의 거리가 멀어지면 공격 취소
        if (isAttacking && distanceToTarget > attackRange)
        {
            CancelAttack();
        }
    }

    void Move()
    {
        animator.SetFloat("Speed", 1); // Run 애니메이션 재생
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void StopMoving()
    {
        animator.SetFloat("Speed", 0); // 정지 상태일 때 애니메이션 정지
    }

    void CancelAttack()
    {
        animator.SetBool("Attack1", false); // Attack1 파라미터를 false로 설정하여 공격 애니메이션 취소
    }

    // Attack 메서드는 더 이상 필요하지 않음

}
