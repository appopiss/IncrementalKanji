/// <summary>
/// 普通にInstantiateしてもIdleActionは呼ばれないため、
/// UsefulMethod.InstantiateIdleをする必要がある。
/// もしくは、main.idleActionCtrl.Addに渡していい。
/// </summary>
public interface IIdleAction
{
    void IdleAction();
}
