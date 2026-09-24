using System;
using System.IO;
using System.Threading.Tasks;
using Oci.ObjectstorageService;
using Oci.Common;
using Oci.Common.Auth;

namespace Oci.Sdk.DotNet.Example.Objectstorage
{
    public class PutObjectExample
    {
        public static async Task Main()
        {
            
            string filePath = "testfile.txt";
            var putObjectRequest = new Oci.ObjectstorageService.Requests.PutObjectRequest
			{
				NamespaceName = "sehubjapaciaas",
				BucketName = "html_files",
				ObjectName = "demo",
                ContentLength = new FileInfo(filePath).Length,
                PutObjectBody = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read),
				};

            var provider = new ConfigFileAuthenticationDetailsProvider("DEFAULT");
            try
            {
                
				using (var client = new ObjectStorageClient(provider, new ClientConfiguration()))
				{
					var response = await client.PutObject(putObjectRequest);
					var hasValueValue = response.LastModified.HasValue;
				}
            }
            catch (Exception e)
            {
                Console.WriteLine($"PutObject Failed with {e.Message}");
                throw e;
            }
        }
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}