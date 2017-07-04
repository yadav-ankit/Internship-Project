using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;

using Newtonsoft.Json;


using Telegram;
using RestSharp;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputMessageContents;
using Telegram.Bot.Types.ReplyMarkups;


using System.IO;

using System.Threading.Tasks;


namespace Telegram.Bot.Examples.Echo
{



    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("434103926:AAG7MuV5TsC4XZLh-H_L_1t8yaAvdccWi0o");

        public string init = "";
        public string recipt = "";
        public static bool money_sended = false;
        static void Main(string[] args)
        {

            /*Bot.OnMessage += BotOnMessageReceived;
             Bot.OnMessageEdited += BotOnMessageReceived;
             Bot.OnReceiveError += BotOnReceiveError;

             var me = Bot.GetMeAsync().Result;

             Console.Title = me.Username;



             Bot.StartReceiving();
             Console.ReadLine();

             Bot.StopReceiving();*/


            try
            {
                GetContactPhone().Wait();
            }
            catch (AggregateException e)
            {
                throw e.InnerException;
            }
        }


        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Debugger.Break();
        }


        public static bool user_exist(string phone_number)
        {
            //merchant's unique reference (should be configurable)
            string init_id = phone_number;

            //customer's unique reference (should be configurable)
            string cust_id = "9962817283";

            // your API access key (should be configurable)
            string dev_key = "becbbce45f79c6f5109f848acd540567";

            string cust_id_type = "mobile_number";

            // sample otp
            string otp_req = "540";



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

            String a = content.ToString();

            if (a.Length != 0)
            {

                System.Console.WriteLine(a);


                if (a.IndexOf("Invalid") != -1)
                    return false;
                else
                    return true;


            }
            return false;
        }


        private static void send_confirmation(string message)
        {
            String send_url = "https://api.telegram.org/bot434103926:AAG7MuV5TsC4XZLh-H_L_1t8yaAvdccWi0o/sendmessage?chat_id=320531910";

            String text =  message;
            send_url = send_url + "&text=" + text;

            //client calling GET method using url
            var send_client = new RestClient(send_url);
            var send_request = new RestRequest(Method.POST);


            /// Obtains response from the server
            IRestResponse send_response = send_client.Execute(send_request);



        }





        public static void create_and_cust_at_backend(string num)
        {
            //merchant's unique reference (should be configurable)
            string init_id = num;


            //merchant's unique phone number (should be configurable)
            string mobile_num = "9962817283";

            // your API access key (should be configurable)
            string dev_key = "becbbce45f79c6f5109f848acd540567";

            // default cust_id_type = mobile_number, also possibles types are Facebook_ID and Google_ID
            string cust_id_type = "mobile_number";

            // a sample name for testing purpose
            string name = "Testing";


            // Base url for get Customer
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num;


            String body = "customer_id_type=" + cust_id_type + "&initiator_id=" + init_id + "&name=" + name;

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



        }

        public static void my_back_end(string str)
        {
            if (user_exist(str))
            {
                //Response.Write(str + " already exist !!!");

                string message = "hi " + str;
                message = message + "you can type /about_us\n/contact_us\n/send_money";
                send_confirmation( message);
                return;

            }
            else
            {
                // Response.Write(str + " You do not already exist .......Want to get added to Eko?");

                string message = " You do not already exist .....Want to get added to Eko? (Yes/No)";
                send_confirmation(message);
                
            }
        }


        public static bool Recipient_exist(string initiater,string recipt)
        {
            // initiate id reference (should be configurable)
            string init_id = initiater;

            // your mobile number
            string mobile_num = "9818526830";

            // your API access key (should be configurable)
            string dev_key = "becbbce45f79c6f5109f848acd540567";

            // id of the recipient
            string recipient_id = recipt;  //"10002921";


            // base url for getting recipient info
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/customers/";
            url = url + "mobile_number:" + mobile_num + "/recipients/" + "recipient_id:" + recipient_id + "?initiator_id=" + init_id;

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            /*Adding developer key in header*/
            request.AddHeader("developer_key", dev_key);

            // Obtains response from the server
            IRestResponse response = client.Execute(request);

            // Contains response from the server
            var content = response.Content;

            String a = content.ToString();

            if (a.Length != 0)
            {

                System.Console.WriteLine(a);


                if (a.IndexOf("Invalid") != -1)
                    return false;
                else
                    return true;


            }
            return false;

        }




        public static void send_money(string initiater, string recipt, string amount)
        {
            string url = "https://staging.eko.co.in:25004/ekoapi/v1/transactions";


            string recipient_id = recipt;

            

            string timestamp = "1990-01-01T01:01:01Z";

            string currency = "INR";

            string dev_key = "becbbce45f79c6f5109f848acd540567";

            string customer_id = "9901473431";

            string initiator_id = initiater;

            string client_ref_id = "1234";

            string hold_timeout = "100";

            string auth = "4176";

            string channel = "2";

            string state = "1";

            string body = "recipient_id=" + recipient_id + "&amount=" + amount + "&timestamp=" + timestamp +
                      "&currency=" + currency + "&customer_id=" + customer_id + "&initiator_id=" + initiator_id + "&client_ref_id=" + client_ref_id + "&hold_timeout=" + hold_timeout
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
                                            

            System.Console.WriteLine(content.ToString());

            money_sended = true;
            return;
        }




        static async Task GetContactPhone()
        {
            string ans = "";
            String intiater = "";
            var offset = 0;

            var keyboard = new ReplyKeyboardMarkup(new[]
                {

                    new [] // last row
                    {
                        new KeyboardButton("shared your contact")
                         {
                            RequestContact = true

                         }
                    },
                new [] // first row
                {
                    new KeyboardButton("about usا"),
                    new KeyboardButton("contact usا"),  
                }


            });
            int count = 1;
            while (true)
            {

                var Updates = await Bot.GetUpdates(offset);


                foreach (var update in Updates)
                {
                    Console.WriteLine("update " + count.ToString());
                    count++;
                    var message = update.Message;

                 
                    if ( update.Type == UpdateType.MessageUpdate && message.Type == MessageType.ContactMessage)
                    {
                        Console.WriteLine(update.Message.Chat.FirstName + " shared contact");

                        var cc = update.Message.Contact.PhoneNumber;
                        if (cc == null)
                        {
                            cc = "aa";
                        }
                        string ph = message.Contact.PhoneNumber;

                        if (ph.Length == 13)
                            ans = ph.Remove(0, 3);
                        else
                            if (ph.Length == 12)
                                ans = ph.Remove(0, 2);
                            else
                                if (ph.Length == 11)
                                    ans = ph.Remove(0, 1);
                                else
                                    ans = ph;
                        intiater = ans;
                       System.Console.WriteLine(intiater);
                        my_back_end(intiater);

                    }

                    else
                    {
                        if (message.Text == ("/start"))
                        {
                            Console.WriteLine(update.Message.Chat.FirstName + " start bot");
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Share your contact to get started", replyMarkup: keyboard);

                            var usage = @"Eko Bot:
            /start   - start conversation
            /contact_us - Our Contact
            /about_us   - About Eko
            /send_money";


                            await Bot.SendTextMessageAsync(message.Chat.Id, usage,
                                replyMarkup: new ReplyKeyboardHide());



                        }
                        else

                            if (message.Text == ("/about_us"))
                            {
                                Console.WriteLine(update.Message.Chat.FirstName + " pressed 'about us'");
                                await Bot.SendTextMessageAsync(message.Chat.Id, "We are a Financial Services Company", replyMarkup: null);



                            }
                            else
                                if (message.Text == "/contact_us")
                                {
                                    Console.WriteLine(update.Message.Chat.FirstName + "pressed 'contact us'");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "mail us at ankit_yadav@eko.co.in", replyMarkup: null);


                                }
                                else
                                    if (message.Text == "yes" || message.Text == "Yes")
                                    {
                                        await Bot.SendTextMessageAsync(message.Chat.Id, "we are adding you", replyMarkup: null);
                                        create_and_cust_at_backend(ans);
                                        await Bot.SendTextMessageAsync(message.Chat.Id, "kindly verify your phone number with OTP.Type your otp here ", replyMarkup: null);

                                    }
                                    else
                                        if (message.Text == "no" || message.Text == "No")
                                        {
                                            await Bot.SendTextMessageAsync(message.Chat.Id, "Sorry to see you go...", replyMarkup: null);
                                        }

                                        else
                                            if (message.Text == "540")
                                            {
                                                await Bot.SendTextMessageAsync(message.Chat.Id, "Otp Verified... Welcome to Eko", replyMarkup: null);

                                                var usage = @"Eko Bot:
            /start   - start conversation
            /contact_us - Our Contact
            /about_us   - About Eko
            /send_money";


                                                await Bot.SendTextMessageAsync(message.Chat.Id, usage,
                                                    replyMarkup: new ReplyKeyboardHide());
                                            }
                                            else
                                                if (message.Text == "/send_money")
                                                {
                                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Enter the phone number of the recipient", replyMarkup: keyboard);

                                                    var variable = 1;

                                                    while (true)
                                                    {
                                                        var new_updates = await Bot.GetUpdates(variable);


                                                        foreach (var i in new_updates)
                                                        {
                                                            var new_message = i.Message;
                                                            if(money_sended)
                                                            {
                                                                break;
                                                            }
                                                           
                                                            if (i.Type == UpdateType.MessageUpdate && new_message.Type == MessageType.ContactMessage)
                                                            {
                                                                //await Bot.SendTextMessageAsync(new_message.Chat.Id, "inside you", replyMarkup: null);

                                                                var cc = i.Message.Contact.PhoneNumber;
                                                                if (cc == null)
                                                                {
                                                                    cc = "aa";
                                                                }
                                                                string ph = new_message.Contact.PhoneNumber;

                                                                if (ph.Length == 13)
                                                                    ans = ph.Remove(0, 3);
                                                                else
                                                                    if (ph.Length == 12)
                                                                        ans = ph.Remove(0, 2);
                                                                    else
                                                                        if (ph.Length == 11)
                                                                            ans = ph.Remove(0, 1);
                                                                        else
                                                                            ans = ph;
                                                                String recipt = ans;

                                                                if (Recipient_exist(intiater, recipt))
                                                                {
                                                                    await Bot.SendTextMessageAsync(update.Message.Chat.Id, "Enter the amount", replyMarkup: null);
                                                                    send_money(intiater, recipt, "400");
                                                                    break;

                                                                }
                                                                else
                                                                {
                                                                    await Bot.SendTextMessageAsync(update.Message.Chat.Id, "No the recipient doesn't exist", replyMarkup: null);
                                                                    break;
                                                                }

                                                               

                                                            }
                                                        }

                                                        if (money_sended)
                                                        {
                                                            money_sended = false;
                                                            await Bot.SendTextMessageAsync(message.Chat.Id, update.Message.Chat.FirstName + " money transferred to " + ans, replyMarkup: null);
                                                            break;
                                                        }
                                                           

                                                    }
                                                }

                                                else
                                                {
                                                    var usage = @"Eko Bot:
            /start   - start conversation
            /contact_us - Our Contact
            /about_us   - About Eko
            /send_money";


                                                    await Bot.SendTextMessageAsync(message.Chat.Id, usage,
                                                        replyMarkup: new ReplyKeyboardHide());
                                                }

                    }
                    offset = update.Id + 1;
                }


            }

        }

    }
}
