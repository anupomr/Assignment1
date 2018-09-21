using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Threading.Tasks;
using Amazon.S3.Transfer;

// Add using statements to access AWS SDK for .NET services. 
// Both the Service and its Model namespace need to be added 
// in order to gain access to a service. For example, to access
// the EC2 service, add:
// using Amazon.EC2;
// using Amazon.EC2.Model;

namespace Assignment1
{
    class Program
    {
        private const string bucketName = "anus3buc";
        private const string keyName = "asign.docx";
        private const string filePath = "f:\\sem5\\asign1.docx";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast2;
        private static IAmazonS3 s3Client;
        public static void Main(string[] args)
        {
            s3Client = new AmazonS3Client(bucketRegion);
            UploadFileAsync().Wait();
            Console.Read();
        }

        private static async Task UploadFileAsync()
        {
            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);

                //Option 1.
                await fileTransferUtility.UploadAsync(filePath, bucketName);
                Console.WriteLine("Upload 1 complated");

                //Option 2.
                await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
                Console.WriteLine("Upload 1 complated");

            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server, Message: '{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server, Message: '{0}' when writing an object", e.Message);
            }


        }

    }

}