

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

namespace IndoNepal
{
    class MyClass
    {


        public string GetCustomer_Click( string init_id = "9910028267",string mobile_num = "7010101019", string dev_key = "becbbce45f79c6f5109f848acd540567")
        {
            // https://staging.eko.co.in:25004/ekoapi/v1/customers/mobile_number:7010101019/product:indonepal ?
            // initiator_id=9910028267 -H 'developer_key:becbbce45f79c6f5109f848acd540567'


            //initialize variables

            //merchant's unique reference (should be configurable)
            //string init_id = "9910028267";

            //merchant's unique phone number (should be configurable)
           // string mobile_num = "7010101019";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";




            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num + "/product:indonepal?initiator_id=" + init_id;


            //client calling GET method using url
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);


            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;

        }

        public string CreateCustomer_Click(string init_id = "9910028267",string company_name = "EKO",string address_line1 = "plot no 34 sector-44,gurgaon",
            string nationality = "Indian",string customer_photo = "indian_ero_male_1.jpg",string income_source = "1",string remittance_reason = "1",
             string id_proof_tpe_id = "3",string id_proof = "SVE1245555",string pincode = "",string gender = "49", string dob = "10121992",string dev_key = "becbbce45f79c6f5109f848acd540567",
            string name = "TestingAvish")
        {
       
            //merchant's unique reference (should be configurable)
           // string init_id = "9910028267";

           // string company_name = "EKO";
           // string address_line1 = "plot no 34 sector-44,gurgaon";

            //string nationality = "Indian";

            //string customer_photo = "indian_ero_male_1.jpg";


           // string income_source = "1";
            //string remittance_reason = "1";

            //string id_proof_tpe_id = "3";
            //string id_proof = "SVE1245555";

           // string pincode = "";
            //merchant's unique phone number (should be configurable)

            string mobile_num = init_id;


           // string gender = "49";

            //string dob = "10121992";


            // your API access key (should be configurable)
           // string dev_key = "becbbce45f79c6f5109f848acd540567";



            // a sample name for testing purpose
            



            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num;


            String body = "name=" + name + "&initiator_id=" + init_id + "mobile_number:" + mobile_num + "&id_proof_type_id=" + id_proof_tpe_id + "&id_proof=" + id_proof +
                "&gender=" + gender + "&dob=" + dob + "&company_name=" + company_name + "&address_line1=" + address_line1 + "&income_source=" + income_source + "&remittance_reason=" + remittance_reason +

                "&nationality=" + nationality + "&customer_photo=" + customer_photo + "pincode=" + pincode;

            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;


            // Display response in a web form
            String reply = content.ToString();

            return reply;
        }

        public string ResendCustomer_Click(string init_id = "9910028267", string dev_key = "becbbce45f79c6f5109f848acd540567")
        {


            // curl -i -X POST  -d "initiator_id=mobile_number:9910028267"   
            // https://staging.eko.co.in:25004/ekoapi/v1/customers/mobile_number:7010101969/product:indonepal /otp  -H             
            //'developer_key:becbbce45f79c6f5109f848acd540567' 


            //merchant's unique reference (should be configurable)
            //string init_id = "9910028267";

            //merchant's unique phone number (should be configurable)
            string mobile_num = init_id;

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";



            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";


            string body = "initiator_id=mobile_number:" + init_id;

            url = url + "mobile_number:" + mobile_num + "/product:indonepal/otp";

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;
        }

        public string VerfifyCustomer_Click(string init_id = "9910028267", string dev_key = "becbbce45f79c6f5109f848acd540567",string id = "7010101969",
            string id_type = "mobile_number", string otp_req = "361")
        {
            // curl -i -X POST  -d "initiator_id=9910028267&id_type=mobile_number&id=7010101969"
            // https://staging.eko.co.in:25004/ekoapi/v1/customers/product:indonepal/verification/otp:361  -H 'developer_key:becbbce45f79c6f5109f848acd540567'


            //merchant's unique reference (should be configurable)
           // string init_id = "9910028267";

            //customer's unique reference (should be configurable)
            //string id = "7010101969";

            // your API access key (should be configurable)
           // string dev_key = "becbbce45f79c6f5109f848acd540567";

           // string id_type = "mobile_number";

            // sample otp
           // string otp_req = "361";



            // Base url for verifying customers
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/product:indonepal/verification/otp:";

            string body = "&initiator_id=" + init_id + "&id_type=" + id_type + "&id=" + id;

            url = url + otp_req;

            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;
        }

        public string ForCashPayout_Click(string recipient_mobile = "9811458963",string init_id = "9910028267", string mobile_number = "7010101019",  string recipient_name = "irfan ansari",
            string gender = "49",string dev_key = "becbbce45f79c6f5109f848acd540567",string district = "2",string address = "SouthCityGurugram",
            string relationship_with_sender = "7")
        {
           // string recipient_mobile = "9811458963";

            //merchant's unique reference (should be configurable)
            //string init_id = "9910028267";

            //string mobile_number = "7010101019";

            //string recipient_name = "irfan ansari";

            //string gender = "49";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";

            //string district = "2";

            //string address = "SouthCityGurugram";
            // string relationship_with_sender = "7";

            // Base url for verifying customers
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_number + "/product:indonepal/recipients/mobile_number:" + recipient_mobile;

            string body = "&initiator_id=" + init_id + "&recipient_name=" + recipient_name + "&gender=" + gender + "&address_lin1=" + address +
               "&relationship_with_sender=" + relationship_with_sender + "&district=" + district + "&recipient_mobile=" + recipient_mobile;


            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return  reply;


        }

