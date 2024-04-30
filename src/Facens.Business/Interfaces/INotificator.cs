using Facens.Business.Notifications;

namespace Facens.Business.Interfaces
{
    public interface INotificator
    {
        bool IsNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notificacao);
    }
}
