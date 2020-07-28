using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

public class MyBaseController : Controller
{
    protected override void Initialize(RequestContext requestContext)
    {
        base.Initialize(requestContext);
        

        if (Session["Autentificado"] != null)
        {
            if (String.Equals(Session["Autentificado"], "Yes"))
            {
                //Usuario autentificado, actualizar último Acceso. 
                Session["UltimoAcceso"] = DateTime.Now;
                //Literal1.Text = "Last Online: " + ((DateTime)Session["LoginTime"]).ToString("yyyy-MM-dd");
            }
            else
            {
                //Usuario Invalido
                Response.Redirect("/login?error=Session_Expirada");
            }
        }
        else
        {
            //Session Expirada
            Response.Redirect("/login?error=Session_Expirada");

        }
        
    }
}