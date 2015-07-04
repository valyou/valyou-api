namespace ValYou.Api
{
    using System;
    using System.Web;

    using Akka.Actor;
    using ServiceStack;
    using ServiceStack.MiniProfiler;

    /// <summary>
    /// The (global) application and session-level event handlers.
    /// </summary>
    /// <remarks>
    /// See:
    ///   * http://en.wikipedia.org/wiki/Global.asax
    ///   * http://msdn.microsoft.com/en-us/library/ms178473.aspx
    ///   * http://www.techrepublic.com/article/working-with-the-aspnet-globalasax-file/
    /// </remarks>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Akka actor system instance.
        /// </summary>
        public static ActorSystem ActorSystem;

        /// <summary>
        /// The application start event.
        /// Gets called the first time the application starts.
        /// </summary>
        /// <param name="sender">The event source / sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            // Apply ServiceStack license from file
            Licensing.RegisterLicenseFromFileIfExists(Server.MapPath("~/servicestack.license"));

            // Configure Akka actor system
            ActorSystem = ActorSystem.Create("valyou");

            // Starts ServiceStack host
            new AppHost().Init();
        }

        /// <summary>
        /// The session start event.
        /// Gets called when a new user visits the application / website (i.e. starts a session for the user).
        /// </summary>
        /// <param name="sender">The event source / sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The application request start event.
        /// Gets called every time a request is received.
        /// It's the first event fired for a request, which is often a page request (URL) that a user enters.
        /// </summary>
        /// <param name="sender">The event source / sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.IsLocal)
            {
                Profiler.Start();
            }
        }

        /// <summary>
        /// The application request authenticate start event.
        /// Gets called when the security module has established the current user's identity as valid.
        /// At this point, the user's credentials have been validated.
        /// </summary>
        /// <param name="sender">The event source / sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The application request end event.
        /// Gets called after an application request has been successfully processed.
        /// It's the last event fired for a request.
        /// </summary>
        /// <param name="sender">The event source / sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            Profiler.Stop();
        }

        /// <summary>
        /// The session end event.
        /// Gets called when a user's session terminates (e.g. time-out, session ends, or user leaves the application / website).
        /// </summary>
        /// <param name="sender">The event source / sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Session_End(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The application end event.
        /// Gets called when the last instance of an HttpApplication class is destroyed.
        /// It's fired only once during an application's lifetime.
        /// </summary>
        /// <param name="sender">The event source / sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Application_End(object sender, EventArgs e)
        {
            ActorSystem.Shutdown();
        }

        /// <summary>
        /// The application error event.
        /// Gets called when an unhandled exception is encountered within the application.
        /// </summary>
        /// <param name="sender">The event source / sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}