using Domain.Core.Events;
using System.Threading.Tasks;

namespace Domain.Core.Bus
{
	public interface IEventHandler { }

	public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
	{
		Task Handle(TEvent @event);
	}
}
