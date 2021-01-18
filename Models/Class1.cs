//using system;
//using system.collections.generic;
//using system.linq;
//using system.web;

//namespace webapplication1.models
//{
//    public class class1
//    {
//        class program

//        {

//            class mainclass



//            {



//                public static void main(string[] args)



//                {



//                    runasync().wait();



//                }







//                static async task runasync()



//                {



//                    //string apikey = "acc_c4ce731bb14dcf7";



//                    //string apisecret = "8d833fd35787d0450fc558d13451d0f2";



//                    //string imageurl = "https://assets.marthastewart.com/styles/wmax-300/d33/vanilla-icecream-0611med107092des/vanilla-icecream-0611med107092des_vert.jpg?itok=_pkpvvkv";



//                    //string basicauthvalue = system.convert.tobase64string(system.text.encoding.utf8.getbytes(string.format("{0}:{1}", apikey, apisecret)));



//                    string url = "https://api.nal.usda.gov/ndb/v2/";



//                    string productid = "01009";



//                    using (var client = new httpclient())



//                    {



//                        client.baseaddress = new uri(url);



//                        client.defaultrequestheaders.accept.clear();



//                        client.defaultrequestheaders.accept.add(new mediatypewithqualityheadervalue(@"application/json"));



//                        //client.defaultrequestheaders.add("authorization", string.format("basic {0}", basicauthvalue));







//                        httpresponsemessage response = await client.getasync(string.format("reports?ndbno={0}&type=f&format=json&api_key=zde2nknxvyuafo6unebx601asrozcazdcaptw3sn", productid));







//                        httpcontent content = response.content;



//                        string result = await content.readasstringasync();





//                        jobject jobject = jobject.parse(result);



//                        //var selectedtages = (from t in jobject["foods"]["food"]["nutrients"]

//                        //                     select new { name = (string)t["name"], value = (string)t["value"]});







//                        foreach (var item in jobject["foods"])



//                        {



//                            console.writeline(item["food"]["nutrients"]);



//                        }

//                    }



//                }

//            }
//        }
//    }
//}