        public string Acc_Deposit_Click( string recipient_mobile = "6010101010", string init_id = "9910028267",string gender = "49", string mobile_number = "7010101019",
            string recipient_name = "irfan ansari", string acc_indonepalbranch = "3216547891234567_11",string dev_key = "becbbce45f79c6f5109f848acd540567",
            string district = "2",string address = "SouthCity Gurugram",string relationship_with_sender = "7")
        {


           // string recipient_mobile = "6010101010";
            //merchant's unique reference (should be configurable)
            //string init_id = "9910028267";

            //string gender = "49";

            // string mobile_number = "7010101019";

           //  string recipient_name = "irfan ansari";

           //  string acc_indonepalbranch = "3216547891234567_11";

            // your API access key (should be configurable)
            // string dev_key = "becbbce45f79c6f5109f848acd540567";

           //  string district = "2";

           // string address = "SouthCity Gurugram";
            // string relationship_with_sender = "7";

            // Base url for verifying customers
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_number + "/product:indonepal /recipients/acc_indonepalbranch:" + acc_indonepalbranch;



            string body = "&initiator_id=" + init_id + "&recipient_name=" + recipient_name + "&gender=" + gender + "&address_lin1=" + address +
                "&relationship_with_sender=" + relationship_with_sender + "&district=" + district + "&recipient_mobile=" + recipient_mobile;

            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;


        }

        public string Get_All_Recipients_Click(string init_id = "9910028267",string mobile_num = "7010101019",string dev_key = "becbbce45f79c6f5109f848acd540567")
        {

            //merchant's unique reference (should be configurable)
           // string init_id = "9910028267";

            //merchant's unique phone number (should be configurable)
           // string mobile_num = "7010101019";

            // your API access key (should be configurable)
           // string dev_key = "becbbce45f79c6f5109f848acd540567";




            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num + "/product:indonepal/recipients?initiator_id=" + init_id;


            //client calling GET method using url
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);


            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;

        }

        public string Transaction_Click(string initiator_id = "9910028267",string recipient_id = "1132",string amount = "200", string client_ref_id = "EKO20170424171929",
            string timestamp = "1990-01-01T01:01:01Z",string hold_timeout = "100",string currency = "INR", string state = "1",string customer_id = "70101010 19",string product = "in donepal",
            string dev_key = "becbbce45f79c6f5109f848acd540567")
        {

            //string initiator_id = "9910028267";

           // string recipient_id = "1132";

            // string amount = "200";

            // string client_ref_id = "EKO20170424171929";

            // string timestamp = "1990-01-01T01:01:01Z";

             //string hold_timeout = "100";

             // string currency = "INR";

           // string state = "1";

            // string customer_id = "70101010 19";

            //string product = "in donepal";


            // your API access key (should be configurable)
            // string dev_key = "becbbce45f79c6f5109f848acd540567";



            // Base url for verifying customers
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions";



            string body = "recipient_id=" + recipient_id + "&amount=" + amount + "&timestamp=" + timestamp +
                "&currency=" + currency + "&customer_id=" + customer_id + "&initiator_id=" + initiator_id +
                "&client_ref_id=" + client_ref_id + "&hold_timeout=" + hold_timeout + "&state=" + state + "&product=" + product;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

           return reply;

        }
            
        public string Refund_Click(string initiator_id = "9910028267",string refrence_number = "12502903",string client_ref_id = "EKO20170424173528",string otp = "7954235762"
            ,string state = "1",string dev_key = "becbbce45f79c6f5109f848acd540567")
        {

           // string initiator_id = "9910028267";

           // string refrence_number = "12502903";

            // string client_ref_id = "EKO20170424173528";

           // string state = "1";

           //  string otp = "7954235762";


            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";

            // Base url for verifying customers
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions/";
            url = url + refrence_number + "/refund/otp";



            string body = "otp=" + otp + "&initiator_id=" + initiator_id + "&state=" + state + "&client_ref_id=" + client_ref_id;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

           return reply;


        }

        public string ResendOtp_Click(string init_id = "9910028267",string dev_key = "becbbce45f79c6f5109f848acd540567")
        {

            //merchant's unique reference (should be configurable)
            //string init_id = "9910028267";

            //merchant's unique phone number (should be configurable)
            // string mobile_num = init_id;

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";




            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions/12502903/refund/otp";


            string body = "initiator_id=mobile_number:" + init_id;


            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

           return reply;
        }

        public string TransactionEnquiry_Click(string dev_key = "becbbce45f79c6f5109f848acd540567")
        {
            
            // your API access key (should be configurable)
           // string dev_key = "becbbce45f79c6f5109f848acd540567";




            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions/12504364?initiator_id=9864165165";



            //client calling GET method using url
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);


            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;

        }

        public string Parteners_Unique_Refrence_Click(string initiator_id = "9864165165",string Unique_Refrence_id = "25042861493203800016", string dev_key = "becbbce45f79c6f5109f848acd540567")
        {
            // curl -i -X GET https://staging.eko.co.in:25004/ekoapi/v1/transactions/client_ref_id:25042861493203800016?initiator_id=9864165165 
            // -H 'developer_key:becbbce45f79c6f5109f848acd540567' 


            //initialize variables
            //string Unique_Refrence_id = "25042861493203800016";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";

            //string initiator_id = "9864165165";


            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions/";
            url = url + "client_ref_id:" + Unique_Refrence_id + "?initiator_id=" + initiator_id;



            //client calling GET method using url
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            /// Obtains response from the server
            IRestResponse response = client.Execute(request);


            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;

        }










    


    }
}
