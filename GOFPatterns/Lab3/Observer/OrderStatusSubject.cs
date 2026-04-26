using System.Collections.Generic;

namespace Lab2.Observer
{
    public class OrderStatusSubject : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public string OrderId { get; }
        public string Status { get; private set; }

        public OrderStatusSubject(string orderId)
        {
            OrderId = orderId;
            Status = "New";
        }

        public void Attach(IObserver observer)
        {
            if (observer == null || _observers.Contains(observer))
            {
                return;
            }

            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            if (observer == null)
            {
                return;
            }

            _observers.Remove(observer);
        }

        public void SetStatus(string status)
        {
            Status = status;
            Notify();
        }

        public void Notify()
        {
            var message = $"Order {OrderId} status: {Status}";
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
    }
}
