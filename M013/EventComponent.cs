namespace M013;

public class EventComponent
{
	public event Action ProcessCompleted;
	public event Action<int> ValueChanged;

	public void StartProcess()
	{
		for(int i = 0; i < 100; i++)
		{
			ValueChanged(i);
		}
		ProcessCompleted();
	}
}
