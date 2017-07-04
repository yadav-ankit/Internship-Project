using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
namespace QuickSend
{
    public class MyClass
    {
        public string split_transaction_get_click( string dev_key = "becbbce45f79c6f5109f848acd540567", string initiator_id = "7349872347",string channel = "2", string amount = "11000",
             string customer_id = "9901473431",string recipient_id = "10007702")
        {

            //string dev_key = "becbbce45f79c6f5109f848acd540567";
            //string initiator_id = "7349872347";
            //string channel = "2";
            //string amount = "11000";
            //string customer_id = "9901473431";

            //string recipient_id = "10007702";


            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions/split";

            url = url + "?initiator_id=" + initiator_id + "&customer_id=" + customer_id + "&recipient_id=" + recipient_id + "&amount=" + amount + "&channel=" + channel;


            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            IRestResponse response = client.Execute(request);
            var content = response.Content; /// Contains response from the server


            return content.ToString();
        }


        public string split_transaction_post_click( string dev_key = "becbbce45f79c6f5109f848acd540567", string initiator_id = "7349872347",string channel = "2", string amount = "20000",
            string customer_id = "9901473431", string split_transaction_id = "12476515", string currency = "INR",string client_ref_id = "10042017040716643571",string recipient_id = "10007702",
           string hold_timeout = "100",string state = "1", string timestamp = "2017-07-10T04:04:16")
        {

           // string dev_key = "becbbce45f79c6f5109f848acd540567";
            //string initiator_id = "7349872347";
            // string channel = "2";
           // string amount = "20000";
            //string customer_id = "9901473431";

            //string split_transaction_id = "12476515";

            //string currency = "INR";
            //string client_ref_id = "10042017040716643571";
            //string recipient_id = "10007702";

            //string hold_timeout = "100";
            //string state = "1";

            //string timestamp = "2017-07-10T04:04:16";


            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions";

            string body = "initiator_id=" + initiator_id + "&customer_id=" + customer_id + "&recipient_id=" + recipient_id + "&amount=" + amount
                             + "&state=" + state + "&channel=" + channel + "&timestamp=" + timestamp + "&currency=" + currency + "&hold_timeout=" + hold_timeout +
                            "&client_ref_id=" + client_ref_id + "&split_tid=" + split_transaction_id;



            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content; /// Contains response from the server

            return content.ToString();
        }

        public string batch_transaction_click(string dev_key = "becbbce45f79c6f5109f848acd540567",string initiator_id = "7349872347",string batch_id = "1351")
        {

           // string dev_key = "becbbce45f79c6f5109f848acd540567";

            //string initiator_id = "7349872347";


            // string batch_id = "1351";

            string url = "https://staging.eko.co.in:25004/ekoapi/v1/tansactions/batch/";


            url = url + batch_id + "?initiator_id=" + initiator_id;

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            IRestResponse response = client.Execute(request);
            var content = response.Content; /// Contains response from the server


           return content.ToString();

        }
    }
}



