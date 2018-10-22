using System;
using System.Text;

namespace RabbitBAU.Core
{
    public static class ExceptionExtensions
    {
        public static string CreateExceptionString(this Exception exception)
        {
            StringBuilder sb = new StringBuilder();

            CreateExceptionString(exception, sb, string.Empty);

            return sb.ToString();
        }

        private static void CreateExceptionString(Exception exception, StringBuilder sb, string indent = "")
        {
            if (indent.Length > 0)
            {
                sb.AppendFormat("{0}Inner", indent);
            }

            sb.AppendFormat("Exception Found:\n{0}Type:{1}", indent, exception.GetType().FullName);

            sb.AppendFormat("\n{0}Message: {1}", indent, exception.Message);

            sb.AppendFormat("\n{0}Source: {1}", indent, exception.Source);

            sb.AppendFormat("\n{0}StackTrace:{0}", indent, exception.StackTrace);

            if (exception.InnerException != null)
            {
                sb.AppendLine();

                CreateExceptionString(exception.InnerException, sb, string.Concat(indent, "    "));
            }
        }
    }
}
