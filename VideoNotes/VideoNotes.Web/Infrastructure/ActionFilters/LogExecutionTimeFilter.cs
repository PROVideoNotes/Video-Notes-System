namespace VideoNotes.Web.Infrastructure.ActionFilters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Diagnostics;
    using System.IO;

    public class LogExecutionTimeFilter : ActionFilterAttribute
    {
        private Stopwatch timer;

        public LogExecutionTimeFilter()
        {
            timer = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer.Reset();
            timer.Start();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
           var timeElapsed = timer.ElapsedMilliseconds;
           
            FileStream fappend = File.Open(@"A:\GoranTelerik\ASP_NET\Diplomska\Log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fappend);
           sw.WriteLine(timeElapsed);
           sw.Close();
        }
    }
}