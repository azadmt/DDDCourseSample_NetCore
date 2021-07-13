using Castle.DynamicProxy;
using PostSharp.Aspects;
using PostSharp.Serialization;
using PostsharpSample;
using System;
using System.Linq;
//[assembly: LogMethod(AttributePriority = 0)]
namespace PostsharpSample
{

    public interface INotificationService
    {
        public void SendNotification(string message);
    }
    public class NotificationService : INotificationService
    {
        [LogMethod]
        public  void SendNotification(string message)
        {
            //Send Notification
        }
    }


    [PSerializable]
    [LinesOfCodeAvoided(6)]
    public sealed class LogMethodAttribute : OnMethodBoundaryAspect
    {
        /// <summary>
        ///   Method invoked before the target method is executed.
        /// </summary>
        /// <param name="args">Method execution context.</param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("PostSharp --- Calling method {0} with parameters:{1}... ",
                 args.Method.Name,
                 string.Join(", ", args.Arguments.Select(a => (a ?? "").ToString()).ToArray()));


            
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("PostSharp --- Done: result was {0}.", args.Method.Name);
        }
    }
}
