using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingCSharp
{
    public class BasicThreading
    {
        static void ExtractExecutingThread()
        {
            // Get the thread currently  
            // executing this method.  
            Thread currThread = Thread.CurrentThread;
        }

        static void ExtractAppDomainHostingThread()
        {
            // Obtain the AppDomain hosting the current thread.
            AppDomain ad = Thread.GetDomain();
        }

        static void ExtractCurrentThreadContext()
        {
            // Obtain the context under which the
            // current thread is operating.
            Context ctx = Thread.CurrentContext;
        }
    }
}
