namespace BookCatalog.Common.Util.Services;

public interface INotificationHandler<T> where T : class
{
    Task Handle(T notification);

    IList<Notification> GetNotifications();
}