using Player.Ability;
using SoundSystem;
using UnityEngine;
using Zenject;
public class DashAbility : BaseAbility
{
    protected override string _name { get; set; } = "Dash";
    protected override Sprite _sprite { get; set; } = Resources.Load<Sprite>("Sprites/Characters/koraga");
    protected override float _cooldown { get; set; } = 1;
    protected override int _levelToUnlock { get; set; } = 2;
    protected override IInputable _inputable { get; set; } = new Inputable();

    private Vector3 directioToForcePlayer = Vector3.zero;
    private const float _DashForce = 250f;
    private const float _UpForce = 0.5f;

    private ISoundManager _soundManager = null;

    [Inject]
    public void Construct(ISoundManager soundManager)
    {
        _soundManager = soundManager;
    }

    public override void Update(Ray ray)
    {
        base.Update(ray);
        directioToForcePlayer = ray.direction;
    }

    protected override void DoAction()
    {
        base.DoAction();
        Vector3 ForceDirection = new Vector3(directioToForcePlayer.x, _UpForce, directioToForcePlayer.z);
        _player.GetComponent<Rigidbody>().AddForce(ForceDirection * _DashForce, ForceMode.Force);
    }
}
