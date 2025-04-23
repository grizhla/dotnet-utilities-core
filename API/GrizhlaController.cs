using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grizhla.UtilitiesCore.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Grizhla.UtilitiesCore.API;

[ApiController]
[BeforeAction]
public class GrizhlaController : ControllerBase
{
    public ActionResult ByProcessResult<T>(
        GrizhlaResult<T> processResult,
        object? responseData = null
    )
    {
        if (processResult.Success && responseData != null)
            return Ok(responseData);
        else if (processResult.Success && responseData == null)
            return Ok(processResult);

        return StatusCode((int)processResult.StatusCode, processResult.Message);
    }
}

public class BeforeActionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        //
    }
}
