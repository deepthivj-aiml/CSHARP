/*
using System;
using System.Threading;

namespace ObserverPattern
{
    public enum OrderState
    {
        CRETAED, CONFIRMED, CANCELLED, CLOSED
    }

    public class Order
    {
        public event Action<string> OrderStateChanged;//event
        public event Action<string> OrderClosed;
        string orderId;
        OrderState currentState;
        public Order()
        {
            orderId = Guid.NewGuid().ToString();
            currentState = OrderState.CRETAED;
        }
        public void ChangeState(OrderState newState)
        {
            this.currentState = newState;

            NotifyAll();
        }
        void NotifyAll()
        {

            if (OrderStateChanged != null && this.currentState != OrderState.CLOSED)
            {

                Delegate[] invocationArray = this.OrderStateChanged.GetInvocationList();
                foreach (Action<string> method in invocationArray)
                {
                    new Thread(new ParameterizedThreadStart((object obj) => { method.Invoke(obj.ToString()); })).Start(this.orderId);
                }
            }
            else if (OrderClosed != null)
            {
                OrderClosed.Invoke(orderId);
            }
        }





        public class AuditSystem
        {
            public void SendAudit(string eventData)
            {
                Console.WriteLine($"Order closed {eventData}");

            }
        }
        public class EmailNotifificationSystem
        {
            public void SendMail(string evtData) { Console.WriteLine($"Email Sent  {evtData}"); }
        }
        public class SMSNotificationSystem
        {
            public void SendSMS(string evtData)
            {
                Console.WriteLine($"SMS Sent  {evtData}");
            }
        }
        public class WhatsAppNotificationSystem
        {
            public void SendWhatsApp(string eventData)
            {
                Console.WriteLine($"Whatsapp sent {eventData}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                EmailNotifificationSystem _emailSystem = new EmailNotifificationSystem();
                SMSNotificationSystem _smsSystem = new SMSNotificationSystem();
                WhatsAppNotificationSystem _whatsappSystem = new WhatsAppNotificationSystem();
                AuditSystem _auditSystem = new AuditSystem();

                Action<string> _emailObserver = new Action<string>(_emailSystem.SendMail);
                Action<string> _smsObserver = new Action<string>(_smsSystem.SendSMS);
                Action<string> _whatsappObserver = new Action<string>(_whatsappSystem.SendWhatsApp);
                Action<string> _closedObserver = new Action<string>(_auditSystem.SendAudit);

                Order _order1 = new Order();
                _order1.OrderStateChanged += _emailObserver;
                _order1.OrderStateChanged += _smsObserver;
                _order1.OrderStateChanged += _whatsappObserver;
                _order1.OrderClosed += _closedObserver;

                _order1.ChangeState(OrderState.CONFIRMED);
                System.Threading.Tasks.Task.Delay(1000).Wait();
                _order1.ChangeState(OrderState.CANCELLED);
                System.Threading.Tasks.Task.Delay(3000).Wait();
                _order1.ChangeState(OrderState.CONFIRMED);
                System.Threading.Tasks.Task.Delay(5000).Wait();
                _order1.ChangeState(OrderState.CLOSED);
            }
        }
    }
}*/