﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RestSharp;

namespace EkoIndiaAPi
{
    public class AllApi
    {
        public String GetCustomer(string init_id = "9910028267",string mobile_num = "5669023498", string dev_key = "becbbce45f79c6f5109f848acd540567")
        {
            //initialize variables

            //merchant's unique reference (should be configurable)
            //string init_id = "9910028267";

            //merchant's unique phone number (should be configurable)
            //string mobile_num = "5669023498";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";




            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num + "?initiator_id=" + init_id;


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
            String reply  = content.ToString();

            return reply;

        }


        public String CreateAddCustomer(string init_id = "9910028267", string mobile_num = "9962817283", string dev_key = "becbbce45f79c6f5109f848acd540567",
            string name = "Testing", string cust_id_type = "mobile_number")
        {

            //merchant's unique reference (should be configurable)
          //  string init_id = "9910028267";


            //merchant's unique phone number (should be configurable)
            //string mobile_num = "9962817283";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";

            // default cust_id_type = mobile_number, also possibles types are Facebook_ID and Google_ID
            //string cust_id_type = "mobile_number";

            // a sample name for testing purpose
            //string name = "Testing";


            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num;


           String  body = "customer_id_type=" + cust_id_type + "&initiator_id=" + init_id + "&name=" + name;

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

        public String ResendOtp_click(string init_id = "9910028267",string mobile_num = "9962817283",string dev_key = "becbbce45f79c6f5109f848acd540567")
        {

            //merchant's unique reference (should be configurable)
            // string init_id = "9910028267";

             //merchant's unique phone number (should be configurable)
            // string mobile_num = "9962817283";

             // your API access key (should be configurable)
             //string dev_key = "becbbce45f79c6f5109f848acd540567";
            


            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";


            string body = "initiator_id=" + init_id;

             url = url + "mobile_number:" + mobile_num + "/otp";  

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

        public String Verify_Customer_Identity_click( string init_id = "9910028267", string cust_id = "9962817283",string dev_key = "becbbce45f79c6f5109f848acd540567",
            string cust_id_type = "mobile_number", string otp_req = "540")
        {

            //merchant's unique reference (should be configurable)
            //string init_id = "9910028267";

            //customer's unique reference (should be configurable)
            //string cust_id = "9962817283";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";
            
            //string cust_id_type = "mobile_number";
            
            // sample otp
           // string otp_req = "540";



            // Base url for verifying customers
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/verification/otp:";

            string body = "id=" + cust_id + "&id_type=" + cust_id_type + "&otp=" + otp_req + "&initiator_id=" + init_id;

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

        public String Get_Bank_Detail_click( string init_id = "9910028267",string mobile_num = "9910028267",string dev_key = "becbbce45f79c6f5109f848acd540567",
            string bankcode = "HDFC")
        {

            // initiate id reference (should be configurable)
            //string init_id = "9910028267";
            
            // mobile number same as initiater id
            //string mobile_num = "9910028267";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";
            

           // your bank name
            //string bankcode = "HDFC";

            mobile_num = init_id;


            // Base url for get banking details
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/banks?";
            url = url + "bank_code=" + bankcode + "&initiator_id=mobile_number:" + init_id;

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

        public String Account_Name_click(string init_id = "9910028267", string cust_id = "9962817283",string dev_key = "becbbce45f79c6f5109f848acd540567",
             string ifsc = "sbin0000001", string account_num = "61046336411")
        {

            // initiate id reference (should be configurable)
           // string init_id = "9910028267";

            // customer id reference (should be configurable)
            //string cust_id = "9962817283";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";

            // your ifsc code if required
            //string ifsc = "sbin0000001";

            // your bank account number
            //string account_num = "61046336411";
           


            
            //base url for getting account name info
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/banks/​";
            string body = "id=" + cust_id  +"&initiator_id=" + init_id;

            url = url + "ifsc:" + ifsc + "/accounts/" + account_num;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content; 

            // Display response in a web form
            String reply = content.ToString();

            return reply;
        }

        public String Add_Reipient_click(string init_id = "9910028267",string recipient_mobile = "8987896897",string dev_key = "becbbce45f79c6f5109f848acd540567",
             string recipient_name = "Testing",string ifsc = "sbin0000001", string acc_num = "61046336411", string cust_id_type = "mobile_number",
            string recipent_type = "1", string recipient_id_type = "3")
        {

            // initiate id reference (should be configurable)
            //string init_id = "9910028267";
            
            // mobile numbe rof the recipient to add
            //string recipient_mobile = "8987896897";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";
            
            // your name of the recipient to add
            //string recipient_name = "Testing";

            // ifsc code
            //string ifsc = "sbin0000001";

            // account number
            //string acc_num = "61046336411";


            // default cust_id_type = mobile_number, also possibles types are Facebook_ID and Google_ID
            //string cust_id_type = "mobile_number";

           

           // string recipent_type = "1";

            // Type of Recipient ID ( 1 is Wallet, 2 is Utility and 3 is Account )
            //string recipient_id_type = "3";
           
           
            
            string body;

            // combining acc_num and ifsc to get a unique key
             string combined_key = acc_num + "_" + ifsc;
           
            
            // base url for adding a recipient
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";

            url = url + "mobile_number:" + recipient_mobile + "/recipients" + "/acc_ifsc:" + combined_key;

            body = "customer_id_type=" + cust_id_type  + "&recipient_type=" + recipent_type +
                    "&recipient_id_type=" + recipient_id_type  + "&recipient_name=" + recipient_name +
                    "&recipient_mobile=" + recipient_mobile + "&initiator_id=" + init_id;


            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
           
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            /// Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;
        }

        public String Get_All_Recipient_click(string init_id = "9910028267",string mobile_num = "9818526830",string dev_key = "becbbce45f79c6f5109f848acd540567")
        {
            
            // initiate id reference (should be configurable)
           // string init_id = "9910028267";

            // your mobile number
            //string mobile_num = "9818526830";

            // your API access key (should be configurable)
           // string dev_key = "becbbce45f79c6f5109f848acd540567";
           
    

            

            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num + "/recipients?initiator_id=" + init_id;

            //client making GET request with url
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            //Adding developer key in header
            request.AddHeader("developer_key", dev_key);

            IRestResponse response = client.Execute(request);


            /// Contains response from the server
            var content = response.Content;  
                  
            // Display response in a web form
            String reply = content.ToString();

            return reply;

        }

        public String Get_Recipient_click(string init_id = "9910028267",string mobile_num = "9818526830",string dev_key = "becbbce45f79c6f5109f848acd540567",
             string recipient_id = "10002921")
        {
            // initiate id reference (should be configurable)
            //string init_id = "9910028267";
           
            // your mobile number
            //string mobile_num = "9818526830";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";
      
           // id of the recipient
            //string recipient_id = "10002921";
        

            // base url for getting recipient info
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num + "/recipients/" + "recipient_id:" +recipient_id + "?initiator_id=" + init_id;

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            // Obtains response from the server
            IRestResponse response = client.Execute(request);

            // Contains response from the server
            var content = response.Content; 
            // Display response in a web form
            String reply = content.ToString();

            return reply;
        }

        public String Delete_Recipient_click(string init_id = "9910028267",string mobile_num = "5669023498", string dev_key = "becbbce45f79c6f5109f848acd540567",
             string recipient_id = "10002439")
        {
           

            // initiate id reference (should be configurable)
           // string init_id = "9910028267";

            // your mobile number
           // string mobile_num = "5669023498";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";

            // recipient id
           // string recipient_id = "10002439";
            

          

            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num + "/recipients/" + "recipient_id:" + recipient_id;

            string body = "initiator_id=" + init_id;

            var client = new RestClient(url);
            var request = new RestRequest(Method.DELETE);
          
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);

            // Obtains response from the server
            IRestResponse response = client.Execute(request);

            // Contains response from the server
            var content = response.Content; 
         
            // Display response in a web form
            String reply = content.ToString();

            return reply;
        
        }

        public String Get_All_Bank_click( string init_id = "9910028267", string dev_key = "becbbce45f79c6f5109f848acd540567")
        {

            // initiate id reference (should be configurable)
            //string init_id = "9910028267";

            // your API access key (should be configurable)
            //string dev_key = "becbbce45f79c6f5109f848acd540567";

         

            string url = "https://staging.eko.co.in:25004/ekoapi/v1/banks?";
            url = url + "initiator_id=" + init_id;

            //client calling GET method using url
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");


            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            IRestResponse response = client.Execute(request);

            // Contains response from the server
            var content = response.Content;

            // Display response in a web form
            String reply = content.ToString();

            return reply;

      }
	  
	  
	    public String Hold_and_commit_click(string recipient_id = "10002439",string amount = "800", string timestamp = "1990-01-01T01:01:01Z",
            string currency = "INR",string dev_key = "becbbce45f79c6f5109f848acd540567",string customer_id = "9901473431",string initiator_id = "9910028267", string client_ref_id = "1234",
            string hold_timeout = "100",string auth = "4176",string channel = "2",string state = "1")
        {
            

            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions";


            //string recipient_id = "10002439";

            //string amount = "800";

            //string timestamp = "1990-01-01T01:01:01Z";

            //string currency = "INR";

            //string dev_key = "becbbce45f79c6f5109f848acd540567";

            //string customer_id = "9901473431";

           // string initiator_id = "9910028267";

            // string client_ref_id = "1234";

            //string hold_timeout = "100";

            //string auth = "4176";

           // string channel = "2";

           // string state = "1";

            string body = "recipient_id=" + recipient_id + "&amount=" + amount +  "&timestamp=" + timestamp +
                      "&currency=" + currency + "&customer_id=" + customer_id +"&initiator_id=" + initiator_id + "&client_ref_id=" + client_ref_id + "&hold_timeout=" + hold_timeout
                          + "&state=" + state + "&pintwin=" + auth + "&channel=" + channel;

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

        public String Refund_Transaction_click(string client_ref_id="9076868",string initiator_id = "9910028267",string transaction_id ="12208775",
            string state = "1",string dev_key = "becbbce45f79c6f5109f848acd540567",string otp ="1754627962")
        {

            // curl -i -X POST -d "otp=1754627962&initiator_id=9910028267&state=1&client_ref_id=9076868" 
            // https://staging.eko.co.in:25004/ekoapi/v1/transactions/12208775/refund -H 'developer_key:becbbce45f79c6f5109f848acd540567'
            
           // string client_ref_id="9076868";

            //string initiator_id = "9910028267";

            //string transaction_id ="12208775";
            //string state = "1";

            //string dev_key = "becbbce45f79c6f5109f848acd540567";

             //string otp ="1754627962";


            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions/";
            url = url + transaction_id + "/refund";

            string body = "otp=" + otp + "&initiator_id=" + initiator_id + "&state=" + state+ "&client_ref_id=" + client_ref_id  ;


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

         public String Resend_Refund_Transaction_click(string transaction_id = "12212118",string mobile_number = "9910028267",string dev_key = "becbbce45f79c6f5109f848acd540567")
        {

            // curl -i -X POST -d "initiator_id=mobile_number:9910028267"
            //https://staging.eko.co.in:25004/ekoapi/v1/transactions/12212118/refund/otp -H 'developer_key:becbbce45f79c6f5109f848acd540567'
            

           // string transaction_id = "12212118";
            //string mobile_number = "9910028267";

            //string dev_key = "becbbce45f79c6f5109f848acd540567";
            string initiator_id = mobile_number;

            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions/";
            url = url + transaction_id + "/refund/otp";

            string body = "initiator_id=mobile_number:" + initiator_id;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content; /// Contains response from the server
                                            /// 

            return content.ToString();

        }

         public String Transaction_Enquiry_click(string transaction_id = "12212118",string mobile_number = "9910028267",string dev_key = "becbbce45f79c6f5109f848acd540567")
        {

            // https://staging.eko.co.in:25004/ekoapi/v1/transactions/12212118?initiator_id=mobile_number:9910028267 -H 'developer_key:becbbce45f79c6f5109f848acd540567' 
            
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions/";

            //string transaction_id = "12212118";

            //string mobile_number = "9910028267";
            //string dev_key = "becbbce45f79c6f5109f848acd540567";
            string initiator_id = mobile_number;


            url = url + transaction_id + "?initiator_id=mobile_number:" + initiator_id;

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
