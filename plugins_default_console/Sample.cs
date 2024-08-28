using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using plugins_default_connection;



namespace plugins_default_console
{
    public class Functions
    {
        private Dataverse Dataverse { get; }

        public Functions(Dataverse dataverse)
        {
            this.Dataverse = dataverse;
        }

        //public Guid CreateSample()
        //{
        //    var sample = new Entity("yp_sample");
        //    sample["yp_st_string"] = "Texto";
        //    sample["yp_pl_optionset"] = new OptionSetValue(1);
        //    sample["yp_mpl_optionset"] = new OptionSetValueCollection() {
        //        new OptionSetValue(1),
        //        new OptionSetValue(3)
        //    };
        //    sample["yp_bo_twooptions"] = false;
        //    sample["yp_int_integer"] = 100;
        //    sample["yp_fl_float_number"] = 100.1d;
        //    sample["yp_dc_decimal"] = 100.2m;
        //    sample["yp_mn_money"] = new Money(100.3m);
        //    sample["yp_dt_datetime"] = DateTime.Now;
        //    sample["yp_lp_contactid"] = new EntityReference("contact", new Guid("9ec9b848-6120-ef11-840a-002248e00ac0"));
        //    sample["yp_lp_customerid"] = new EntityReference("account", new Guid("dcf3921c-6120-ef11-840a-002248e00ac0"));
        //    sample.Id = this.Dataverse.ServiceClient.Create(sample);
        //    return sample.Id;
        //}

        //public void UpdateWithIdSample(Guid id)
        //{
        //    var sample = new Entity("yp_sample", id);
        //    sample["yp_st_string"] = $"{DateTime.Now.ToShortDateString()}";
        //    sample["yp_pl_optionset"] = new OptionSetValue(2);
        //    this.Dataverse.ServiceClient.Update(sample);
        //}

    }
}
