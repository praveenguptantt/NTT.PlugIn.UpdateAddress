using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace NTT.PlugIn.UpdateAddress
{
    public class Update : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            //Extract the tracing service for use in debugging sandboxed plug-ins.
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));
            // Get a reference to the Organization service.
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));


            IOrganizationServiceFactory servicefactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService client = servicefactory.CreateOrganizationService(context.UserId);

            try
            {
                if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                {
                    // Obtain the target entity from the input parameters.
                    Entity targetEntity = (Entity)context.InputParameters["Target"];

                    if (targetEntity.LogicalName != "acca_devops")
                        return;

                    
                }
            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                tracingService.Trace(string.Format(CultureInfo.InvariantCulture, "Exception: {0}", e.ToString()));
                tracingService.Trace(string.Format(CultureInfo.InvariantCulture, "Stack Trace: {0}", e.StackTrace));
                throw;
            }
            catch (Exception e)
            {
                tracingService.Trace(string.Format(CultureInfo.InvariantCulture, "Exception: {0}", e.ToString()));
                tracingService.Trace(string.Format(CultureInfo.InvariantCulture, "Stack Trace: {0}", e.StackTrace));
                throw;
            }
        }
    }
}
