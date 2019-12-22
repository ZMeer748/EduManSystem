using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduManSystem.App_Code
{
    public class ToastrHelper
    {
        public static string GetToastrScript(string messageType, string tittle, string message)
        {
            return "$(document).Toasts('create', {"
                    + "class: 'bg-" + messageType + "', "
                    + "title: '" + tittle + "',"
                    + "position: 'topRight',"
                    + "subtitle: '',"
                    + "autohide: true,"
                    + "delay: 1250,"
                    + "body: '" + message + "',"
                    + "icon: 'fas fa-" + GetIcon(messageType) + " fa-lg'"
                    + "})";
        }

        private static string GetIcon(string messageType)
        {
            switch (messageType)
            {
                case "success":
                    return "check-circle";
                case "info":
                    return "info-circle";
                case "warning":
                    return "exclamation-circle";
                case "danger":
                    return "exclamation-triangle";
                case "maroon":
                    return "smile-wink";
                default:
                    return "info-circle";
            }
        }
    }
}