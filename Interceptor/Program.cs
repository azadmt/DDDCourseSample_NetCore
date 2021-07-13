using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Linq;

namespace Interceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new ContainerBuilder();
           
            cb.RegisterType<NotificationService>()
                       .As<INotificationService>()
                       // .EnableClassInterceptors() //on virtual method
                         .EnableInterfaceInterceptors()
                        .InterceptedBy(typeof(MethodLoggerInterceptor));

            cb.RegisterType<MethodLoggerInterceptor>();
            var container = cb.Build();
           // var ns = container.Resolve<NotificationService>();
          var ns = container.Resolve<INotificationService>();
            ns.SendNotification("my message");

            Console.ReadKey();

        }
    }
    public interface INotificationService
    {
        public void SendNotification(string message);
    }
    public class NotificationService : INotificationService
    {
        public virtual void SendNotification(string message)
        {
            //Send Notification
        }
    }

    public class MethodLoggerInterceptor : IInterceptor
    {
        public MethodLoggerInterceptor()
        {

        }
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Calling method {0} with parameters:{1}... ",
              invocation.Method.Name,
              string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();

            Console.WriteLine("Done:  {0}.", invocation.Method.Name);
        }
    }
}
